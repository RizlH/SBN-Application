using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using SBN_Application.Forms.InputForms;
using SBN_Application.Data;
using SBN_Application.Services;
using Microsoft.EntityFrameworkCore;
using SBN_Application.Models;

namespace SBN_Application.Forms.Menus
{
    public partial class AssetPage : UserControl
    {
        private readonly AppDbContext _context;
        private readonly AssetService _assetService;

        public AssetPage()
        {
            InitializeComponent();
            _context = new AppDbContext();
            _assetService = new AssetService(_context);

            // Wire up event handlers
            buttondeleteasset.Click += ButtonDeleteAsset_Click;
            dataGridViewasset.CellDoubleClick += DataGridViewAsset_CellDoubleClick;

            // Load data saat form dimuat
            this.Load += AssetPage_Load;
        }

        private void AssetPage_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadAssetDataAsync();
        }

        // Konfigurasi DataGridView
        private void ConfigureDataGridView()
        {
            dataGridViewasset.AutoGenerateColumns = false;
            dataGridViewasset.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewasset.MultiSelect = false;
            dataGridViewasset.ReadOnly = true;
            dataGridViewasset.AllowUserToAddRows = false;
            dataGridViewasset.RowHeadersVisible = false;

            // Clear existing columns
            dataGridViewasset.Columns.Clear();

            // Kolom ID (hidden)
            dataGridViewasset.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id_Asset",
                HeaderText = "ID",
                Name = "Id_Asset",
                Visible = false
            });

            // Kolom Nama Buyer
            dataGridViewasset.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nama_Buyer",
                HeaderText = "Nama Buyer",
                Name = "Nama_Buyer",
                Width = 150
            });

            // Kolom Nama SBN
            dataGridViewasset.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nama_Sbn",
                HeaderText = "Nama SBN - Kode SBN",
                Name = "Nama_Sbn",
                Width = 300
            });

            // Kolom Modal (Rp dan rata kiri)
            var modalColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Modal",
                HeaderText = "Modal",
                Name = "Modal",
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Format = "N0",
                    FormatProvider = new System.Globalization.CultureInfo("id-ID")
                }
            };
            dataGridViewasset.Columns.Add(modalColumn);

            // Kolom Fixed Rate
            var fixedRateColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Fixed_Rate",
                HeaderText = "Fixed Rate",
                Name = "Fixed_Rate",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Format = "P1" // nanti kita override di CellFormatting
                }
            };
            dataGridViewasset.Columns.Add(fixedRateColumn);


            // Kolom Tenor (dalam tahun)
            var tenorColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Tenor",
                HeaderText = "Tenor",
                Name = "Tenor",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };
            dataGridViewasset.Columns.Add(tenorColumn);

            // Kolom Total Diterima (Rp dan rata kiri)
            var totalColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Total_Diterima",
                HeaderText = "Total Diterima",
                Name = "Total_Diterima",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Format = "N0",
                    FormatProvider = new System.Globalization.CultureInfo("id-ID")
                }
            };
            dataGridViewasset.Columns.Add(totalColumn);

            // Kolom Tanggal Dibuat
            dataGridViewasset.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Created_At",
                HeaderText = "Tanggal Dibuat",
                Name = "Created_At",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy"
                }
            });

            // Hapus event ganda kalau sudah ada sebelumnya
            dataGridViewasset.CellFormatting -= DataGridViewasset_CellFormatting;
            dataGridViewasset.CellFormatting += DataGridViewasset_CellFormatting;
        }


        // === Event handler terpisah ===
        private void DataGridViewasset_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;

            if (grid.Columns[e.ColumnIndex].Name == "Modal" && e.Value != null)
            {
                e.Value = $"Rp {Convert.ToDecimal(e.Value):N0}";
                e.FormattingApplied = true;
            }
            else if (grid.Columns[e.ColumnIndex].Name == "Total_Diterima" && e.Value != null)
            {
                e.Value = $"Rp {Convert.ToDecimal(e.Value):N0}";
                e.FormattingApplied = true;
            }
            else if (grid.Columns[e.ColumnIndex].Name == "Fixed_Rate" && e.Value != null)
            {
                decimal rate = Convert.ToDecimal(e.Value);

                // Jika datanya tersimpan dalam bentuk desimal murni (misal 6.3), tampilkan langsung
                if (rate > 1)
                    e.Value = $"{rate:N1}%";
                else
                    e.Value = $"{rate * 100:N1}%"; // jika tersimpan 0.063 maka hasilnya 6,3%

                e.FormattingApplied = true;
            }

            else if (grid.Columns[e.ColumnIndex].Name == "Tenor" && e.Value != null)
            {
                double bulan = Convert.ToDouble(e.Value);
                double tahun = bulan / 12.0;
                e.Value = $"{tahun:N0} Tahun";
                e.FormattingApplied = true;
            }
            else if (grid.Columns[e.ColumnIndex].Name == "Nama_Sbn" && e.Value != null)
            {
                // Ambil data row terkait
                var row = grid.Rows[e.RowIndex].DataBoundItem;

                if (row != null)
                {
                    // Gunakan refleksi untuk ambil properti lain (jika ada)
                    var kodeProp = row.GetType().GetProperty("Kode_Sbn");
                    if (kodeProp != null)
                    {
                        var kodeSbn = kodeProp.GetValue(row)?.ToString();
                        e.Value = $"{e.Value} - {kodeSbn}";
                        e.FormattingApplied = true;
                    }
                }
            }
        }




        // Load data asset ke DataGridView
        private async Task LoadAssetDataAsync()
        {
            try
            {
                // Suspend layout untuk performa lebih baik
                dataGridViewasset.SuspendLayout();

                // Simpan posisi scroll jika ada
                int firstDisplayedScrollingRowIndex = 0;
                if (dataGridViewasset.FirstDisplayedScrollingRowIndex >= 0)
                {
                    firstDisplayedScrollingRowIndex = dataGridViewasset.FirstDisplayedScrollingRowIndex;
                }

                // Clear selection dan binding
                dataGridViewasset.ClearSelection();
                dataGridViewasset.DataSource = null;

                // Force clear rows
                if (dataGridViewasset.Rows.Count > 0)
                {
                    dataGridViewasset.Rows.Clear();
                }

                // Gunakan service untuk mendapatkan data fresh dari database
                var assets = await _assetService.GetAllAssets();

                // Konversi ke format untuk DataGridView
                var displayData = assets.Select(a => new
                {
                    a.Id_Asset,
                    Nama_Buyer = a.Buyer?.Nama_Buyer ?? "N/A",
                    Nama_Sbn = $"{(a.Sbn?.Nama_Sbn ?? "N/A")} - {(a.Sbn?.Kode_Sbn ?? "N/A")}",
                    a.Modal,
                    Fixed_Rate = a.Sbn?.Fixed_Rate ?? 0,  // ← ambil dari relasi SBN
                    a.Tenor,
                    a.Total_Diterima,
                    a.Created_At
                }).ToList();






                // Rebind data
                dataGridViewasset.DataSource = displayData;

                // Kembalikan posisi scroll
                if (firstDisplayedScrollingRowIndex < dataGridViewasset.Rows.Count && firstDisplayedScrollingRowIndex >= 0)
                {
                    dataGridViewasset.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
                }

                // Update label untuk menampilkan jumlah data
                label1.Text = $"Asset Page ({displayData.Count} data)";

                // Resume layout
                dataGridViewasset.ResumeLayout();
            }
            catch (Exception ex)
            {
                dataGridViewasset.ResumeLayout();
                MessageBox.Show($"Error saat memuat data: {ex.Message}\n\nDetail: {ex.InnerException?.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Event handler untuk tombol Input
        private async void buttoninputasset_Click(object sender, EventArgs e)
        {
            using (var inputContext = new AppDbContext())
            {
                var inputService = new AssetService(inputContext);
                using (InputAsset inputasset = new InputAsset(inputContext))
                {
                    if (inputasset.ShowDialog() == DialogResult.OK)
                    {
                        // Refresh menggunakan context utama
                        await LoadAssetDataAsync();
                    }
                }
            }
        }

        // Event handler untuk double click pada row (untuk edit)
        private async void DataGridViewAsset_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var assetId = Convert.ToInt32(dataGridViewasset.Rows[e.RowIndex].Cells["Id_Asset"].Value);

                using (var editContext = new AppDbContext())
                {
                    var editService = new AssetService(editContext);
                    using (InputAsset editForm = new InputAsset(editContext, assetId))
                    {
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            // Refresh menggunakan context utama
                            await LoadAssetDataAsync();
                        }
                    }
                }
            }
        }

        // Event handler untuk tombol Delete
        private async void ButtonDeleteAsset_Click(object sender, EventArgs e)
        {
            if (dataGridViewasset.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data yang ingin dihapus!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridViewasset.SelectedRows[0];
            var assetId = Convert.ToInt32(selectedRow.Cells["Id_Asset"].Value);
            var buyerName = selectedRow.Cells["Nama_Buyer"].Value.ToString();
            var sbnName = selectedRow.Cells["Nama_Sbn"].Value.ToString();

            var result = MessageBox.Show(
                $"Apakah Anda yakin ingin menghapus asset?\n\n" +
                $"Buyer: {buyerName}\n" +
                $"SBN: {sbnName}",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Gunakan service untuk delete
                    bool deleted = await _assetService.DeleteAsset(assetId);

                    if (deleted)
                    {
                        MessageBox.Show("Data asset berhasil dihapus!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadAssetDataAsync(); // Refresh data
                    }
                    else
                    {
                        MessageBox.Show("Data asset tidak ditemukan!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saat menghapus data: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
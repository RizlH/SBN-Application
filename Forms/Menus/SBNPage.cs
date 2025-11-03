using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using SBN_Application.Forms.InputForms;
using SBN_Application.Data;
using SBN_Application.Services;
using Microsoft.EntityFrameworkCore;

namespace SBN_Application.Forms.Menus
{
    public partial class SBNPage : UserControl
    {
        private readonly AppDbContext _context;
        private readonly SBNService _sbnService;

        public SBNPage()
        {
            InitializeComponent();
            _context = new AppDbContext();
            _sbnService = new SBNService(_context);

            // Wire up event handlers
            buttondeletesbn.Click += ButtonDeleteSBN_Click;
            dataGridViewsbn.CellDoubleClick += DataGridViewSBN_CellDoubleClick;

            // Load data saat form dimuat
            this.Load += SBNPage_Load;
        }

        private void SBNPage_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadSBNDataAsync();
        }

        // Konfigurasi DataGridView
        // ===============================
        // Konfigurasi DataGridView (mirip Asset Page)
        // ===============================
        // ===============================
        // Konfigurasi DataGridView (versi final mirip Asset Page)
        // ===============================
        private void ConfigureDataGridView()
        {
            dataGridViewsbn.AutoGenerateColumns = false;
            dataGridViewsbn.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewsbn.MultiSelect = false;
            dataGridViewsbn.ReadOnly = true;
            dataGridViewsbn.AllowUserToAddRows = false;
            dataGridViewsbn.RowHeadersVisible = false;

            // Bersihkan kolom lama
            dataGridViewsbn.Columns.Clear();

            // Kolom ID (hidden)
            dataGridViewsbn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id_Sbn",
                HeaderText = "ID",
                Name = "Id_Sbn",
                Visible = false
            });

            // Nama SBN
            dataGridViewsbn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nama_Sbn",
                HeaderText = "Nama SBN",
                Name = "Nama_Sbn",
                Width = 230
            });

            // Kode SBN
            dataGridViewsbn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Kode_Sbn",
                HeaderText = "Kode SBN",
                Name = "Kode_Sbn",
                Width = 120
            });

            // Deskripsi
            dataGridViewsbn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Deskripsi",
                HeaderText = "Deskripsi",
                Name = "Deskripsi",
                Width = 300
            });

            // Tipe Investor
            dataGridViewsbn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Tipe_Investor",
                HeaderText = "Tipe Investor",
                Name = "Tipe_Investor",
                Width = 200
            });

            // Min. Pembelian (Rp, rata kiri)
            var minPembelianColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Min_Beli",
                HeaderText = "Min. Pembelian",
                Name = "Min_Beli",
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft // rata kiri
                }
            };
            dataGridViewsbn.Columns.Add(minPembelianColumn);

            // Fixed Rate (6,30%)
            var fixedRateColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Fixed_Rate",
                HeaderText = "Fixed Rate",
                Name = "Fixed_Rate",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };
            dataGridViewsbn.Columns.Add(fixedRateColumn);

            // Tanggal dibuat
            dataGridViewsbn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Created_At",
                HeaderText = "Tanggal Dibuat",
                Name = "Created_At",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy"
                }
            });

            // Tambahkan event formatting
            dataGridViewsbn.CellFormatting += dataGridViewsbn_CellFormatting;
        }

        // Event formatting khusus Min_Beli & Fixed_Rate
        private void dataGridViewsbn_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var culture = new System.Globalization.CultureInfo("id-ID");

            // Format kolom Min_Beli jadi Rp X.XXX.XXX
            if (dataGridViewsbn.Columns[e.ColumnIndex].Name == "Min_Beli" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal nominal))
                {
                    e.Value = $"Rp {nominal.ToString("N0", culture)}";
                    e.FormattingApplied = true;
                }
            }

            // Format kolom Fixed_Rate jadi X,XX%
            if (dataGridViewsbn.Columns[e.ColumnIndex].Name == "Fixed_Rate" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal rate))
                {
                    if (rate < 1) rate *= 100; // kalau masih 0.063 → 6.30
                    e.Value = $"{rate.ToString("N2", culture)}%";
                    e.FormattingApplied = true;
                }
            }
        }




        // Load data SBN ke DataGridView menggunakan SBNService
        private async Task LoadSBNDataAsync()
        {
            try
            {
                // Suspend layout untuk performa lebih baik
                dataGridViewsbn.SuspendLayout();

                // Simpan posisi scroll jika ada
                int firstDisplayedScrollingRowIndex = 0;
                if (dataGridViewsbn.FirstDisplayedScrollingRowIndex >= 0)
                {
                    firstDisplayedScrollingRowIndex = dataGridViewsbn.FirstDisplayedScrollingRowIndex;
                }

                // Clear selection dan binding
                dataGridViewsbn.ClearSelection();
                dataGridViewsbn.DataSource = null;

                // Force clear rows
                if (dataGridViewsbn.Rows.Count > 0)
                {
                    dataGridViewsbn.Rows.Clear();
                }

                // Gunakan service untuk mendapatkan data fresh dari database
                var sbns = await _sbnService.GetAllSBN();

                // Rebind data
                dataGridViewsbn.DataSource = sbns;

                // Kembalikan posisi scroll
                if (firstDisplayedScrollingRowIndex < dataGridViewsbn.Rows.Count && firstDisplayedScrollingRowIndex >= 0)
                {
                    dataGridViewsbn.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
                }

                // Update label untuk menampilkan jumlah data
                label1.Text = $"SBN Page ({sbns.Count} data)";

                // Resume layout
                dataGridViewsbn.ResumeLayout();
            }
            catch (Exception ex)
            {
                dataGridViewsbn.ResumeLayout();
                MessageBox.Show($"Error saat memuat data: {ex.Message}\n\nDetail: {ex.InnerException?.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler untuk tombol Input
        private async void buttoninputsbn_Click(object sender, EventArgs e)
        {
            using (var inputContext = new AppDbContext())
            {
                var inputService = new SBNService(inputContext);
                using (InputSBN inputsbn = new InputSBN(inputContext))
                {
                    if (inputsbn.ShowDialog() == DialogResult.OK)
                    {
                        // Refresh menggunakan context utama
                        await LoadSBNDataAsync();
                    }
                }
            }
        }

        // Event handler untuk double click pada row (untuk edit)
        private async void DataGridViewSBN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Abaikan klik di header atau baris kosong
                if (e.RowIndex < 0 || e.RowIndex >= dataGridViewsbn.Rows.Count)
                    return;

                var row = dataGridViewsbn.Rows[e.RowIndex];

                // Pastikan kolom Id_Sbn ada dan punya nilai
                if (!row.Cells.Contains(row.Cells["Id_Sbn"]) || row.Cells["Id_Sbn"].Value == null)
                    return;

                if (!int.TryParse(row.Cells["Id_Sbn"].Value.ToString(), out int sbnId))
                    return;

                using (var editContext = new AppDbContext())
                {
                    var editService = new SBNService(editContext);
                    using (InputSBN editForm = new InputSBN(editContext, sbnId))
                    {
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            await LoadSBNDataAsync(); // Refresh setelah edit
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi error saat membuka form edit:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler untuk tombol Delete menggunakan SBNService
        private async void ButtonDeleteSBN_Click(object sender, EventArgs e)
        {
            if (dataGridViewsbn.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data yang ingin dihapus!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridViewsbn.SelectedRows[0];
            var sbnId = Convert.ToInt32(selectedRow.Cells["Id_Sbn"].Value);
            var sbnName = selectedRow.Cells["Nama_Sbn"].Value.ToString();

            var result = MessageBox.Show(
                $"Apakah Anda yakin ingin menghapus SBN '{sbnName}'?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Gunakan service untuk delete
                    bool deleted = await _sbnService.DeleteSBN(sbnId);

                    if (deleted)
                    {
                        MessageBox.Show("Data buyer berhasil dihapus!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadSBNDataAsync(); // Refresh data
                    }
                    else
                    {
                        MessageBox.Show("Data SBN tidak ditemukan!", "Error",
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
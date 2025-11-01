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
    public partial class BuyerPage : UserControl
    {
        private readonly AppDbContext _context;
        private readonly BuyerService _buyerService;

        public BuyerPage()
        {
            InitializeComponent();
            _context = new AppDbContext();
            _buyerService = new BuyerService(_context);

            // Wire up event handlers
            buttondeletebuyer.Click += ButtonDeleteBuyer_Click;
            dataGridViewbuyer.CellDoubleClick += DataGridViewBuyer_CellDoubleClick;

            // Load data saat form dimuat
            this.Load += BuyerPage_Load;
        }

        private void BuyerPage_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadBuyerDataAsync();
        }

        // Konfigurasi DataGridView
        private void ConfigureDataGridView()
        {
            dataGridViewbuyer.AutoGenerateColumns = false;
            dataGridViewbuyer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewbuyer.MultiSelect = false;
            dataGridViewbuyer.ReadOnly = true;
            dataGridViewbuyer.AllowUserToAddRows = false;
            dataGridViewbuyer.RowHeadersVisible = false;

            // Clear existing columns
            dataGridViewbuyer.Columns.Clear();

            // Tambah kolom ID tapi HIDDEN
            dataGridViewbuyer.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id_Buyer",
                HeaderText = "ID",
                Name = "Id_Buyer",
                Visible = false
            });

            dataGridViewbuyer.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nama_Buyer",
                HeaderText = "Nama Buyer",
                Name = "Nama_Buyer",
                Width = 200
            });

            dataGridViewbuyer.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "No_Telp",
                HeaderText = "No. Telp",
                Name = "No_Telp",
                Width = 120
            });

            dataGridViewbuyer.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Name = "Email",
                Width = 200
            });

            dataGridViewbuyer.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Alamat",
                HeaderText = "Alamat",
                Name = "Alamat",
                Width = 250
            });

            dataGridViewbuyer.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "No_Rek",
                HeaderText = "No. Rekening",
                Name = "No_Rek",
                Width = 150
            });

            dataGridViewbuyer.Columns.Add(new DataGridViewTextBoxColumn
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
        }

        // Load data buyer ke DataGridView menggunakan BuyerService
        private async Task LoadBuyerDataAsync()
        {
            try
            {
                // Suspend layout untuk performa lebih baik
                dataGridViewbuyer.SuspendLayout();

                // Simpan posisi scroll jika ada
                int firstDisplayedScrollingRowIndex = 0;
                if (dataGridViewbuyer.FirstDisplayedScrollingRowIndex >= 0)
                {
                    firstDisplayedScrollingRowIndex = dataGridViewbuyer.FirstDisplayedScrollingRowIndex;
                }

                // Clear selection dan binding
                dataGridViewbuyer.ClearSelection();
                dataGridViewbuyer.DataSource = null;

                // Force clear rows
                if (dataGridViewbuyer.Rows.Count > 0)
                {
                    dataGridViewbuyer.Rows.Clear();
                }

                // Gunakan service untuk mendapatkan data fresh dari database
                var buyers = await _buyerService.GetAllBuyers();

                // Rebind data
                dataGridViewbuyer.DataSource = buyers;

                // Kembalikan posisi scroll
                if (firstDisplayedScrollingRowIndex < dataGridViewbuyer.Rows.Count && firstDisplayedScrollingRowIndex >= 0)
                {
                    dataGridViewbuyer.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
                }

                // Update label untuk menampilkan jumlah data
                label1.Text = $"Buyer Page ({buyers.Count} data)";

                // Resume layout
                dataGridViewbuyer.ResumeLayout();
            }
            catch (Exception ex)
            {
                dataGridViewbuyer.ResumeLayout();
                MessageBox.Show($"Error saat memuat data: {ex.Message}\n\nDetail: {ex.InnerException?.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler untuk tombol Input
        private async void buttoninputbuyer_Click(object sender, EventArgs e)
        {
            using (var inputContext = new AppDbContext())
            {
                var inputService = new BuyerService(inputContext);
                using (InputBuyer inputbuyer = new InputBuyer(inputContext))
                {
                    if (inputbuyer.ShowDialog() == DialogResult.OK)
                    {
                        // Refresh menggunakan context utama
                        await LoadBuyerDataAsync();
                    }
                }
            }
        }

        // Event handler untuk double click pada row (untuk edit)
        private async void DataGridViewBuyer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var buyerId = Convert.ToInt32(dataGridViewbuyer.Rows[e.RowIndex].Cells["Id_Buyer"].Value);

                using (var editContext = new AppDbContext())
                {
                    var editService = new BuyerService(editContext);
                    using (InputBuyer editForm = new InputBuyer(editContext, buyerId))
                    {
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            // Refresh menggunakan context utama
                            await LoadBuyerDataAsync();
                        }
                    }
                }
            }
        }

        // Event handler untuk tombol Delete menggunakan BuyerService
        private async void ButtonDeleteBuyer_Click(object sender, EventArgs e)
        {
            if (dataGridViewbuyer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data yang ingin dihapus!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridViewbuyer.SelectedRows[0];
            var buyerId = Convert.ToInt32(selectedRow.Cells["Id_Buyer"].Value);
            var buyerName = selectedRow.Cells["Nama_Buyer"].Value.ToString();

            var result = MessageBox.Show(
                $"Apakah Anda yakin ingin menghapus buyer '{buyerName}'?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Gunakan service untuk delete
                    bool deleted = await _buyerService.DeleteBuyer(buyerId);

                    if (deleted)
                    {
                        MessageBox.Show("Data buyer berhasil dihapus!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadBuyerDataAsync(); // Refresh data
                    }
                    else
                    {
                        MessageBox.Show("Data buyer tidak ditemukan!", "Error",
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
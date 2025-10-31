using System;
using System.Linq;
using System.Windows.Forms;
using SBN_Application.Forms.InputForms;
using SBN_Application.Data;
using Microsoft.EntityFrameworkCore;

namespace SBN_Application.Forms.Menus
{
    public partial class BuyerPage : UserControl
    {
        private readonly AppDbContext _context;

        public BuyerPage()
        {
            InitializeComponent();
            _context = new AppDbContext();

            // Wire up event handlers
            buttondeletebuyer.Click += ButtonDeleteBuyer_Click;
            dataGridViewbuyer.CellDoubleClick += DataGridViewBuyer_CellDoubleClick;

            // Load data saat form dimuat
            this.Load += BuyerPage_Load;
        }

        private void BuyerPage_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadBuyerData();
        }

        // Konfigurasi DataGridView
        private void ConfigureDataGridView()
        {
            dataGridViewbuyer.AutoGenerateColumns = false;
            dataGridViewbuyer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewbuyer.MultiSelect = false;
            dataGridViewbuyer.ReadOnly = true;
            dataGridViewbuyer.AllowUserToAddRows = false;
            dataGridViewbuyer.RowHeadersVisible = false; // Sembunyikan header row

            // Clear existing columns
            dataGridViewbuyer.Columns.Clear();

            // Tambah kolom ID tapi HIDDEN
            dataGridViewbuyer.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id_Buyer",
                HeaderText = "ID",
                Name = "Id_Buyer",
                Visible = false // SEMBUNYIKAN KOLOM ID
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

        // Load data buyer ke DataGridView
        private void LoadBuyerData()
        {
            try
            {
                // Buat context baru untuk setiap load data
                using (var loadContext = new AppDbContext())
                {
                    var buyers = loadContext.Buyers
                        .OrderBy(b => b.Nama_Buyer)
                        .ToList();

                    dataGridViewbuyer.DataSource = null; // Reset dulu
                    dataGridViewbuyer.DataSource = buyers;

                    // Update label untuk menampilkan jumlah data
                    label1.Text = $"Buyer Page ({buyers.Count} data)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler untuk tombol Input
        private void buttoninputbuyer_Click(object sender, EventArgs e)
        {
            using (InputBuyer inputbuyer = new InputBuyer())
            {
                if (inputbuyer.ShowDialog() == DialogResult.OK)
                {
                    LoadBuyerData(); // Refresh data setelah input
                }
            }
        }

        // Event handler untuk double click pada row (untuk edit)
        private void DataGridViewBuyer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var buyerId = Convert.ToInt32(dataGridViewbuyer.Rows[e.RowIndex].Cells["Id_Buyer"].Value);

                using (InputBuyer editForm = new InputBuyer(buyerId))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadBuyerData(); // Refresh data setelah edit
                    }
                }
            }
        }

        // Event handler untuk tombol Delete
        private void ButtonDeleteBuyer_Click(object sender, EventArgs e)
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
                    // Gunakan context baru untuk delete
                    using (var deleteContext = new AppDbContext())
                    {
                        var buyer = deleteContext.Buyers.Find(buyerId);
                        if (buyer != null)
                        {
                            deleteContext.Buyers.Remove(buyer);
                            deleteContext.SaveChanges();

                            MessageBox.Show("Data buyer berhasil dihapus!", "Sukses",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadBuyerData(); // Refresh data
                        }
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
using System;
using System.Linq;
using System.Windows.Forms;
using SBN_Application.Data;
using SBN_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace SBN_Application.Forms.InputForms
{
    public partial class InputBuyer : Form
    {
        private AppDbContext _context;
        private int? _buyerId = null;
        private bool _isEditMode = false;

        // Constructor untuk mode tambah
        public InputBuyer()
        {
            InitializeComponent();
            _context = new AppDbContext();
            _isEditMode = false;
            this.Text = "Tambah Data Buyer";
        }

        // Constructor untuk mode edit
        public InputBuyer(int buyerId)
        {
            InitializeComponent();
            _context = new AppDbContext();

            _buyerId = buyerId;
            _isEditMode = true;
            this.Text = "Edit Data Buyer";
            buttonDelBuyer.Visible = true;
            buttonAddBuyer.Text = "Update";

            LoadBuyerData();
        }

        // Load data buyer untuk edit
        private void LoadBuyerData()
        {
            try
            {
                var buyer = _context.Buyers.Find(_buyerId);
                if (buyer != null)
                {
                    textBoxNamaBuyer.Text = buyer.Nama_Buyer;
                    textBoxNoTelp.Text = buyer.No_Telp;
                    textBoxEmailBuyer.Text = buyer.Email;
                    textBoxAlamatBuyer.Text = buyer.Alamat;
                    textBoxNoRek.Text = buyer.No_Rek;
                }
                else
                {
                    MessageBox.Show("Data buyer tidak ditemukan!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        // Event handler untuk tombol Tambah/Update
        private void ButtonAddBuyer_Click(object sender, EventArgs e)
        {
            // Validasi input
            if (!ValidateInput())
                return;

            try
            {
                if (_isEditMode)
                {
                    UpdateBuyer();
                }
                else
                {
                    AddBuyer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Validasi input
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxNamaBuyer.Text))
            {
                MessageBox.Show("Nama Buyer harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNamaBuyer.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxNoTelp.Text))
            {
                MessageBox.Show("No. Telp harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNoTelp.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxEmailBuyer.Text))
            {
                MessageBox.Show("Email harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmailBuyer.Focus();
                return false;
            }

            // Validasi format email sederhana
            if (!textBoxEmailBuyer.Text.Contains("@") || !textBoxEmailBuyer.Text.Contains("."))
            {
                MessageBox.Show("Format email tidak valid!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmailBuyer.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxAlamatBuyer.Text))
            {
                MessageBox.Show("Alamat harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxAlamatBuyer.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxNoRek.Text))
            {
                MessageBox.Show("No. Rekening harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNoRek.Focus();
                return false;
            }

            return true;
        }

        // Tambah buyer baru
        private void AddBuyer()
        {
            try
            {
                var buyer = new Buyer
                {
                    Nama_Buyer = textBoxNamaBuyer.Text.Trim(),
                    No_Telp = textBoxNoTelp.Text.Trim(),
                    Email = textBoxEmailBuyer.Text.Trim(),
                    Alamat = textBoxAlamatBuyer.Text.Trim(),
                    No_Rek = textBoxNoRek.Text.Trim(),
                    Created_At = DateTime.Now
                };

                _context.Buyers.Add(buyer);

                // Simpan dengan error handling detail
                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateException dbEx)
                {
                    var innerException = dbEx.InnerException?.Message ?? dbEx.Message;
                    MessageBox.Show($"Database Error:\n{innerException}\n\nPastikan:\n1. Tabel 'Buyers' sudah dibuat\n2. Semua kolom sudah sesuai\n3. Database PostgreSQL sudah running",
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Data buyer berhasil ditambahkan!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear form untuk input berikutnya
                this.DialogResult = DialogResult.OK;
                this.Close();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n\nInner Exception: {ex.InnerException?.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Update buyer
        private void UpdateBuyer()
        {
            try
            {
                var buyer = _context.Buyers.Find(_buyerId);
                if (buyer != null)
                {
                    buyer.Nama_Buyer = textBoxNamaBuyer.Text.Trim();
                    buyer.No_Telp = textBoxNoTelp.Text.Trim();
                    buyer.Email = textBoxEmailBuyer.Text.Trim();
                    buyer.Alamat = textBoxAlamatBuyer.Text.Trim();
                    buyer.No_Rek = textBoxNoRek.Text.Trim();

                    _context.SaveChanges();

                    MessageBox.Show("Data buyer berhasil diupdate!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Data buyer tidak ditemukan!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat mengupdate data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler untuk tombol Hapus
        private void ButtonDelBuyer_Click(object sender, EventArgs e)
        {
            if (!_isEditMode || !_buyerId.HasValue)
                return;

            var result = MessageBox.Show(
                "Apakah Anda yakin ingin menghapus data buyer ini?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var buyer = _context.Buyers.Find(_buyerId);
                    if (buyer != null)
                    {
                        _context.Buyers.Remove(buyer);
                        _context.SaveChanges();

                        MessageBox.Show("Data buyer berhasil dihapus!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saat menghapus data: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Clear semua textbox
        private void ClearForm()
        {
            textBoxNamaBuyer.Clear();
            textBoxNoTelp.Clear();
            textBoxEmailBuyer.Clear();
            textBoxAlamatBuyer.Clear();
            textBoxNoRek.Clear();
            textBoxNamaBuyer.Focus();
        }

        private void buttonDelBuyer_Click_1(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
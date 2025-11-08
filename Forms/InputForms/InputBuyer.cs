using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using SBN_Application.Data;
using SBN_Application.Models;
using SBN_Application.Services;

namespace SBN_Application.Forms.InputForms
{
    public partial class InputBuyer : Form
    {
        private readonly AppDbContext _context;
        private readonly BuyerService _buyerService;
        private int? _buyerId;
        private bool _isEditMode;

        // Constructor untuk mode Add (tanpa buyerId)
        public InputBuyer(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
            _buyerService = new BuyerService(_context);
            _isEditMode = false;
            _buyerId = null;

            this.Load += InputBuyer_Load;
        }

        // Constructor untuk mode Edit (dengan buyerId)
        public InputBuyer(AppDbContext context, int buyerId)
        {
            InitializeComponent();
            _context = context;
            _buyerService = new BuyerService(_context);
            _isEditMode = true;
            _buyerId = buyerId;

            this.Load += InputBuyer_Load;
        }

        private async void InputBuyer_Load(object sender, EventArgs e)
        {
            textBoxNamaBuyer.PlaceholderText = "John Doe?";
            textBoxNoTelp.PlaceholderText = "08xxxxxxxxxx";
            textBoxEmailBuyer.PlaceholderText = "john@gmail.com";
            textBoxAlamatBuyer.PlaceholderText = "Kota Tangerang";
            textBoxNoRek.PlaceholderText = "112233441122";

            if (_isEditMode && _buyerId.HasValue)
            {
                this.Text = "Edit Buyer";
                await LoadBuyerData(_buyerId.Value);
            }
            else
            {
                this.Text = "Tambah Buyer";
            }
        }

        // Load data buyer untuk mode edit
        private async Task LoadBuyerData(int buyerId)
        {
            try
            {
                var buyer = await _buyerService.GetBuyer(buyerId);

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
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // Event handler untuk tombol Save
        private async void buttonAddBuyer_Click(object sender, EventArgs e)
        {
            // Validasi input
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                if (_isEditMode && _buyerId.HasValue)
                {
                    await UpdateBuyer();
                }
                else
                {
                    await AddNewBuyer();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tambah buyer baru menggunakan BuyerService
        private async Task AddNewBuyer()
        {
            try
            {
                // Validasi email duplikat
                bool emailExists = await _buyerService.EmailExists(textBoxEmailBuyer.Text.Trim());
                if (emailExists)
                {
                    MessageBox.Show("Email sudah digunakan oleh buyer lain!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw new Exception("Email duplikat");
                }

                var newBuyer = new Buyer
                {
                    Nama_Buyer = textBoxNamaBuyer.Text.Trim(),
                    No_Telp = textBoxNoTelp.Text.Trim(),
                    Email = textBoxEmailBuyer.Text.Trim(),
                    Alamat = textBoxAlamatBuyer.Text.Trim(),
                    No_Rek = textBoxNoRek.Text.Trim(),
                    Created_At = DateTime.Now
                };

                await _buyerService.AddBuyer(newBuyer);

                MessageBox.Show("Data buyer berhasil ditambahkan!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal menambahkan buyer: {ex.Message}", ex);
            }
        }

        // Update buyer menggunakan BuyerService
        private async Task UpdateBuyer()
        {
            try
            {
                // Validasi email duplikat (kecuali email sendiri)
                bool emailExists = await _buyerService.EmailExists(
                    textBoxEmailBuyer.Text.Trim(),
                    _buyerId.Value);

                if (emailExists)
                {
                    MessageBox.Show("Email sudah digunakan oleh buyer lain!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw new Exception("Email duplikat");
                }

                var buyer = await _buyerService.GetBuyer(_buyerId.Value);

                if (buyer != null)
                {
                    buyer.Nama_Buyer = textBoxNamaBuyer.Text.Trim();
                    buyer.No_Telp = textBoxNoTelp.Text.Trim();
                    buyer.Email = textBoxEmailBuyer.Text.Trim();
                    buyer.Alamat = textBoxAlamatBuyer.Text.Trim();
                    buyer.No_Rek = textBoxNoRek.Text.Trim();

                    await _buyerService.UpdateBuyer(buyer);

                    MessageBox.Show("Data buyer berhasil diupdate!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new Exception("Data buyer tidak ditemukan");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal mengupdate buyer: {ex.Message}", ex);
            }
        }

        // Validasi input form
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

            // Validasi hanya angka
            if (!textBoxNoTelp.Text.All(char.IsDigit) || textBoxNoTelp.Text.Contains("+"))
            {
                MessageBox.Show("No. Telp hanya boleh berisi angka!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNoTelp.Focus();
                return false;
            }

            // Validasi panjang nomor (minimal 8 digit, maksimal 14 digit)
            if (textBoxNoTelp.Text.Length <= 7 || textBoxNoTelp.Text.Length >= 15)
            {
                MessageBox.Show("No. Telp harus terdiri dari 8 hingga 14 digit!", "Validasi",
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
            if (!IsValidEmail(textBoxEmailBuyer.Text.Trim()))
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

            // Validasi hanya angka
            if (!textBoxNoRek.Text.All(char.IsDigit))
            {
                MessageBox.Show("No. Rekening hanya boleh berisi angka!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNoRek.Focus();
                return false;
            }

            // Validasi panjang (opsional, contoh 10–16 digit)
            if (textBoxNoRek.Text.Length < 10 || textBoxNoRek.Text.Length > 16)
            {
                MessageBox.Show("No. Rekening harus terdiri dari 10 hingga 16 digit!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNoRek.Focus();
                return false;
            }


            return true;
        }

        // Validasi format email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
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

        // Event handler untuk tombol Cancel
        private void buttonDelBuyer_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
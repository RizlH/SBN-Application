using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using SBN_Application.Data;
using SBN_Application.Models;
using SBN_Application.Services;

namespace SBN_Application.Forms.InputForms
{
    public partial class InputSBN : Form
    {
        private readonly AppDbContext _context;
        private readonly SBNService _sbnService;
        private int? _sbnId;
        private bool _isEditMode;

        // Constructor untuk mode Add (tanpa sbnId)
        public InputSBN(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
            _sbnService = new SBNService(_context);
            _isEditMode = false;
            _sbnId = null;

            this.Load += InputSBN_Load;
        }

        // Constructor untuk mode Edit (dengan sbnId)
        public InputSBN(AppDbContext context, int sbnId)
        {
            InitializeComponent();
            _context = context;
            _sbnService = new SBNService(_context);
            _isEditMode = true;
            _sbnId = sbnId;

            this.Load += InputSBN_Load;
        }

        private async void InputSBN_Load(object sender, EventArgs e)
        {
            textBoxNamaSBN.PlaceholderText = "Surat Utang Konoha?";
            textBoxKodeSBN.PlaceholderText = "SUK000?";
            textBoxDesSBN.PlaceholderText = "Sukuk seri ke-?";
            textBoxMinSBN.PlaceholderText = "1000000?";
            textBoxFixSBN.PlaceholderText = "6,5?";
            if (_isEditMode && _sbnId.HasValue)
            {
                this.Text = "Edit SBN";
                await LoadSBNData(_sbnId.Value);
            }
            else
            {
                this.Text = "Tambah SBN";
            }
        }

        // Load data SBN untuk mode edit
        private async Task LoadSBNData(int sbnId)
        {
            try
            {
                var sbn = await _sbnService.GetSBN(sbnId);

                if (sbn != null)
                {
                    textBoxNamaSBN.Text = sbn.Nama_Sbn;
                    textBoxKodeSBN.Text = sbn.Kode_Sbn;
                    textBoxDesSBN.Text = sbn.Deskripsi;
                    comboBoxTipeSBN.Text = sbn.Tipe_Investor;
                    textBoxMinSBN.Text = sbn.Min_Beli.ToString();
                    textBoxFixSBN.Text = sbn.Fixed_Rate.ToString("F2");
                }
                else
                {
                    MessageBox.Show("Data SBN tidak ditemukan!", "Error",
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
        private async void buttonAddSBN_Click(object sender, EventArgs e)
        {
            // Validasi input
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                if (_isEditMode && _sbnId.HasValue)
                {
                    await UpdateSBN();
                }
                else
                {
                    await AddNewSBN();
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

        // Tambah SBN baru menggunakan SBNService
        private async Task AddNewSBN()
        {
            try
            {
                // Validasi kode duplikat
                bool kodeExists = await _sbnService.KodeExists(textBoxKodeSBN.Text.Trim());
                if (kodeExists)
                {
                    MessageBox.Show("Kode SBN sudah digunakan!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw new Exception("Kode duplikat");
                }

                var newSBN = new SBN
                {
                    Nama_Sbn = textBoxNamaSBN.Text.Trim(),
                    Kode_Sbn = textBoxKodeSBN.Text.Trim(),
                    Deskripsi = textBoxDesSBN.Text.Trim(),
                    Tipe_Investor = comboBoxTipeSBN.Text.Trim(),
                    Min_Beli = int.Parse(textBoxMinSBN.Text.Trim()),
                    Fixed_Rate = double.Parse(textBoxFixSBN.Text.Trim()),
                    Created_At = DateTime.UtcNow
                };

                await _sbnService.AddSBN(newSBN);

                MessageBox.Show("Data SBN berhasil ditambahkan!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Gagal menambahkan data SBN!\n\n{inner}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Update SBN menggunakan SBNService
        private async Task UpdateSBN()
        {
            try
            {
                // Validasi kode duplikat (kecuali kode sendiri)
                bool kodeExists = await _sbnService.KodeExists(
                    textBoxKodeSBN.Text.Trim(),
                    _sbnId.Value);

                if (kodeExists)
                {
                    MessageBox.Show("Kode SBN sudah digunakan oleh SBN lain!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw new Exception("Kode duplikat");
                }

                var sbn = await _sbnService.GetSBN(_sbnId.Value);

                if (sbn != null)
                {
                    sbn.Nama_Sbn = textBoxNamaSBN.Text.Trim();
                    sbn.Kode_Sbn = textBoxKodeSBN.Text.Trim();
                    sbn.Deskripsi = textBoxDesSBN.Text.Trim();
                    sbn.Tipe_Investor = comboBoxTipeSBN.Text.Trim();
                    sbn.Min_Beli = int.Parse(textBoxMinSBN.Text.Trim());
                    sbn.Fixed_Rate = double.Parse(textBoxFixSBN.Text.Trim());

                    await _sbnService.UpdateSBN(sbn);

                    MessageBox.Show("Data SBN berhasil diupdate!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new Exception("Data SBN tidak ditemukan");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal mengupdate SBN: {ex.Message}", ex);
            }
        }

        // Validasi input form
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxNamaSBN.Text))
            {
                MessageBox.Show("Nama SBN harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNamaSBN.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxKodeSBN.Text))
            {
                MessageBox.Show("Kode SBN harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxKodeSBN.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBoxTipeSBN.Text))
            {
                MessageBox.Show("Tipe Investor harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxTipeSBN.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxMinSBN.Text) ||
                !int.TryParse(textBoxMinSBN.Text.Trim(), out int minBeli) || minBeli <= 0)
            {
                MessageBox.Show("Minimal Pembelian harus diisi dengan angka yang valid!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMinSBN.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxFixSBN.Text) ||
                !double.TryParse(textBoxFixSBN.Text.Trim(), out double fixedRate) || fixedRate < 0)
            {
                MessageBox.Show("Fixed Rate harus diisi dengan angka yang valid!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxFixSBN.Focus();
                return false;
            }

            return true;
        }

        // Clear semua textbox
        private void ClearForm()
        {
            textBoxNamaSBN.Clear();
            textBoxKodeSBN.Clear();
            textBoxDesSBN.Clear();
            comboBoxTipeSBN.SelectedIndex = -1;
            textBoxMinSBN.Clear();
            textBoxFixSBN.Clear();
            textBoxNamaSBN.Focus();
        }

        // Event handler untuk tombol Clear/Cancel
        private void buttonDelSBN_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // Validasi input hanya angka untuk Min Beli
        private void textBoxMinSBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Validasi input angka desimal untuk Fixed Rate
        private void textBoxFixSBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Hanya satu titik/koma desimal yang diperbolehkan
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (textBox.Text.Contains('.') || textBox.Text.Contains(',')))
            {
                e.Handled = true;
            }
        }
    }
}
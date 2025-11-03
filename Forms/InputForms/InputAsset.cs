using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using SBN_Application.Data;
using SBN_Application.Models;
using SBN_Application.Services;
using Microsoft.EntityFrameworkCore;

namespace SBN_Application.Forms.InputForms
{
    public partial class InputAsset : Form
    {
        private readonly AppDbContext _context;
        private readonly AssetService _assetService;
        private readonly BuyerService _buyerService;
        private readonly SBNService _sbnService;
        private int? _assetId;
        private bool _isEditMode;

        // Constructor untuk mode Add (tanpa assetId)
        public InputAsset(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
            _assetService = new AssetService(_context);
            _buyerService = new BuyerService(_context);
            _sbnService = new SBNService(_context);
            _isEditMode = false;
            _assetId = null;

            this.Load += InputAsset_Load;
        }

        // Constructor untuk mode Edit (dengan assetId)
        public InputAsset(AppDbContext context, int assetId)
        {
            InitializeComponent();
            _context = context;
            _assetService = new AssetService(_context);
            _buyerService = new BuyerService(_context);
            _sbnService = new SBNService(_context);
            _isEditMode = true;
            _assetId = assetId;

            this.Load += InputAsset_Load;
        }

        private async void InputAsset_Load(object sender, EventArgs e)
        {
            await LoadBuyersToComboBox();
            await LoadSBNsToComboBox();

            textBoxModal.PlaceholderText = "1000000?";

            // Wire up event handlers
            comboBoxBuyer.SelectedIndexChanged += ComboBoxBuyer_SelectedIndexChanged;
            comboBoxSBN.SelectedIndexChanged += ComboBoxSBN_SelectedIndexChanged;
            buttonAddAsset.Click += ButtonAddAsset_Click;

            if (_isEditMode && _assetId.HasValue)
            {
                this.Text = "Edit Asset";
                await LoadAssetData(_assetId.Value);
            }
            else
            {
                this.Text = "Tambah Asset";
                textBoxDetailBuyer.ReadOnly = true;
                textBoxDetailSBN.ReadOnly = true;
            }
        }

        // Load buyers ke ComboBox
        private async Task LoadBuyersToComboBox()
        {
            try
            {
                var buyers = await _buyerService.GetAllBuyers();
                comboBoxBuyer.DataSource = buyers;
                comboBoxBuyer.DisplayMember = "Nama_Buyer";
                comboBoxBuyer.ValueMember = "Id_Buyer";
                comboBoxBuyer.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading buyers: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load SBNs ke ComboBox
        private async Task LoadSBNsToComboBox()
        {
            try
            {
                var sbns = await _sbnService.GetAllSBN();
                comboBoxSBN.DataSource = sbns;
                comboBoxSBN.DisplayMember = "Nama_Sbn";
                comboBoxSBN.ValueMember = "Id_Sbn";
                comboBoxSBN.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading SBNs: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler ketika buyer dipilih
        private void ComboBoxBuyer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBuyer.SelectedIndex >= 0)
            {
                var selectedBuyer = comboBoxBuyer.SelectedItem as Buyer;
                if (selectedBuyer != null)
                {
                    textBoxDetailBuyer.Text = $"Nama: {selectedBuyer.Nama_Buyer}\r\n" +
                                             $"No. Telp: {selectedBuyer.No_Telp}\r\n" +
                                             $"Email: {selectedBuyer.Email}\r\n" +
                                             $"Alamat: {selectedBuyer.Alamat}\r\n" +
                                             $"No. Rek: {selectedBuyer.No_Rek}";
                }
            }
            else
            {
                textBoxDetailBuyer.Clear();
            }
        }

        // Event handler ketika SBN dipilih
        private void ComboBoxSBN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSBN.SelectedIndex >= 0)
            {
                var selectedSBN = comboBoxSBN.SelectedItem as SBN;
                if (selectedSBN != null)
                {
                    textBoxDetailSBN.Text = $"Nama: {selectedSBN.Nama_Sbn}\r\n" +
                                           $"Kode: {selectedSBN.Kode_Sbn}\r\n" +
                                           $"Tipe Investor: {selectedSBN.Tipe_Investor}\r\n" +
                                           $"Min. Beli: Rp {selectedSBN.Min_Beli:N0}\r\n" +
                                           $"Fixed Rate: {selectedSBN.Fixed_Rate:N1}%";
                }
            }
            else
            {
                textBoxDetailSBN.Clear();
            }
        }

        // Load data asset untuk mode edit
        private async Task LoadAssetData(int assetId)
        {
            try
            {
                var asset = await _assetService.GetAsset(assetId);

                if (asset != null)
                {
                    comboBoxBuyer.SelectedValue = asset.Id_Buyer;
                    comboBoxSBN.SelectedValue = asset.Id_Sbn;
                    textBoxModal.Text = asset.Modal.ToString();

                    // Set tenor (konversi bulan ke tahun)
                    int tenorTahun = asset.Tenor / 12;
                    comboBoxTenor.SelectedIndex = tenorTahun - 1;
                }
                else
                {
                    MessageBox.Show("Data asset tidak ditemukan!", "Error",
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
        private async void ButtonAddAsset_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                if (_isEditMode && _assetId.HasValue)
                {
                    await UpdateAsset();
                }
                else
                {
                    await AddNewAsset();
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

        // Tambah asset baru
        private async Task AddNewAsset()
        {
            try
            {
                int buyerId = (int)comboBoxBuyer.SelectedValue;
                int sbnId = (int)comboBoxSBN.SelectedValue;
                int modal = int.Parse(textBoxModal.Text.Trim());

                // Konversi tenor dari tahun ke bulan
                string tenorText = comboBoxTenor.Text;
                int tenorTahun = int.Parse(tenorText.Split(' ')[0]);
                int tenorBulan = tenorTahun * 12;

                var newAsset = new Asset
                {
                    Id_Buyer = buyerId,
                    Id_Sbn = sbnId,
                    Modal = modal,
                    Tenor = tenorBulan,
                    Created_At = DateTime.Now
                };

                await _assetService.AddAsset(newAsset);

                MessageBox.Show($"Data asset berhasil ditambahkan!\n\n" +
                               $"Total yang akan diterima: Rp {newAsset.Total_Diterima:N2}",
                               "Sukses",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal menambahkan asset: {ex.Message}", ex);
            }
        }

        // Update asset
        // Di InputAsset.cs
        private async Task UpdateAsset()
        {
            int buyerId = (int)comboBoxBuyer.SelectedValue;
            int sbnId = (int)comboBoxSBN.SelectedValue;
            int modal = int.Parse(textBoxModal.Text.Trim());
            int tenorTahun = int.Parse(comboBoxTenor.Text.Split(' ')[0]);
            int tenorBulan = tenorTahun * 12;

            await _assetService.UpdateAsset(_assetId.Value, buyerId, sbnId, modal, tenorBulan);
            MessageBox.Show("Data buyer berhasil diupdate!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        // Validasi input form
        private bool ValidateInput()
        {
            if (comboBoxBuyer.SelectedIndex < 0)
            {
                MessageBox.Show("Pilih buyer terlebih dahulu!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxBuyer.Focus();
                return false;
            }

            if (comboBoxSBN.SelectedIndex < 0)
            {
                MessageBox.Show("Pilih SBN terlebih dahulu!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxSBN.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxModal.Text))
            {
                MessageBox.Show("Modal harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxModal.Focus();
                return false;
            }

            if (!int.TryParse(textBoxModal.Text.Trim(), out int modal) || modal <= 0)
            {
                MessageBox.Show("Modal harus berupa angka positif!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxModal.Focus();
                return false;
            }

            // Validasi minimal pembelian
            var selectedSBN = comboBoxSBN.SelectedItem as SBN;
            if (selectedSBN != null && modal < selectedSBN.Min_Beli)
            {
                MessageBox.Show($"Modal minimal untuk SBN ini adalah Rp {selectedSBN.Min_Beli:N0}!",
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                textBoxModal.Focus();
                return false;
            }

            if (comboBoxTenor.SelectedIndex < 0)
            {
                MessageBox.Show("Pilih tenor terlebih dahulu!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxTenor.Focus();
                return false;
            }

            return true;
        }

        // Validasi input hanya angka untuk Modal
        private void textBoxModal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
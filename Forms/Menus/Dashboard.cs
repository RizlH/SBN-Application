using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SBN_Application.Data;
using SBN_Application.Services;

namespace SBN_Application.Forms.Menus
{
    public partial class Dashboard : UserControl
    {
        private AppDbContext _context;


        public Dashboard()
        {
            InitializeComponent();
            _context = new AppDbContext();

            // Load data saat dashboard dimuat
            this.Load += Dashboard_Load;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                // Hitung jumlah Buyer
                int buyerCount = 0;
                try
                {
                    buyerCount = _context.Buyers.Count();
                }
                catch
                {
                    buyerCount = 0;
                }
                label4.Text = buyerCount.ToString();

                // Hitung jumlah SBN menggunakan SBNService
                int sbnCount = 0;
                try
                {
                    sbnCount = _context.SBNs.Count();
                }
                catch
                {
                    sbnCount = 0;
                }
                label5.Text = sbnCount.ToString();

                // Hitung jumlah Asset
                int assetCount = 0;
                try
                {
                    assetCount = _context.Assets.Count();
                }
                catch
                {
                    assetCount = 0;
                }
                label7.Text = assetCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat data dashboard: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Set default values jika error
                label4.Text = "0";
                label5.Text = "0";
                label7.Text = "0";
            }
        }

        // Method public untuk refresh data dari luar (dipanggil setelah CRUD)
        public void RefreshDashboard()
        {
            LoadDashboardData();
        }
    }
}
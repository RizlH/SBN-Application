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

namespace SBN_Application.Forms.Menus
{
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();

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
                using (var context = new AppDbContext())
                {
                    // Hitung jumlah Buyer
                    int buyerCount = context.Buyers.Count();
                    label4.Text = buyerCount.ToString();

                    // Hitung jumlah SBN (jika sudah ada tabel SBN)
                    try
                    {
                        int sbnCount = context.SBNs.Count();
                        label5.Text = sbnCount.ToString();
                    }
                    catch
                    {
                        label5.Text = "0";
                    }

                    // Hitung jumlah Asset (jika sudah ada tabel Asset)
                    try
                    {
                        int assetCount = context.Assets.Count();
                        label7.Text = assetCount.ToString();
                    }
                    catch
                    {
                        label7.Text = "0";
                    }
                }
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

        // Method public untuk refresh data dari luar (jika diperlukan)
        public void RefreshDashboard()
        {
            LoadDashboardData();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBN_Application.Forms
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void ShowPage(UserControl page)
        {
            panelContainer.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(page);
            page.BringToFront();
        }


        private void buyerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPage(new Menus.BuyerPage());
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPage(new Menus.Dashboard());
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            ShowPage(new Menus.Dashboard());
        }

        private void sbnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPage(new Menus.SBNPage());
        }

        private void assetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPage(new Menus.AssetPage());
        }
    }
}

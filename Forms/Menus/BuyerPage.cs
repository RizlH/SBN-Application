using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SBN_Application.Forms.InputForms;

namespace SBN_Application.Forms.Menus
{
    public partial class BuyerPage : UserControl
    {
        public BuyerPage()
        {
            InitializeComponent();
        }

        private void buttoninputbuyer_Click(object sender, EventArgs e)
        {
            InputBuyer inputbuyer = new InputBuyer();
            inputbuyer.ShowDialog();
        }
    }
}

namespace SBN_Application.Forms
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            homeToolStripMenuItem = new ToolStripMenuItem();
            buyerToolStripMenuItem = new ToolStripMenuItem();
            sbnToolStripMenuItem = new ToolStripMenuItem();
            assetToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveBorder;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, buyerToolStripMenuItem, sbnToolStripMenuItem, assetToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(878, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.BackColor = Color.White;
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(77, 29);
            homeToolStripMenuItem.Text = "Home";
            // 
            // buyerToolStripMenuItem
            // 
            buyerToolStripMenuItem.BackColor = Color.White;
            buyerToolStripMenuItem.Name = "buyerToolStripMenuItem";
            buyerToolStripMenuItem.Size = new Size(72, 29);
            buyerToolStripMenuItem.Text = "Buyer";
            // 
            // sbnToolStripMenuItem
            // 
            sbnToolStripMenuItem.BackColor = Color.White;
            sbnToolStripMenuItem.Name = "sbnToolStripMenuItem";
            sbnToolStripMenuItem.Size = new Size(61, 29);
            sbnToolStripMenuItem.Text = "SBN";
            // 
            // assetToolStripMenuItem
            // 
            assetToolStripMenuItem.BackColor = Color.White;
            assetToolStripMenuItem.Name = "assetToolStripMenuItem";
            assetToolStripMenuItem.Size = new Size(71, 29);
            assetToolStripMenuItem.Text = "Asset";
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 544);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "HomeForm";
            Text = "HomeForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem buyerToolStripMenuItem;
        private ToolStripMenuItem sbnToolStripMenuItem;
        private ToolStripMenuItem assetToolStripMenuItem;
    }
}
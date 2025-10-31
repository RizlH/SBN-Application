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
            panelContainer = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(113, 201, 206);
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, buyerToolStripMenuItem, sbnToolStripMenuItem, assetToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(978, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.BackColor = Color.White;
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(77, 29);
            homeToolStripMenuItem.Text = "Home";
            homeToolStripMenuItem.Click += homeToolStripMenuItem_Click;
            // 
            // buyerToolStripMenuItem
            // 
            buyerToolStripMenuItem.BackColor = Color.White;
            buyerToolStripMenuItem.Name = "buyerToolStripMenuItem";
            buyerToolStripMenuItem.Size = new Size(72, 29);
            buyerToolStripMenuItem.Text = "Buyer";
            buyerToolStripMenuItem.Click += buyerToolStripMenuItem_Click;
            // 
            // sbnToolStripMenuItem
            // 
            sbnToolStripMenuItem.BackColor = Color.White;
            sbnToolStripMenuItem.Name = "sbnToolStripMenuItem";
            sbnToolStripMenuItem.Size = new Size(61, 29);
            sbnToolStripMenuItem.Text = "SBN";
            sbnToolStripMenuItem.Click += sbnToolStripMenuItem_Click;
            // 
            // assetToolStripMenuItem
            // 
            assetToolStripMenuItem.BackColor = Color.White;
            assetToolStripMenuItem.Name = "assetToolStripMenuItem";
            assetToolStripMenuItem.Size = new Size(71, 29);
            assetToolStripMenuItem.Text = "Asset";
            assetToolStripMenuItem.Click += assetToolStripMenuItem_Click;
            // 
            // panelContainer
            // 
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 33);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(978, 511);
            panelContainer.TabIndex = 12;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(227, 253, 253);
            ClientSize = new Size(978, 544);
            Controls.Add(panelContainer);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "HomeForm";
            Text = "HomeForm";
            Load += HomeForm_Load;
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
        private Panel panelContainer;
    }
}
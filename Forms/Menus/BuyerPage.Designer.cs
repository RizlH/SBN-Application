namespace SBN_Application.Forms.Menus
{
    public partial class BuyerPage : UserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttoninputbuyer = new Button();
            buttondeletebuyer = new Button();
            dataGridViewbuyer = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewbuyer).BeginInit();
            SuspendLayout();
            // 
            // buttoninputbuyer
            // 
            buttoninputbuyer.Location = new Point(808, 38);
            buttoninputbuyer.Margin = new Padding(4);
            buttoninputbuyer.Name = "buttoninputbuyer";
            buttoninputbuyer.Size = new Size(118, 36);
            buttoninputbuyer.TabIndex = 7;
            buttoninputbuyer.Text = "Input";
            buttoninputbuyer.UseVisualStyleBackColor = true;
            buttoninputbuyer.Click += buttoninputbuyer_Click;
            // 
            // buttondeletebuyer
            // 
            buttondeletebuyer.Location = new Point(652, 38);
            buttondeletebuyer.Margin = new Padding(4);
            buttondeletebuyer.Name = "buttondeletebuyer";
            buttondeletebuyer.Size = new Size(118, 36);
            buttondeletebuyer.TabIndex = 6;
            buttondeletebuyer.Text = "Delete";
            buttondeletebuyer.UseVisualStyleBackColor = true;
            // 
            // dataGridViewbuyer
            // 
            dataGridViewbuyer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewbuyer.Location = new Point(54, 96);
            dataGridViewbuyer.Margin = new Padding(4);
            dataGridViewbuyer.Name = "dataGridViewbuyer";
            dataGridViewbuyer.RowHeadersWidth = 51;
            dataGridViewbuyer.Size = new Size(872, 378);
            dataGridViewbuyer.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 44);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(99, 25);
            label1.TabIndex = 4;
            label1.Text = "Buyer Page";
            // 
            // BuyerPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(227, 253, 253);
            Controls.Add(buttoninputbuyer);
            Controls.Add(buttondeletebuyer);
            Controls.Add(dataGridViewbuyer);
            Controls.Add(label1);
            Name = "BuyerPage";
            Size = new Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)dataGridViewbuyer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttoninputbuyer;
        private Button buttondeletebuyer;
        private DataGridView dataGridViewbuyer;
        private Label label1;
    }
}

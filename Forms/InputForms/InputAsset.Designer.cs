namespace SBN_Application.Forms.InputForms
{
    partial class InputAsset
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBoxBuyer = new ComboBox();
            comboBoxSBN = new ComboBox();
            textBoxModal = new TextBox();
            buttonAddAsset = new Button();
            textBoxDetailBuyer = new TextBox();
            textBoxDetailSBN = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            comboBoxTenor = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 48);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(56, 25);
            label1.TabIndex = 0;
            label1.Text = "Buyer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 202);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(45, 25);
            label2.TabIndex = 1;
            label2.Text = "SBN";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(58, 362);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(63, 25);
            label3.TabIndex = 2;
            label3.Text = "Modal";
            // 
            // comboBoxBuyer
            // 
            comboBoxBuyer.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBuyer.FormattingEnabled = true;
            comboBoxBuyer.Location = new Point(142, 48);
            comboBoxBuyer.Margin = new Padding(4);
            comboBoxBuyer.Name = "comboBoxBuyer";
            comboBoxBuyer.Size = new Size(250, 33);
            comboBoxBuyer.TabIndex = 3;
            // 
            // comboBoxSBN
            // 
            comboBoxSBN.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSBN.FormattingEnabled = true;
            comboBoxSBN.Location = new Point(142, 199);
            comboBoxSBN.Margin = new Padding(4);
            comboBoxSBN.Name = "comboBoxSBN";
            comboBoxSBN.Size = new Size(250, 33);
            comboBoxSBN.TabIndex = 4;
            // 
            // textBoxModal
            // 
            textBoxModal.Location = new Point(142, 359);
            textBoxModal.Margin = new Padding(4);
            textBoxModal.Name = "textBoxModal";
            textBoxModal.Size = new Size(250, 31);
            textBoxModal.TabIndex = 5;
            textBoxModal.KeyPress += textBoxModal_KeyPress;
            // 
            // buttonAddAsset
            // 
            buttonAddAsset.Location = new Point(446, 447);
            buttonAddAsset.Margin = new Padding(4);
            buttonAddAsset.Name = "buttonAddAsset";
            buttonAddAsset.Size = new Size(118, 36);
            buttonAddAsset.TabIndex = 6;
            buttonAddAsset.Text = "Tambah";
            buttonAddAsset.UseVisualStyleBackColor = true;
            // 
            // textBoxDetailBuyer
            // 
            textBoxDetailBuyer.BackColor = SystemColors.Window;
            textBoxDetailBuyer.Location = new Point(411, 48);
            textBoxDetailBuyer.Margin = new Padding(4);
            textBoxDetailBuyer.Multiline = true;
            textBoxDetailBuyer.Name = "textBoxDetailBuyer";
            textBoxDetailBuyer.ReadOnly = true;
            textBoxDetailBuyer.Size = new Size(384, 135);
            textBoxDetailBuyer.TabIndex = 7;
            // 
            // textBoxDetailSBN
            // 
            textBoxDetailSBN.BackColor = SystemColors.Window;
            textBoxDetailSBN.Location = new Point(411, 202);
            textBoxDetailSBN.Margin = new Padding(4);
            textBoxDetailSBN.Multiline = true;
            textBoxDetailSBN.Name = "textBoxDetailSBN";
            textBoxDetailSBN.ReadOnly = true;
            textBoxDetailSBN.Size = new Size(384, 128);
            textBoxDetailSBN.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(282, 85);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(110, 25);
            label4.TabIndex = 9;
            label4.Text = "Detail Buyer:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(293, 236);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(99, 25);
            label5.TabIndex = 10;
            label5.Text = "Detail SBN:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(58, 401);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(55, 25);
            label6.TabIndex = 11;
            label6.Text = "Tenor";
            // 
            // comboBoxTenor
            // 
            comboBoxTenor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTenor.FormattingEnabled = true;
            comboBoxTenor.Items.AddRange(new object[] { "1 Tahun", "2 Tahun", "3 Tahun", "4 Tahun", "5 Tahun", "6 Tahun" });
            comboBoxTenor.Location = new Point(142, 401);
            comboBoxTenor.Margin = new Padding(4);
            comboBoxTenor.Name = "comboBoxTenor";
            comboBoxTenor.Size = new Size(250, 33);
            comboBoxTenor.TabIndex = 12;
            // 
            // InputAsset
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 514);
            Controls.Add(comboBoxTenor);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBoxDetailSBN);
            Controls.Add(textBoxDetailBuyer);
            Controls.Add(buttonAddAsset);
            Controls.Add(textBoxModal);
            Controls.Add(comboBoxSBN);
            Controls.Add(comboBoxBuyer);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4);
            Name = "InputAsset";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Input Data Asset";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBoxBuyer;
        private ComboBox comboBoxSBN;
        private TextBox textBoxModal;
        private Button buttonAddAsset;
        private TextBox textBoxDetailBuyer;
        private TextBox textBoxDetailSBN;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox comboBoxTenor;
    }
}
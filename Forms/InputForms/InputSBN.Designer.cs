namespace SBN_Application.Forms.InputForms
{
    partial class InputSBN
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
            textBoxNamaSBN = new TextBox();
            textBoxKodeSBN = new TextBox();
            textBoxDesSBN = new TextBox();
            label4 = new Label();
            textBoxTipeSBN = new TextBox();
            label5 = new Label();
            textBoxMinSBN = new TextBox();
            buttonAddSBN = new Button();
            label6 = new Label();
            textBoxFixSBN = new TextBox();
            buttonDelSBN = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 42);
            label1.Name = "label1";
            label1.Size = new Size(97, 25);
            label1.TabIndex = 0;
            label1.Text = "Nama SBN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 113);
            label2.Name = "label2";
            label2.Size = new Size(91, 25);
            label2.TabIndex = 1;
            label2.Text = "Kode SBN";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 397);
            label3.Name = "label3";
            label3.Size = new Size(104, 25);
            label3.TabIndex = 2;
            label3.Text = "Fixed Rated";
            // 
            // textBoxNamaSBN
            // 
            textBoxNamaSBN.Location = new Point(269, 36);
            textBoxNamaSBN.Name = "textBoxNamaSBN";
            textBoxNamaSBN.Size = new Size(232, 31);
            textBoxNamaSBN.TabIndex = 3;
            // 
            // textBoxKodeSBN
            // 
            textBoxKodeSBN.Location = new Point(269, 107);
            textBoxKodeSBN.Name = "textBoxKodeSBN";
            textBoxKodeSBN.Size = new Size(232, 31);
            textBoxKodeSBN.TabIndex = 4;
            // 
            // textBoxDesSBN
            // 
            textBoxDesSBN.Location = new Point(269, 176);
            textBoxDesSBN.Name = "textBoxDesSBN";
            textBoxDesSBN.Size = new Size(232, 31);
            textBoxDesSBN.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 182);
            label4.Name = "label4";
            label4.Size = new Size(84, 25);
            label4.TabIndex = 6;
            label4.Text = "Deskripsi";
            // 
            // textBoxTipeSBN
            // 
            textBoxTipeSBN.Location = new Point(269, 248);
            textBoxTipeSBN.Name = "textBoxTipeSBN";
            textBoxTipeSBN.Size = new Size(232, 31);
            textBoxTipeSBN.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(45, 329);
            label5.Name = "label5";
            label5.Size = new Size(161, 25);
            label5.TabIndex = 8;
            label5.Text = "Minimal Pembelian";
            // 
            // textBoxMinSBN
            // 
            textBoxMinSBN.Location = new Point(269, 323);
            textBoxMinSBN.Name = "textBoxMinSBN";
            textBoxMinSBN.Size = new Size(232, 31);
            textBoxMinSBN.TabIndex = 9;
            // 
            // buttonAddSBN
            // 
            buttonAddSBN.Location = new Point(269, 450);
            buttonAddSBN.Name = "buttonAddSBN";
            buttonAddSBN.Size = new Size(112, 34);
            buttonAddSBN.TabIndex = 10;
            buttonAddSBN.Text = "Tambah";
            buttonAddSBN.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(45, 251);
            label6.Name = "label6";
            label6.Size = new Size(114, 25);
            label6.TabIndex = 11;
            label6.Text = "Tipe Investor";
            // 
            // textBoxFixSBN
            // 
            textBoxFixSBN.Location = new Point(269, 391);
            textBoxFixSBN.Name = "textBoxFixSBN";
            textBoxFixSBN.Size = new Size(232, 31);
            textBoxFixSBN.TabIndex = 12;
            // 
            // buttonDelSBN
            // 
            buttonDelSBN.Location = new Point(389, 450);
            buttonDelSBN.Name = "buttonDelSBN";
            buttonDelSBN.Size = new Size(112, 34);
            buttonDelSBN.TabIndex = 13;
            buttonDelSBN.Text = "Hapus";
            buttonDelSBN.UseVisualStyleBackColor = true;
            // 
            // InputSBN
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 514);
            Controls.Add(buttonDelSBN);
            Controls.Add(textBoxFixSBN);
            Controls.Add(label6);
            Controls.Add(buttonAddSBN);
            Controls.Add(textBoxMinSBN);
            Controls.Add(label5);
            Controls.Add(textBoxTipeSBN);
            Controls.Add(label4);
            Controls.Add(textBoxDesSBN);
            Controls.Add(textBoxKodeSBN);
            Controls.Add(textBoxNamaSBN);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "InputSBN";
            Text = "Input Data SBN";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxNamaSBN;
        private TextBox textBoxKodeSBN;
        private TextBox textBoxDesSBN;
        private Label label4;
        private TextBox textBoxTipeSBN;
        private Label label5;
        private TextBox textBoxMinSBN;
        private Button buttonAddSBN;
        private Label label6;
        private TextBox textBoxFixSBN;
        private Button buttonDelSBN;
    }
}
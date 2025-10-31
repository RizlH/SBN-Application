namespace SBN_Application.Forms.InputForms
{
    partial class InputBuyer
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
            buttonDelSBN = new Button();
            label6 = new Label();
            buttonAddSBN = new Button();
            textBoxMinSBN = new TextBox();
            label5 = new Label();
            textBoxTipeSBN = new TextBox();
            label4 = new Label();
            textBoxDesSBN = new TextBox();
            textBoxKodeSBN = new TextBox();
            textBoxNamaSBN = new TextBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonDelSBN
            // 
            buttonDelSBN.Location = new Point(405, 410);
            buttonDelSBN.Name = "buttonDelSBN";
            buttonDelSBN.Size = new Size(112, 34);
            buttonDelSBN.TabIndex = 27;
            buttonDelSBN.Text = "Hapus";
            buttonDelSBN.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(61, 248);
            label6.Name = "label6";
            label6.Size = new Size(68, 25);
            label6.TabIndex = 25;
            label6.Text = "Alamat";
            // 
            // buttonAddSBN
            // 
            buttonAddSBN.Location = new Point(285, 410);
            buttonAddSBN.Name = "buttonAddSBN";
            buttonAddSBN.Size = new Size(112, 34);
            buttonAddSBN.TabIndex = 24;
            buttonAddSBN.Text = "Tambah";
            buttonAddSBN.UseVisualStyleBackColor = true;
            // 
            // textBoxMinSBN
            // 
            textBoxMinSBN.Location = new Point(285, 320);
            textBoxMinSBN.Name = "textBoxMinSBN";
            textBoxMinSBN.Size = new Size(232, 31);
            textBoxMinSBN.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(61, 326);
            label5.Name = "label5";
            label5.Size = new Size(117, 25);
            label5.TabIndex = 22;
            label5.Text = "No. Rekening";
            // 
            // textBoxTipeSBN
            // 
            textBoxTipeSBN.Location = new Point(285, 245);
            textBoxTipeSBN.Name = "textBoxTipeSBN";
            textBoxTipeSBN.Size = new Size(232, 31);
            textBoxTipeSBN.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(61, 179);
            label4.Name = "label4";
            label4.Size = new Size(54, 25);
            label4.TabIndex = 20;
            label4.Text = "Email";
            // 
            // textBoxDesSBN
            // 
            textBoxDesSBN.Location = new Point(285, 173);
            textBoxDesSBN.Name = "textBoxDesSBN";
            textBoxDesSBN.Size = new Size(232, 31);
            textBoxDesSBN.TabIndex = 19;
            // 
            // textBoxKodeSBN
            // 
            textBoxKodeSBN.Location = new Point(285, 104);
            textBoxKodeSBN.Name = "textBoxKodeSBN";
            textBoxKodeSBN.Size = new Size(232, 31);
            textBoxKodeSBN.TabIndex = 18;
            // 
            // textBoxNamaSBN
            // 
            textBoxNamaSBN.Location = new Point(285, 33);
            textBoxNamaSBN.Name = "textBoxNamaSBN";
            textBoxNamaSBN.Size = new Size(232, 31);
            textBoxNamaSBN.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 110);
            label2.Name = "label2";
            label2.Size = new Size(76, 25);
            label2.TabIndex = 15;
            label2.Text = "No. Telp";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 39);
            label1.Name = "label1";
            label1.Size = new Size(108, 25);
            label1.TabIndex = 14;
            label1.Text = "Nama Buyer";
            // 
            // InputBuyer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 514);
            Controls.Add(buttonDelSBN);
            Controls.Add(label6);
            Controls.Add(buttonAddSBN);
            Controls.Add(textBoxMinSBN);
            Controls.Add(label5);
            Controls.Add(textBoxTipeSBN);
            Controls.Add(label4);
            Controls.Add(textBoxDesSBN);
            Controls.Add(textBoxKodeSBN);
            Controls.Add(textBoxNamaSBN);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "InputBuyer";
            Text = "Input Data Buyer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonDelSBN;
        private Label label6;
        private Button buttonAddSBN;
        private TextBox textBoxMinSBN;
        private Label label5;
        private TextBox textBoxTipeSBN;
        private Label label4;
        private TextBox textBoxDesSBN;
        private TextBox textBoxKodeSBN;
        private TextBox textBoxNamaSBN;
        private Label label2;
        private Label label1;
    }
}
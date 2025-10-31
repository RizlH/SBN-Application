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
            buttonDelBuyer = new Button();
            label6 = new Label();
            buttonAddBuyer = new Button();
            textBoxNoRek = new TextBox();
            label5 = new Label();
            textBoxAlamatBuyer = new TextBox();
            label4 = new Label();
            textBoxEmailBuyer = new TextBox();
            textBoxNoTelp = new TextBox();
            textBoxNamaBuyer = new TextBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonDelBuyer
            // 
            buttonDelBuyer.Location = new Point(405, 410);
            buttonDelBuyer.Name = "buttonDelBuyer";
            buttonDelBuyer.Size = new Size(112, 34);
            buttonDelBuyer.TabIndex = 27;
            buttonDelBuyer.Text = "Hapus";
            buttonDelBuyer.UseVisualStyleBackColor = true;
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
            // buttonAddBuyer
            // 
            buttonAddBuyer.Location = new Point(285, 410);
            buttonAddBuyer.Name = "buttonAddBuyer";
            buttonAddBuyer.Size = new Size(112, 34);
            buttonAddBuyer.TabIndex = 24;
            buttonAddBuyer.Text = "Tambah";
            buttonAddBuyer.UseVisualStyleBackColor = true;
            // 
            // textBoxNoRek
            // 
            textBoxNoRek.Location = new Point(285, 320);
            textBoxNoRek.Name = "textBoxNoRek";
            textBoxNoRek.Size = new Size(232, 31);
            textBoxNoRek.TabIndex = 23;
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
            // textBoxAlamatBuyer
            // 
            textBoxAlamatBuyer.Location = new Point(285, 245);
            textBoxAlamatBuyer.Name = "textBoxAlamatBuyer";
            textBoxAlamatBuyer.Size = new Size(232, 31);
            textBoxAlamatBuyer.TabIndex = 21;
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
            // textBoxEmailBuyer
            // 
            textBoxEmailBuyer.Location = new Point(285, 173);
            textBoxEmailBuyer.Name = "textBoxEmailBuyer";
            textBoxEmailBuyer.Size = new Size(232, 31);
            textBoxEmailBuyer.TabIndex = 19;
            // 
            // textBoxNoTelp
            // 
            textBoxNoTelp.Location = new Point(285, 104);
            textBoxNoTelp.Name = "textBoxNoTelp";
            textBoxNoTelp.Size = new Size(232, 31);
            textBoxNoTelp.TabIndex = 18;
            // 
            // textBoxNamaBuyer
            // 
            textBoxNamaBuyer.Location = new Point(285, 33);
            textBoxNamaBuyer.Name = "textBoxNamaBuyer";
            textBoxNamaBuyer.Size = new Size(232, 31);
            textBoxNamaBuyer.TabIndex = 17;
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
            Controls.Add(buttonDelBuyer);
            Controls.Add(label6);
            Controls.Add(buttonAddBuyer);
            Controls.Add(textBoxNoRek);
            Controls.Add(label5);
            Controls.Add(textBoxAlamatBuyer);
            Controls.Add(label4);
            Controls.Add(textBoxEmailBuyer);
            Controls.Add(textBoxNoTelp);
            Controls.Add(textBoxNamaBuyer);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "InputBuyer";
            Text = "Input Data Buyer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonDelBuyer;
        private Label label6;
        private Button buttonAddBuyer;
        private TextBox textBoxNoRek;
        private Label label5;
        private TextBox textBoxAlamatBuyer;
        private Label label4;
        private TextBox textBoxEmailBuyer;
        private TextBox textBoxNoTelp;
        private TextBox textBoxNamaBuyer;
        private Label label2;
        private Label label1;
    }
}
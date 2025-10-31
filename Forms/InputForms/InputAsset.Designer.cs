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
            comboBoxbuyer = new ComboBox();
            comboBoxsbn = new ComboBox();
            textBoxmodal = new TextBox();
            buttonasset = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label4 = new Label();
            label5 = new Label();
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
            // comboBoxbuyer
            // 
            comboBoxbuyer.FormattingEnabled = true;
            comboBoxbuyer.Location = new Point(142, 48);
            comboBoxbuyer.Margin = new Padding(4);
            comboBoxbuyer.Name = "comboBoxbuyer";
            comboBoxbuyer.Size = new Size(250, 33);
            comboBoxbuyer.TabIndex = 3;
            // 
            // comboBoxsbn
            // 
            comboBoxsbn.FormattingEnabled = true;
            comboBoxsbn.Location = new Point(142, 199);
            comboBoxsbn.Margin = new Padding(4);
            comboBoxsbn.Name = "comboBoxsbn";
            comboBoxsbn.Size = new Size(250, 33);
            comboBoxsbn.TabIndex = 4;
            // 
            // textBoxmodal
            // 
            textBoxmodal.Location = new Point(142, 359);
            textBoxmodal.Margin = new Padding(4);
            textBoxmodal.Name = "textBoxmodal";
            textBoxmodal.Size = new Size(250, 31);
            textBoxmodal.TabIndex = 5;
            // 
            // buttonasset
            // 
            buttonasset.Location = new Point(446, 413);
            buttonasset.Margin = new Padding(4);
            buttonasset.Name = "buttonasset";
            buttonasset.Size = new Size(118, 36);
            buttonasset.TabIndex = 6;
            buttonasset.Text = "Tambah";
            buttonasset.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(446, 79);
            textBox1.Margin = new Padding(4);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(349, 99);
            textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(446, 231);
            textBox2.Margin = new Padding(4);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(349, 99);
            textBox2.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(446, 51);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(110, 25);
            label4.TabIndex = 9;
            label4.Text = "Detail Buyer:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(446, 202);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(99, 25);
            label5.TabIndex = 10;
            label5.Text = "Detail SBN:";
            // 
            // InputAsset
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 514);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(buttonasset);
            Controls.Add(textBoxmodal);
            Controls.Add(comboBoxsbn);
            Controls.Add(comboBoxbuyer);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4);
            Name = "InputAsset";
            Text = "Input Data Asset";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBoxbuyer;
        private ComboBox comboBoxsbn;
        private TextBox textBoxmodal;
        private Button buttonasset;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label4;
        private Label label5;
    }
}
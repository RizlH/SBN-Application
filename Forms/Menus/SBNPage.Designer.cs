namespace SBN_Application.Forms.Menus
{
    partial class SBNPage
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
            label1 = new Label();
            dataGridViewsbn = new DataGridView();
            inputsbnbtn = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewsbn).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 30);
            label1.Name = "label1";
            label1.Size = new Size(102, 25);
            label1.TabIndex = 0;
            label1.Text = "SBN PAGES";
            // 
            // dataGridViewsbn
            // 
            dataGridViewsbn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewsbn.Location = new Point(43, 81);
            dataGridViewsbn.Name = "dataGridViewsbn";
            dataGridViewsbn.RowHeadersWidth = 62;
            dataGridViewsbn.Size = new Size(912, 382);
            dataGridViewsbn.TabIndex = 1;
            // 
            // inputsbnbtn
            // 
            inputsbnbtn.Location = new Point(824, 21);
            inputsbnbtn.Name = "inputsbnbtn";
            inputsbnbtn.Size = new Size(112, 34);
            inputsbnbtn.TabIndex = 2;
            inputsbnbtn.Text = "Input";
            inputsbnbtn.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(669, 21);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 3;
            button1.Text = "Delete";
            button1.UseVisualStyleBackColor = true;
            // 
            // SBNPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(227, 253, 253);
            Controls.Add(button1);
            Controls.Add(inputsbnbtn);
            Controls.Add(dataGridViewsbn);
            Controls.Add(label1);
            Name = "SBNPage";
            Size = new Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)dataGridViewsbn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridViewsbn;
        private Button inputsbnbtn;
        private Button button1;
    }
}

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
            label1.Location = new Point(34, 24);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 0;
            label1.Text = "SBN PAGES";
            // 
            // dataGridViewsbn
            // 
            dataGridViewsbn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewsbn.Location = new Point(34, 65);
            dataGridViewsbn.Margin = new Padding(2, 2, 2, 2);
            dataGridViewsbn.Name = "dataGridViewsbn";
            dataGridViewsbn.RowHeadersWidth = 62;
            dataGridViewsbn.Size = new Size(730, 306);
            dataGridViewsbn.TabIndex = 1;
            // 
            // inputsbnbtn
            // 
            inputsbnbtn.Location = new Point(659, 17);
            inputsbnbtn.Margin = new Padding(2, 2, 2, 2);
            inputsbnbtn.Name = "inputsbnbtn";
            inputsbnbtn.Size = new Size(90, 27);
            inputsbnbtn.TabIndex = 2;
            inputsbnbtn.Text = "Input";
            inputsbnbtn.UseVisualStyleBackColor = true;
            inputsbnbtn.Click += inputsbnbtn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(535, 17);
            button1.Margin = new Padding(2, 2, 2, 2);
            button1.Name = "button1";
            button1.Size = new Size(90, 27);
            button1.TabIndex = 3;
            button1.Text = "Delete";
            button1.UseVisualStyleBackColor = true;
            // 
            // SBNPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(227, 253, 253);
            Controls.Add(button1);
            Controls.Add(inputsbnbtn);
            Controls.Add(dataGridViewsbn);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "SBNPage";
            Size = new Size(800, 400);
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

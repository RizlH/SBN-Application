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
            buttoninputsbn = new Button();
            buttondeletesbn = new Button();
            dataGridViewsbn = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewsbn).BeginInit();
            SuspendLayout();
            // 
            // buttoninputsbn
            // 
            buttoninputsbn.Location = new Point(808, 38);
            buttoninputsbn.Margin = new Padding(4);
            buttoninputsbn.Name = "buttoninputsbn";
            buttoninputsbn.Size = new Size(118, 36);
            buttoninputsbn.TabIndex = 7;
            buttoninputsbn.Text = "Input";
            buttoninputsbn.UseVisualStyleBackColor = true;
            buttoninputsbn.Click += buttoninputsbn_Click;
            // 
            // buttondeletesbn
            // 
            buttondeletesbn.Location = new Point(652, 38);
            buttondeletesbn.Margin = new Padding(4);
            buttondeletesbn.Name = "buttondeletesbn";
            buttondeletesbn.Size = new Size(118, 36);
            buttondeletesbn.TabIndex = 6;
            buttondeletesbn.Text = "Delete";
            buttondeletesbn.UseVisualStyleBackColor = true;
            // 
            // dataGridViewsbn
            // 
            dataGridViewsbn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewsbn.Location = new Point(54, 96);
            dataGridViewsbn.Margin = new Padding(4);
            dataGridViewsbn.Name = "dataGridViewsbn";
            dataGridViewsbn.RowHeadersWidth = 51;
            dataGridViewsbn.Size = new Size(872, 378);
            dataGridViewsbn.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 44);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 4;
            label1.Text = "SBN Page";
            // 
            // SBNPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(227, 253, 253);
            Controls.Add(buttoninputsbn);
            Controls.Add(buttondeletesbn);
            Controls.Add(dataGridViewsbn);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "SBNPage";
            Size = new Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)dataGridViewsbn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttoninputsbn;
        private Button buttondeletesbn;
        private DataGridView dataGridViewsbn;
        private Label label1;
    }
}

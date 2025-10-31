namespace SBN_Application.Forms.Menus
{
    partial class AssetPage
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
            dataGridViewasset = new DataGridView();
            buttondeleteasset = new Button();
            buttoninputasset = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewasset).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 29);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 0;
            label1.Text = "Asset Page";
            // 
            // dataGridViewasset
            // 
            dataGridViewasset.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewasset.Location = new Point(51, 90);
            dataGridViewasset.Name = "dataGridViewasset";
            dataGridViewasset.RowHeadersWidth = 51;
            dataGridViewasset.Size = new Size(698, 302);
            dataGridViewasset.TabIndex = 1;
            // 
            // buttondeleteasset
            // 
            buttondeleteasset.Location = new Point(501, 29);
            buttondeleteasset.Name = "buttondeleteasset";
            buttondeleteasset.Size = new Size(94, 29);
            buttondeleteasset.TabIndex = 2;
            buttondeleteasset.Text = "Delete";
            buttondeleteasset.UseVisualStyleBackColor = true;
            // 
            // buttoninputasset
            // 
            buttoninputasset.Location = new Point(626, 29);
            buttoninputasset.Name = "buttoninputasset";
            buttoninputasset.Size = new Size(94, 29);
            buttoninputasset.TabIndex = 3;
            buttoninputasset.Text = "Input";
            buttoninputasset.UseVisualStyleBackColor = true;
            // 
            // AssetPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(227, 253, 253);
            Controls.Add(buttoninputasset);
            Controls.Add(buttondeleteasset);
            Controls.Add(dataGridViewasset);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "AssetPage";
            Size = new Size(800, 432);
            ((System.ComponentModel.ISupportInitialize)dataGridViewasset).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridViewasset;
        private Button buttondeleteasset;
        private Button buttoninputasset;
    }
}

namespace Ficbook_Scraper
{
    partial class EditChapterForm
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
            this.ChapterTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ChapterTextBox
            // 
            this.ChapterTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChapterTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChapterTextBox.Location = new System.Drawing.Point(0, 0);
            this.ChapterTextBox.Multiline = true;
            this.ChapterTextBox.Name = "ChapterTextBox";
            this.ChapterTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChapterTextBox.Size = new System.Drawing.Size(800, 614);
            this.ChapterTextBox.TabIndex = 0;
            this.ChapterTextBox.TextChanged += new System.EventHandler(this.ChapterTextBox_TextChanged);
            // 
            // EditChapterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 614);
            this.Controls.Add(this.ChapterTextBox);
            this.Name = "EditChapterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditChapterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ChapterTextBox;
    }
}
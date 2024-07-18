namespace Ficbook_Scraper
{
    partial class Main_Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Split_Container = new System.Windows.Forms.SplitContainer();
            this.Link_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Parse_button = new System.Windows.Forms.Button();
            this.Labels_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Split_Container)).BeginInit();
            this.Split_Container.Panel1.SuspendLayout();
            this.Split_Container.Panel2.SuspendLayout();
            this.Split_Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // Split_Container
            // 
            this.Split_Container.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Split_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Split_Container.Location = new System.Drawing.Point(0, 0);
            this.Split_Container.Name = "Split_Container";
            this.Split_Container.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Split_Container.Panel1
            // 
            this.Split_Container.Panel1.Controls.Add(this.Link_textbox);
            this.Split_Container.Panel1.Controls.Add(this.label1);
            this.Split_Container.Panel1.Controls.Add(this.Parse_button);
            // 
            // Split_Container.Panel2
            // 
            this.Split_Container.Panel2.AutoScroll = true;
            this.Split_Container.Panel2.Controls.Add(this.Labels_textbox);
            this.Split_Container.Panel2.Controls.Add(this.label2);
            this.Split_Container.Size = new System.Drawing.Size(673, 767);
            this.Split_Container.SplitterDistance = 120;
            this.Split_Container.TabIndex = 0;
            // 
            // Link_textbox
            // 
            this.Link_textbox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Link_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Link_textbox.Location = new System.Drawing.Point(150, 39);
            this.Link_textbox.Name = "Link_textbox";
            this.Link_textbox.Size = new System.Drawing.Size(358, 24);
            this.Link_textbox.TabIndex = 2;
            this.Link_textbox.Text = "https://ficbook.net/readfic/8750841";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(224, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Вставьте ссылку на фикбук:";
            // 
            // Parse_button
            // 
            this.Parse_button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Parse_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Parse_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Parse_button.Location = new System.Drawing.Point(227, 71);
            this.Parse_button.Name = "Parse_button";
            this.Parse_button.Size = new System.Drawing.Size(198, 31);
            this.Parse_button.TabIndex = 0;
            this.Parse_button.Text = "Спарсить текст...";
            this.Parse_button.UseVisualStyleBackColor = true;
            this.Parse_button.Click += new System.EventHandler(this.Parse_button_Click);
            // 
            // Labels_textbox
            // 
            this.Labels_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Labels_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Labels_textbox.Location = new System.Drawing.Point(76, 31);
            this.Labels_textbox.Multiline = true;
            this.Labels_textbox.Name = "Labels_textbox";
            this.Labels_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Labels_textbox.Size = new System.Drawing.Size(506, 62);
            this.Labels_textbox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(307, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Теги:";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 767);
            this.Controls.Add(this.Split_Container);
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Скрапер";
            this.Split_Container.Panel1.ResumeLayout(false);
            this.Split_Container.Panel1.PerformLayout();
            this.Split_Container.Panel2.ResumeLayout(false);
            this.Split_Container.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Split_Container)).EndInit();
            this.Split_Container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer Split_Container;
        private System.Windows.Forms.TextBox Link_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Parse_button;
        private System.Windows.Forms.TextBox Labels_textbox;
        private System.Windows.Forms.Label label2;
    }
}


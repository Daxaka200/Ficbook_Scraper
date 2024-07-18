using System;
using System.Windows.Forms;

namespace Ficbook_Scraper
{
    public partial class EditChapterForm : Form
    {
        private string _chapterContent;
        private Chapter _chapter;

        public EditChapterForm(Chapter chapter)
        {
            InitializeComponent();
            _chapter = chapter;
            _chapterContent = chapter.Content;
            ChapterTextBox.Text = _chapterContent;
            this.Text = _chapter.Title;
        }

        private void ChapterTextBox_TextChanged(object sender, EventArgs e)
        {
            _chapterContent = ChapterTextBox.Text;
            _chapter.Content = _chapterContent;
        }
    }
}

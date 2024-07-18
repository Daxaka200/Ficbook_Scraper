using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ficbook_Scraper
{
    public partial class Main_Form : Form
    {
        private readonly BrowserHelper _browserHelper;
        private DataExtractor _dataExtractor;
        private ProgressBar _progressBar;
        private Label _progressLabel;
        private Ficbook _currentFicbook;

        public Main_Form()
        {
            InitializeComponent();
            _browserHelper = new BrowserHelper();

            InitializeProgressBar();
            Labels_textbox.Visible = false;
            label2.Visible = false;






            // Заполнение тестового объекта Ficbook
            //_currentFicbook = new Ficbook
            //{
            //    Url = "https://example.com/ficbook",
            //    Title = "Тестовый Фикбук",
            //    Fandom = "Тестовый Фандом",
            //    Tags = new List<string> { "тест", "фикбук", "пример" },
            //    Description = "Это описание тестового фикбука.",
            //    Chapters = new List<Chapter>
            //    {
            //        new Chapter { Url = "https://example.com/chapter1", Title = "Глава 1", Content = "Содержимое главы 1" },
            //        new Chapter { Url = "https://example.com/chapter2", Title = "Глава 2", Content = "Содержимое главы 2" }
            //    }
            //};

            //var exportForm = new ExportForm(_currentFicbook);
            //exportForm.Show();
        }

        private void InitializeProgressBar()
        {
            _progressBar = new ProgressBar
            {
                Width = 450,
                Style = ProgressBarStyle.Marquee,
                Visible = false
            };

            _progressLabel = new Label
            {
                Width = 400,
                Text = "Работа выполняется...",
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };

            // Центрируем элементы в панели
            CenterControl(_progressBar, Split_Container.Panel2);
            CenterControl(_progressLabel, Split_Container.Panel2, offsetY: _progressBar.Height + 10);

            Split_Container.Panel2.Controls.Add(_progressBar);
            Split_Container.Panel2.Controls.Add(_progressLabel);
        }

        private void CenterControl(Control control, Control parent, int offsetY = 0)
        {
            control.Location = new Point(
                (parent.Width - control.Width) / 2,
                (parent.Height - control.Height) / 2 + offsetY
            );
        }

        private async void Parse_button_Click(object sender, EventArgs e)
        {
            try
            {
                Parse_button.Enabled = false;
                ShowProgress();
                await Task.Run(async () =>
                {
                    await _browserHelper.InitializeAsync().ConfigureAwait(false);
                    string url = Link_textbox.Text;
                    if (string.IsNullOrWhiteSpace(url))
                    {
                        MessageBox.Show("Please enter a valid URL.");
                        return;
                    }

                    await _browserHelper.GetHtmlContentAsync(url).ConfigureAwait(false);

                    _dataExtractor = new DataExtractor(_browserHelper.GetPage());
                    var ficbook = await _dataExtractor.GetFicbookAsync(url).ConfigureAwait(false);

                    this.Invoke(new Action(() =>
                    {
                        _currentFicbook = ficbook;
                        this.Text = ficbook.Title;
                        Labels_textbox.Text = string.Join(", ", ficbook.Tags);
                        Labels_textbox.Visible = true;
                        label2.Visible = true;
                        DisplayChapters(ficbook.Chapters);
                    }));
                }).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                await _browserHelper.CloseBrowserAsync().ConfigureAwait(false);
                HideProgress();
                Parse_button.Enabled = true;
            }
        }

        private void DisplayChapters(List<Chapter> chapters)
        {
            int y = 100;
            int panelWidth = Split_Container.Panel2.Width;

            foreach (var chapter in chapters)
            {
                // Добавляем панель-разделитель
                var separator = new Panel
                {
                    Size = new System.Drawing.Size(panelWidth - 20, 2),
                    Location = new System.Drawing.Point(10, y),
                    BorderStyle = BorderStyle.FixedSingle
                };
                Split_Container.Panel2.Controls.Add(separator);
                y += 10; // Отступ после разделителя

                var label = new Label
                {
                    Text = chapter.Title,
                    Location = new System.Drawing.Point(10, y),
                    AutoSize = true,
                    Font = new Font("Arial", 12, FontStyle.Bold)
                };
                Split_Container.Panel2.Controls.Add(label);

                var editButton = new Button
                {
                    Text = "Редактировать главу",
                    Location = new System.Drawing.Point(panelWidth - 180, y),
                    Tag = chapter.Url,
                    Size = new System.Drawing.Size(150, 30)
                };
                editButton.Click += EditButton_Click;
                Split_Container.Panel2.Controls.Add(editButton);

                y += 50; // Расстояние между элементами
            }

            // Кнопка "Перейти к выгрузке"
            var exportButton = new Button
            {
                Text = "Перейти к выгрузке",
                Location = new System.Drawing.Point(10, y + 20),
                Size = new System.Drawing.Size(200, 40)
            };
            exportButton.Click += ExportButton_Click;
            Split_Container.Panel2.Controls.Add(exportButton);
        }

        private void ShowProgress()
        {
            _progressBar.Visible = true;
            _progressLabel.Visible = true;
        }

        private void HideProgress()
        {
            _progressBar.Visible = false;
            _progressLabel.Visible = false;
        }

        private async void EditButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                string chapterUrl = button.Tag as string;
                if (!string.IsNullOrEmpty(chapterUrl) && _currentFicbook != null)
                {
                    try
                    {
                        ShowProgress();
                        await Task.Run(() =>
                        {
                            var chapter = _currentFicbook.Chapters.Find(c => c.Url == chapterUrl);
                            if (chapter != null)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    var editForm = new EditChapterForm(chapter);
                                    editForm.Show();
                                }));
                            }
                        }).ConfigureAwait(true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                    finally
                    {
                        HideProgress();
                    }
                }
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (_currentFicbook != null)
            {
                var exportForm = new ExportForm(_currentFicbook);
                exportForm.Show();
            }
        }
    }
}

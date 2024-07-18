using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace Ficbook_Scraper
{
    public class DataExtractor
    {
        private readonly IPage _page;

        public DataExtractor(IPage page)
        {
            _page = page;
        }

        public async Task<string> GetTitleAsync()
        {
            try
            {
                return await _page.GetTitleAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return string.Empty;
            }
        }

        public async Task<string> GetFandomAsync()
        {
            try
            {
                return await _page.EvaluateFunctionAsync<string>("() => document.querySelector('.fanfic-main-info .mb-10 a').innerText.trim()").ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return string.Empty;
            }
        }

        public async Task<string> GetDescriptionAsync()
        {
            try
            {
                return await _page.EvaluateFunctionAsync<string>("() => document.querySelector('.description .urlized-links.js-public-beta-description.text-preline').innerText.trim()").ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return string.Empty;
            }
        }

        public async Task<List<string>> GetTagsAsync()
        {
            try
            {
                var tags = await _page.EvaluateFunctionAsync<string[]>(@"() => {
                    return Array.from(document.querySelectorAll('.description .tags .tag')).map(tag => tag.textContent.trim());
                }").ConfigureAwait(false);
                return new List<string>(tags);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<string>();
            }
        }

        public async Task<List<Chapter>> GetChaptersAsync()
        {
            try
            {
                var chapters = await _page.EvaluateFunctionAsync<Chapter[]>(@"() => {
                    return Array.from(document.querySelectorAll('.list-of-fanfic-parts .part')).map(part => {
                        const titleElement = part.querySelector('.part-title h3');
                        const linkElement = part.querySelector('.part-link');
                        return {
                            Title: titleElement ? titleElement.textContent.trim() : '',
                            Url: linkElement ? linkElement.href : '',
                            Content: ''
                        };
                    });
                }").ConfigureAwait(false);
                return new List<Chapter>(chapters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<Chapter>();
            }
        }

        public async Task<string> GetChapterContentAsync(string chapterUrl)
        {
            try
            {
                await _page.GoToAsync(chapterUrl, new NavigationOptions { Timeout = 0 }).ConfigureAwait(false);

                // Удаление элементов с классом 'fb-ads-block ads-in-text'
                await _page.EvaluateFunctionAsync(@"() => {
                    const ads = document.querySelectorAll('.fb-ads-block.ads-in-text');
                    ads.forEach(ad => ad.remove());
                }").ConfigureAwait(false);

                var content = await _page.QuerySelectorAsync("#content").ConfigureAwait(false);
                return await content.EvaluateFunctionAsync<string>("el => el.innerHTML").ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return string.Empty;
            }
        }

        public async Task<Ficbook> GetFicbookAsync(string url)
        {
            var ficbook = new Ficbook { Url = url };
            ficbook.Title = await GetTitleAsync().ConfigureAwait(false);
            ficbook.Fandom = await GetFandomAsync().ConfigureAwait(false);
            ficbook.Description = await GetDescriptionAsync().ConfigureAwait(false);
            ficbook.Tags = await GetTagsAsync().ConfigureAwait(false);
            ficbook.Chapters = await GetChaptersAsync().ConfigureAwait(false);

            foreach (var chapter in ficbook.Chapters)
            {
                chapter.Content = await GetChapterContentAsync(chapter.Url).ConfigureAwait(false);
            }

            return ficbook;
        }
    }
}

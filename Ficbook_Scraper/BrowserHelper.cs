using System;
using System.Threading.Tasks;
using PuppeteerExtraSharp;
using PuppeteerExtraSharp.Plugins.ExtraStealth;
using PuppeteerSharp;

namespace Ficbook_Scraper
{
    public class BrowserHelper
    {
        private IBrowser _browser;
        private IPage _page;
        private readonly string _browserPath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
        private readonly string _proxyServer = "194.39.32.241:6538";
        private readonly string _proxyUsername = "mbhvvvpe";
        private readonly string _proxyPassword = "k9h4boe34g82";

        public BrowserHelper()
        {
        }

        public async Task InitializeAsync()
        {
            var puppeteerExtra = new PuppeteerExtra();
            puppeteerExtra.Use(new StealthPlugin());

            _browser = await puppeteerExtra.LaunchAsync(new LaunchOptions
            {
                ExecutablePath = _browserPath,
                Headless = true, 
                Args = new[]
                {
                    "--disable-blink-features=AutomationControlled",
                    "--no-sandbox",
                    "--disable-setuid-sandbox",
                    "--disable-dev-shm-usage",
                    "--disable-web-security",
                    "--disable-accelerated-2d-canvas",
                    "--disable-gpu",
                    "--no-first-run",
                    "--no-default-browser-check",
                    "--disable-extensions",
                    "--ignore-certificate-errors",
                    "--disable-popup-blocking",
                    "--disable-plugins",
                    "--disable-software-rasterizer",
                    "--disable-features=site-per-process",
                    $"--proxy-server={_proxyServer}"
                },
                IgnoreHTTPSErrors = true,
                DefaultViewport = new ViewPortOptions
                {
                    Width = 1920,
                    Height = 1080
                }
            }).ConfigureAwait(false);

            _page = await _browser.NewPageAsync().ConfigureAwait(false);
            await _page.SetUserAgentAsync("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36").ConfigureAwait(false);

            // Авторизация в прокси
            await _page.AuthenticateAsync(new Credentials
            {
                Username = _proxyUsername,
                Password = _proxyPassword
            }).ConfigureAwait(false);
        }

        public async Task SetCookiesAsync(string url, params CookieParam[] cookies)
        {
            await _page.GoToAsync(url, new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.DOMContentLoaded } }).ConfigureAwait(false);
            await _page.SetCookieAsync(cookies).ConfigureAwait(false);
        }

        public async Task<string> GetHtmlContentAsync(string url)
        {
            try
            {
                await _page.GoToAsync(url, new NavigationOptions { Timeout = 0, WaitUntil = new[] { WaitUntilNavigation.DOMContentLoaded } }).ConfigureAwait(false);
                return await _page.GetContentAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return string.Empty;
            }
        }

        public async Task CloseBrowserAsync()
        {
            if (_browser != null)
            {
                await _browser.CloseAsync().ConfigureAwait(false);
            }
        }

        public IPage GetPage()
        {
            return _page;
        }
    }
}

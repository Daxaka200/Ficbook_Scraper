using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuppeteerSharp;

namespace Ficbook_Scraper
{
    public partial class ExportForm : Form
    {
        private readonly BrowserHelper _browserHelper;
        private readonly Ficbook _ficbook;

        public ExportForm(Ficbook ficbook)
        {
            InitializeComponent();
            _ficbook = ficbook;
            _browserHelper = new BrowserHelper();
            Load += async (s, e) => await SignInWithCookies();
        }

        private async Task SignInWithCookies()
        {
            await _browserHelper.InitializeAsync();

            // Устанавливаем куки для авторизации
            var cookies = new[]
            {
                new CookieParam
                {
                    Name = "yabs-sid",
                    Value = "1940458211721228384",
                    Domain = "mc.yandex.ru",
                    Path = "/",
                    Expires = (DateTimeOffset.UtcNow + TimeSpan.FromDays(1)).ToUnixTimeSeconds(),
                    HttpOnly = false,
                    Secure = false
                },
                new CookieParam
                {
                    Name = "__Host-next-auth.csrf-token",
                    Value = "c4a6eea462a1481c18cad5d708460a30d4e5889025eaf7a5b0e175061a7d7a40%7Cf01dc108aee0332beeb83c11b04b536efe6e04e23e0c266b82e94db2aacb6685",
                    Domain = "zahleb.me",
                    Path = "/",
                    Expires = (DateTimeOffset.UtcNow + TimeSpan.FromDays(1)).ToUnixTimeSeconds(),
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSite.Lax
                },
                new CookieParam
                {
                    Name = "__Secure-next-auth.callback-url",
                    Value = "https%3A%2F%2Fzahleb.me%2F",
                    Domain = "zahleb.me",
                    Path = "/",
                    Expires = (DateTimeOffset.UtcNow + TimeSpan.FromDays(1)).ToUnixTimeSeconds(),
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSite.Lax
                },
                new CookieParam
                {
                    Name = "_ym_visorc",
                    Value = "w",
                    Domain = ".zahleb.me",
                    Path = "/",
                    Expires = (DateTimeOffset.UtcNow + TimeSpan.FromDays(1)).ToUnixTimeSeconds(),
                    HttpOnly = false,
                    Secure = false
                },
                new CookieParam
                {
                    Name = "_ym_isad",
                    Value = "2",
                    Domain = ".zahleb.me",
                    Path = "/",
                    Expires = (DateTimeOffset.UtcNow + TimeSpan.FromDays(1)).ToUnixTimeSeconds(),
                    HttpOnly = false,
                    Secure = false
                },
                new CookieParam
                {
                    Name = "__Secure-next-auth.session-token",
                    Value = "eyJhbGciOiJkaXIiLCJlbmMiOiJBMjU2R0NNIn0..dI3PoSAu18_tlCPH.YRhI0-SrrSv8WnIkrFnbbTsDUh77lnhCGps_g0kHzFAZh-C1j_0Kr9Vjk5R_18SQcNA5i9PdsordCUvNCwoZF7X0xFyQ8IVCutM3RWX0iaTlEFdmKmxfAuXbx3I1VurYVTbzD_2rUtVK4H9FX5MAD5475i-T8JuBZJ9zyko4RpqO50WpAtdxr_d6UQEuDFuBRZTJPhsCjYOLifXGP4xEJVj_0XuWAMnf7nmBDMYirvhGIz59gnGWc7-ddb-yIig0pKfOlWNwbpPnmdvJRAzRlm4c5E5U65_NslOsdWVYUAl2JnsrTVOeXXryizkypSt0B9a3tlKPxnQYroBU8D6HG7qZQR3gKis3VKqlKLpX4rmHijPN-Q5kd8JglWz2XyGpbFPyDJvVDcwMus0gWgJ6oXyJqMDwo7aGzKvuoYH09SMNdC7ffnk3ML58tEuJEwGobII6pD9kh8Qj9wunai1nkADY2PkP8W1LwvHZPjtDBqPBv36qeSFwYNhye03i13AUY7QyNKwonxrZbSPGA45yX8Eb__M1O1WHKKJHFYp-vWui6vi9hOGxB3b9F_Moh77KwPZIb2RjgO6GU0aYHb5eICkHSxq4YX8zvPOkUuCyYgnF5KgC4XB1fthlX38ZQ_Wu_ytmmeTIFyiLs4sBEb9RD7YSwV6-SuC1EuXBKjIA8a6eYjfaWk7NY2tvS2eNPLJbB_MbgHNdDbu7iHaY1Rk0QWetbhUtY9zQ73s6f0x82LG7iZXeniXriaHy2k4cEBNUwBXwiHqePom_qq17mLTsAzTshR7Bc-30dKPvuMpSDEK2VQLknPbr01yC7SCU7zDQy5nd-YVlfqpUOvTg4gADI4L7iOS04CN6pJd7OgadLWoQNBiqgyyRAJrYrs5VIhHy2CvrcKN0_Sui9i8kw_xHM4tx6OeK52WEUKB4usSGnbTjE...",
                    Domain = "zahleb.me",
                    Path = "/",
                    Expires = (DateTimeOffset.UtcNow + TimeSpan.FromDays(1)).ToUnixTimeSeconds(),
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSite.Lax
                },
                new CookieParam
                {
                    Name = "ymex",
                    Value = "2036588384.yrts.1721228384#2036588384.yrtsi.1721228384",
                    Domain = ".yandex.ru",
                    Path = "/",
                    Expires = (DateTimeOffset.UtcNow + TimeSpan.FromDays(365)).ToUnixTimeSeconds(),
                    HttpOnly = false,
                    Secure = false
                },
                new CookieParam
                {
                    Name = "bh",
                    Value = "EkAiTm90L0EpQnJhbmQiO3Y9IjgiLCAiQ2hyb21pdW0iO3Y9IjEyNiIsICJHb29nbGUgQ2hyb21lIjt2PSIxMjYiKgI/MDoJIldpbmRvd3Mi",
                    Domain = "mc.yandex.ru",
                    Path = "/",
                    Expires = (DateTimeOffset.UtcNow + TimeSpan.FromDays(365)).ToUnixTimeSeconds(),
                    HttpOnly = false,
                    Secure = false
                },
                new CookieParam
                {
                    Name = "_ym_d",
                    Value = "1721228393",
                    Domain = ".zahleb.me",
                    Path = "/",
                    Expires = (DateTimeOffset.UtcNow + TimeSpan.FromDays(365)).ToUnixTimeSeconds(),
                    HttpOnly = false,
                    Secure = false
                },
                new CookieParam
                {
                    Name = "_ym_uid",
                    Value = "1721015284132652367",
                    Domain = ".zahleb.me",
                    Path = "/",
                    Expires = (DateTimeOffset.UtcNow + TimeSpan.FromDays(365)).ToUnixTimeSeconds(),
                    HttpOnly = false,
                    Secure = false
                },
                new CookieParam
                {
                    Name = "yashr",
                    Value = "3658355671721228392",
                    Domain = ".yandex.ru",
                    Path = "/",
                    Expires = (DateTimeOffset.UtcNow + TimeSpan.FromDays(365)).ToUnixTimeSeconds(),
                    HttpOnly = false,
                    Secure = false,
                    SameSite = SameSite.None
                },
                new CookieParam
                {
                    Name = "receive-cookie-deprecation",
                    Value = "1",
                    Domain = ".yandex.ru",
                    Path = "/",
                    Expires = (DateTimeOffset.UtcNow + TimeSpan.FromDays(365)).ToUnixTimeSeconds(),
                    HttpOnly = false,
                    Secure = false,
                    SameSite = SameSite.None
                },
                new CookieParam
                {
                    Name = "bh",
                    Value = "Ej4iTm90L0EpQnJhbmQiO3Y9IjgiLCJDaHJvbWl1bSI7dj0iMTI2IiwiR29vZ2xlIENocm9tZSI7dj0iMTI2IhoFIng4NiIiECIxMjYuMC42NDc4LjEyNyIqAj8wOgkiV2luZG93cyJCCCIxMC4wLjAiSgQiNjQiUlsiTm90L0EpQnJhbmQiO3Y9IjguMC4wLjAiLCJDaHJvbWl1bSI7dj0iMTI2LjAuNjQ3OC4xMjciLCJHb29nbGUgQ2hyb21lIjt2PSIxMjYuMC42NDc4LjEyNyIi",
                    Domain = ".yandex.ru",
                    Path = "/",
                    Expires = (DateTimeOffset.UtcNow + TimeSpan.FromDays(365)).ToUnixTimeSeconds(),
                    HttpOnly = false,
                    Secure = false
                },
                new CookieParam
                {
                    Name = "i",
                    Value = "mE7WEBWJWjoDUKfSTG7iJDCoPKSvwrEaPxZxZWLMoMJCcfwQhYfhGTq+AL/dJRa+4TliEYSOr/IkFxHBD7FrzGstrik=",
                    Domain = ".yandex.ru",
                    Path = "/",
                    Expires = (DateTimeOffset.UtcNow + TimeSpan.FromDays(365)).ToUnixTimeSeconds(),
                    HttpOnly = false,
                    Secure = false
                },
                new CookieParam
                {
                    Name = "yandexuid",
                    Value = "4001859181721228384",
                    Domain = ".yandex.ru",
                    Path = "/",
                    Expires = (DateTimeOffset.UtcNow + TimeSpan.FromDays(365)).ToUnixTimeSeconds(),
                    HttpOnly = false,
                    Secure = false
                },
                new CookieParam
                {
                    Name = "yuidss",
                    Value = "4001859181721228384",
                    Domain = ".yandex.ru",
                    Path = "/",
                    Expires = (DateTimeOffset.UtcNow + TimeSpan.FromDays(365)).ToUnixTimeSeconds(),
                    HttpOnly = false,
                    Secure = false
                },
                new CookieParam
                {
                    Name = "_ga",
                    Value = "GA1.1.701530263.1721228397",
                    Domain = ".zahleb.me",
                    Path = "/",
                    Expires = (DateTimeOffset.UtcNow + TimeSpan.FromDays(365)).ToUnixTimeSeconds(),
                    HttpOnly = false,
                    Secure = false
                },
                new CookieParam
                {
                    Name = "_ga_HHEFK237E4",
                    Value = "GS1.1.1721228396.1.0.1721228397.0.0.0",
                    Domain = ".zahleb.me",
                    Path = "/",
                    Expires = (DateTimeOffset.UtcNow + TimeSpan.FromDays(365)).ToUnixTimeSeconds(),
                    HttpOnly = false,
                    Secure = false
                }
            };

            await _browserHelper.SetCookiesAsync("https://zahleb.me", cookies);

            // Переход для проверки авторизации
            string content = await _browserHelper.GetHtmlContentAsync("https://zahleb.me");

            MessageBox.Show(content);
        }
    }
}

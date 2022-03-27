using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Vgtu.Test.Chrome
{
    public class OldLinkRedirectTest
    {
        private readonly string _oldUrl = "https://vgtu.lt";
        private readonly string _url = "https://vilniustech.lt/";
        private readonly IWebDriver _driver = new ChromeDriver();

        [Fact]
        public void RedirectOnOldLink()
        {
            using (_driver)
            {
                _driver.Navigate().GoToUrl(_oldUrl);

                Assert.Equal(_url, _driver.Url);
            }
        }
    }
}

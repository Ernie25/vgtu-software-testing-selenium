using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Vgtu.Test.Chrome
{
    public class OldLinkRedirectTest : BaseArrangement
    {
        [Fact]
        public void RedirectOnOldLink()
        {
            using (_driver)
            {
                _driver.Navigate().GoToUrl(_oldUrl);

                Assert.Equal(Url, _driver.Url);
            }
        }
    }
}

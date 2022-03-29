using Xunit;

namespace Vgtu.Test.Tests
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

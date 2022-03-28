using Xunit;
using System.Threading;

namespace Vgtu.Test.Chrome
{
    public class GeneralTest : BaseArrangement
    {
        [Fact]
        public void LoadApplicationPage()
        {
            using (_driver)
            {
                _driver.Navigate().GoToUrl(Url);
                
                Assert.Equal(Url, _driver.Url);
                Assert.Equal(Title, _driver.Title);
            }
        }
        
        [Fact]
        public void ReloadApplicationPage()
        {
            using (_driver)
            {
                _driver.Navigate().GoToUrl(Url);

                _driver.Navigate().Refresh();

                Assert.Equal(Url, _driver.Url);
                Assert.Equal(Title, _driver.Title);
            }
        }

        [Fact]
        public void BackToApplicationHomePage()
        {
            using (_driver)
            {
                _driver.Navigate().GoToUrl(Url);

                _driver.Navigate().GoToUrl(Url + _universityPageUri);
                Thread.Sleep(3000);
                _driver.Navigate().Back();

                Assert.Equal(Url, _driver.Url);
                Assert.Equal(Title, _driver.Title);
            }
        }
    }
}
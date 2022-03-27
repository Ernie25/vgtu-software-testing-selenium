using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Vgtu.Test.Chrome
{
    public class GeneralTests
    {
        private readonly string _url = "https://vilniustech.lt/";
        private readonly string _universityPageUri = "universitetas/9";
        private readonly string _title = "VILNIUS TECH – Vilniaus Gedimino technikos universitetas";
        private readonly IWebDriver _driver = new ChromeDriver();

        [Fact]
        public void LoadApplicationPage()
        {
            using (_driver)
            {
                _driver.Navigate().GoToUrl(_url);
                
                Assert.Equal(_url, _driver.Url);
                Assert.Equal(_title, _driver.Title);
            }
        }
        
        [Fact]
        public void ReloadApplicationPage()
        {
            using (_driver)
            {
                _driver.Navigate().GoToUrl(_url);

                _driver.Navigate().Refresh();

                Assert.Equal(_url, _driver.Url);
                Assert.Equal(_title, _driver.Title);
            }
        }

        [Fact]
        public void BackToApplicationHomePage()
        {
            using (_driver)
            {
                _driver.Navigate().GoToUrl(_url);

                _driver.Navigate().GoToUrl(_url + _universityPageUri);
                Thread.Sleep(3000);
                _driver.Navigate().Back();

                Assert.Equal(_url, _driver.Url);
                Assert.Equal(_title, _driver.Title);
            }
        }
    }
}
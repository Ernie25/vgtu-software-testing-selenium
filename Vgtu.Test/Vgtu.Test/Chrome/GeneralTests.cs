using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Vgtu.Test.Chrome
{
    public class GeneralTests
    {
        private readonly string _url = "https://vilniustech.lt/";
        private readonly IWebDriver _driver = new ChromeDriver();

        [Fact]
        public void LoadApplicationPage()
        {
            string expectedTitle = "VILNIUS TECH – Vilniaus Gedimino technikos universitetas";
            using (_driver)
            {
                _driver.Navigate().GoToUrl(_url);
                
                Assert.Equal(_url, _driver.Url);
                Assert.Equal(expectedTitle, _driver.Title);
            }
        } 
    }
}
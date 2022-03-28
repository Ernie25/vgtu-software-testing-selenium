using Xunit;
using OpenQA.Selenium;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace Vgtu.Test.Chrome
{
    public class SocialMediaRedirectTest : BaseArrangement
    {
        [Fact]
        public void RedirectThroughElementHeading()
        {
            using (_driver)
            {
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(Url);

                var link = _driver.FindElement(By.LinkText("#VILNIUSTECH INSTAGRAM"));
                link?.Click();

                Assert.Equal(_instagramUrl, _driver.Url);
            }
        }

        [Fact]
        public void RedirectThroughLinkIg()
        {
            using (_driver)
            {
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(Url);
                Thread.Sleep(2000);

                var instagramPostWrapper = _driver.FindElement(By.ClassName("impressions"));
                var links = instagramPostWrapper.FindElements(By.TagName("a"));
                foreach(var link in links)
                {
                    var expectedResult = link.GetAttribute("href") + "/";
                    link?.Click();
                    var browserTabs = new List<string>(_driver.WindowHandles);
                    var originTab = browserTabs.First();
                    var newTab = browserTabs.Last();
                    string result = _driver.SwitchTo().Window(newTab).Url;
                    browserTabs.Remove(newTab);
                    _driver.SwitchTo().Window(newTab).Close();
                    _driver.SwitchTo().Window(originTab);

                    Assert.Equal(expectedResult, result);
                }
            }
        }

        [Fact]
        public void RedirectThroughFooterLink()
        {
            using (_driver)
            {
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(Url);
                Thread.Sleep(2000);

                var link = _driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/ul/li[4]/a"));
                link?.Click();
                var browserTabs = new List<string>(_driver.WindowHandles);
                var newTab = browserTabs.Last();
                string result = _driver.SwitchTo().Window(newTab).Url;


                Assert.Equal(_instagramUrl, result);
            }
        }
    }
}

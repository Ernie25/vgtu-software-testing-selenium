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

                var instagramPostsWrapper = _driver.FindElement(By.ClassName("impressions"));
                var links = instagramPostsWrapper.FindElements(By.TagName("a"));
                foreach(var link in links)
                {
                    var expectedResult = link.GetAttribute("href").Replace("https://www.instagram.com/", "") + "/";
                    link?.Click();
                    var browserTabs = new List<string>(_driver.WindowHandles);
                    var originTab = browserTabs.First();
                    var newTab = browserTabs.Last();
                    bool result = _driver.SwitchTo().Window(newTab).Url.Contains(expectedResult);
                    browserTabs.Remove(newTab);
                    _driver.SwitchTo().Window(newTab).Close();
                    _driver.SwitchTo().Window(originTab);

                    Assert.True(result);
                }
            }
        }

        [Theory]
        [MemberData(nameof(FooterSocialMediaLinks))]
        public void RedirectThroughFooterLink(string elementXpath, string expectedBaseUrl)
        {
            using (_driver)
            {
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(Url);
                Thread.Sleep(2000);

                var link = _driver.FindElement(By.XPath(elementXpath));
                link?.Click();
                var browserTabs = new List<string>(_driver.WindowHandles);
                var newTab = browserTabs.Last();
                bool result = _driver.SwitchTo().Window(newTab).Url.Contains(expectedBaseUrl);

                Assert.True(result);
            }
        }

        private static IEnumerable<object[]> FooterSocialMediaLinks()
        {
            yield return new object[] {
                "/html/body/div[3]/div/div[2]/ul/li[2]/a",
                "youtube.com"
            };
            yield return new object[] {
                "/html/body/div[3]/div/div[2]/ul/li[1]/a",
                "facebook.com"
            };
            yield return new object[] {
                "/html/body/div[3]/div/div[2]/ul/li[3]/a",
                "linkedin.com"
            };
            yield return new object[] {
                "/html/body/div[3]/div/div[2]/ul/li[4]/a",
                "instagram.com"
            };
        }
    }
}

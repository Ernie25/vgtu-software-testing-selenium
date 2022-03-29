using Xunit;
using OpenQA.Selenium;
using Vgtu.Test.Helpers;
using System.Collections.Generic;

namespace Vgtu.Test.Chrome
{
    public class SearchTest : BaseArrangement
    {
        [Fact]
        public void ShowClassAppear_AfterSearchIconBeingClicked()
        {
            using (_driver)
            {
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(Url);

                var searchIcon = _driver.FindElement(By.XPath("//input[@value='Paieška']"));
                var searchDiv = _driver.FindElement(By.ClassName("search"));
                bool isShown = searchDiv.GetAttribute("class").Contains("show");
                searchIcon.Click();
                searchDiv = _driver.FindElement(By.ClassName("search"));

                Assert.NotEqual(searchDiv.GetAttribute("class").Contains("show"), isShown);
            }
        }

        [Theory]
        [MemberData(nameof(SearchData))]
        public void MakeSearchRequest_AfterSearchIconBeingClicked(string expectedItem, string expectedQueryUri)
        {
            using (_driver)
            {
                string expectedUrl = StringUrlBuilder.BuildQueryUrl(Url, expectedItem, "search");
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(Url);

                var searchDiv = _driver.FindElement(By.ClassName("search"));
                var searchIcon = _driver.FindElement(By.XPath("//input[@value='Paieška']"));
                searchIcon.Click();
                var searchInput = searchDiv.FindElement(By.Name("q"));
                searchInput.SendKeys(expectedItem);
                searchIcon.Click();
                var resultSearchInput = _driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[2]/form/fieldset/input[1]"));
                var resultSpan = _driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[3]/span"));

                Assert.Equal(Url + expectedQueryUri, _driver.Url);
                Assert.Equal(expectedItem, resultSearchInput.GetAttribute("value"));
                Assert.Equal(expectedItem, resultSpan.Text);

            }
        }

        [Theory]
        [MemberData(nameof(SearchData))]
        public void MakeSearchRequestFromSearchPage_AfterSearchIconIsBeingClicked(string expectedItem, string expectedQueryUri)
        {
            using (_driver)
            {
                string url = StringUrlBuilder.BuildQueryUrl(Url, expectedItem, "search"); ;
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(url);

                var searchDiv = _driver.FindElement(By.ClassName("search_list_form"));
                var searchIcon = _driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[2]/form/fieldset/input[3]"));
                var searchInput = searchDiv.FindElement(By.Name("q"));
                searchIcon.Click();
                searchDiv = _driver.FindElement(By.ClassName("search_list_form"));
                searchInput = searchDiv.FindElement(By.Name("q"));
                var resultSpan = _driver.FindElement(By.ClassName("mark"));

                Assert.Equal(Url + expectedQueryUri, _driver.Url);
                Assert.Equal(expectedItem, searchInput.GetAttribute("Value"));
                Assert.Equal(expectedItem, resultSpan.Text);
            }
        }

        private static IEnumerable<object[]> SearchData()
        {
            yield return new object[] {
                "VGTU SA",
                "?q=VGTU+SA&act=search"
            };
            yield return new object[] {
                "VGTU",
                "?q=VGTU&act=search"
            };
            yield return new object[] {
                "",
                "?q=&act=search"
            };
        }
    }
}

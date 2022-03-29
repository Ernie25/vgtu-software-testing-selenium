using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;
using Vgtu.Test.Helpers;
using Xunit;


namespace Vgtu.Test.Tests
{
    public class PageTest : BaseArrangement
    {
        [Theory]
        [MemberData(nameof(Pages))]
        public void ReachPage(string linkText, string expectedUri)
        {
            using (_driver)
            {                
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(Url);


                var navigationMenu = _driver.FindElement(By.ClassName("main_menu"));
                var navigationButton = navigationMenu.FindElement(By.LinkText(linkText));
                navigationButton?.Click();

                Assert.Equal(StringUrlBuilder.BuildUrl(Url, expectedUri), _driver.Url);
            }
        }

        private static IEnumerable<object[]> Pages()
        {
            yield return new object[] {
                "Universitetas",
                PageUri.UniversityPageUri
            };
            yield return new object[] {
                "Stojantiesiems",
                PageUri.ApplicantsPageUri
            };
            yield return new object[] {
                "Mokslui",
                PageUri.EducationPageUri
            };
            yield return new object[] {
                "Verslui",
                PageUri.BusinessPageUri
            };
            yield return new object[] {
                "Tarptautiškumas",
                PageUri.InternationalStudentsPageUri
            };
            yield return new object[] {
                "Fakultetai",
                PageUri.FacultiesPageUri
            };
        }
    }
}

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
        public void ReachPage(string linkText, string expectedUri, string wrapper)
        {
            using (_driver)
            {                
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(Url);

                var navigationMenu = _driver.FindElement(By.ClassName(wrapper));
                var navigationButton = navigationMenu.FindElement(By.LinkText(linkText));
                navigationButton?.Click();
                
                Assert.Equal(StringUrlBuilder.BuildUrl(Url, expectedUri), _driver.Url);
            }
        }
        private static IEnumerable<object[]> Pages()
        {
            yield return new object[] {
                "Universitetas",
                PageUri.UniversityPageUri,
                "main_menu"
            };
            yield return new object[] {
                "Stojantiesiems",
                PageUri.ApplicantsPageUri,
                "main_menu"
            };
            yield return new object[] {
                "Mokslui",
                PageUri.EducationPageUri,
                "main_menu"
            };
            yield return new object[] {
                "Verslui",
                PageUri.BusinessPageUri,
                "main_menu"
            };
            yield return new object[] {
                "Tarptautiškumas",
                PageUri.InternationalStudentsPageUri,
                "main_menu"
            };
            yield return new object[] {
                "Fakultetai",
                PageUri.FacultiesPageUri,
                "main_menu"
            };
            yield return new object[] {
                "Kontaktai",
                PageUri.MainContactsUri,
                "footer-nav"
            };
            yield return new object[] {
                "Duomenų saugumas",
                PageUri.DataSecuriytUri,
                "footer-nav"
            };
            yield return new object[] {
                "Alumni",
                PageUri.AlumniUri,
                "footer-nav"
            };
        }
    }
}

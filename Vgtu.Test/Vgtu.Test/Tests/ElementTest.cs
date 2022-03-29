using OpenQA.Selenium;
using Xunit;

namespace Vgtu.Test.Tests
{
    public class ElementTest : BaseArrangement
    {
        [Fact]
        public void ImageElementContainsImageClass_FacultyNewsDiv()
        {
            using (_driver)
            {
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(Url);
                string expectedClass = "image";
                string wrapperClass = "faculty_news";
                string tagName = "img";

                var imageWrapper = _driver.FindElement(By.ClassName(wrapperClass));
                var imageElements = imageWrapper.FindElements(By.TagName(tagName));


                foreach(var image in imageElements)
                {
                    Assert.Equal(expectedClass, image.GetAttribute("class"));
                }
            }
        }
    }
}

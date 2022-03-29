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
        
        [Fact]
        public void EventDivHasDescriptionAndDateDivs()
        {
            using (_driver)
            {
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(Url);

                var eventsList = _driver.FindElement(By.Id("events_list"));
                var events = eventsList.FindElements(By.ClassName("events_item"));

                foreach (var e in events) 
                {
                    var dateDiv = e.FindElement(By.ClassName("date"));
                    var month = e.FindElement(By.ClassName("month"));
                    var descDiv = e.FindElement(By.ClassName("desc"));
                    var desc = descDiv.FindElement(By.TagName("a"));


                    Assert.NotNull(dateDiv);
                    Assert.NotNull(month);
                    Assert.NotNull(descDiv);
                    Assert.NotNull(desc);
                }


            }
        }
    }
}

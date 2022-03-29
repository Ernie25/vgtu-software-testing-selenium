using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Vgtu.Test
{
    public class BaseArrangement
    {
        protected string Url { get; set; } = "https://vilniustech.lt/";
        protected string Title { get; set; } = "VILNIUS TECH – Vilniaus Gedimino technikos universitetas";
        protected readonly string _oldUrl = "https://vgtu.lt";
        protected readonly string _instagramUrl = "https://www.instagram.com/vilniustech/";
        protected readonly IWebDriver _driver = new ChromeDriver();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace AutomationCSharpTraining
{
    class HomePage
    {
        IWebDriver _driver;
        const string MailLinkLocator = "desk-notif-card__login-new-item";

        public IWebElement MailLink { get; set; }
        public List<IWebElement> LiTags;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            MailLink = _driver.FindElement(By.ClassName(MailLinkLocator));

            /*Examples of 'By search' that are not presented in the flow of the test
            By Name:
            var SearchField = _driver.FindElement(By.Name("text"));

            By Tag Name:
            LiTags = _driver.FindElements(By.TagName("li")).ToList();

            By Link Text:
            var WeatherLink = _driver.FindElement(By.LinkText("Погода"));

            By Partial Link Text:
            var LinkWithCustomText = _driver.FindElement(By.PartialLinkText("ро"));

            By CSS
            var NewsLink = _driver.FindElement(By.CssSelector("span[class='news__tab-text']"));
            */            
        }

        public void EnterMailLoginPage()
        {
            MailLink.Click();            
        }
    }
}

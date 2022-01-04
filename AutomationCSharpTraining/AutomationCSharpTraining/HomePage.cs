using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace AutomationCSharpTraining
{
    class HomePage
    {
        private readonly IWebDriver _driver;
        //public List<IWebElement> LiTags;
        private static readonly string HomeUrl = "https://yandex.by";
        private static readonly By _mailLink = By.ClassName("desk-notif-card__login-new-item");
        private static readonly By _usernameLocator = By.ClassName("desk-notif-card__user-name");
        

        public HomePage(IWebDriver driver)
        {
            _driver = driver;            
        }

        public HomePage URL()
        {
            _driver.Url = HomeUrl;
            return new HomePage(_driver);
        }            
        public IWebElement MailLink => _driver.FindElement(_mailLink);
        public IWebElement Username => _driver.FindElement(_usernameLocator);

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


        public UsernamePage EnterLoginPage()
        {
            MailLink.Click();
            return new UsernamePage(_driver);
        }

        public bool IsLoggedIn(string username)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(condition =>
            {
                try
                {
                    return Username.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
            );
            Username.FindElement(By.XPath("//span[text()='" + username + "']"));
            return Username.Displayed;
        }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Nest;

namespace AutomationCSharpTraining
{
    class HomePage
    {
        private readonly IWebDriver _driver;
        //public List<IWebElement> LiTags;
        private readonly string HomeUrl = "https://yandex.by";
        private readonly By _loginLocator = By.XPath("//a[contains(@class,\"desk-notif-card__login-new-item_enter\")]");
        private readonly By _usernameLocator = By.ClassName("desk-notif-card__user-name");
        private readonly By _logoutLocator = By.XPath("//*[contains(text(),\"Выйти\")]");        


        public HomePage(IWebDriver driver)
        {
            _driver = driver;            
        }

        public HomePage URL()
        {
            _driver.Url = HomeUrl;
            return new HomePage(_driver);
        }            
        public IWebElement LoginLink => _driver.FindElement(_loginLocator);
        public IWebElement Username => _driver.FindElement(_usernameLocator);
        public IWebElement LogoutLink => _driver.FindElement(_logoutLocator);        

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
            LoginLink.Click();
            return new UsernamePage(_driver);
        }

        public bool IsLoggedIn(string username)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
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

        public void LogOut()
        {
            Username.Click();
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            LogoutLink.Click();
        }

        public void MakeHPScreenShot() 
        {
            _driver.MakeScreenShot();
        }
    }
}

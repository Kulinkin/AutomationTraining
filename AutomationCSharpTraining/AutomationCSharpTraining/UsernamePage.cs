using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomationCSharpTraining
{
    class UsernamePage
    {
        //
        IWebDriver _driver;

        private static readonly By _enterUsernameButtonLocator = By.XPath("//button[@id = 'passp:sign-in']");
        private static readonly By _usernameFieldLocator = By.Id("passp-field-login");
        private static readonly string _username1 = "iifortest";
        private static readonly string _username2 = "p4vtest";

        public IWebElement UsernameField { get; set; }
        public IWebElement EnterUsernameButton { get; set; }
        

        public UsernamePage(IWebDriver driver)
        {
            _driver = driver;
            UsernameField = _driver.FindElement(_usernameFieldLocator);
            EnterUsernameButton = _driver.FindElement(_enterUsernameButtonLocator);
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(condition =>
            {
                try
                {
                    if (UsernameField.Displayed && EnterUsernameButton.Displayed)
                    {
                        return true;
                    }
                    else return false;
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
        }

        public PasswordPage EnterUsername1()
        {
            UsernameField.Click();
            UsernameField.SendKeys(_username1);
            EnterUsernameButton.Click();
            return new PasswordPage(_driver);
        }

        public PasswordPage EnterUsername2()
        {
            UsernameField.Click();
            UsernameField.SendKeys(_username2);
            EnterUsernameButton.Click();
            return new PasswordPage(_driver);
        }
    }
}

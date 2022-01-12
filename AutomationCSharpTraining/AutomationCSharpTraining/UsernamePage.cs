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

        private readonly By _enterUsernameButtonLocator = By.XPath("//button[@id = 'passp:sign-in']");
        private readonly By _usernameFieldLocator = By.Id("passp-field-login");
        public string Username1 => "iifortest";
        public string Username2 => "p4vtest";

        public IWebElement UsernameField => _driver.FindElement(_usernameFieldLocator);
        public IWebElement EnterUsernameButton => _driver.FindElement(_enterUsernameButtonLocator);

        public UsernamePage(IWebDriver driver)
        {
            _driver = driver;            
        }

        public bool WaitUsernameFieldButton(IWebElement control)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            return wait.Until(condition =>
            {
                try
                {
                    return control.Displayed;                                                    
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

        public PasswordPage EnterUsername(String username)
        {
            UsernameField.Click();
            UsernameField.SendKeys(username);
            EnterUsernameButton.Click();
            return new PasswordPage(_driver);
        }        
    }
}

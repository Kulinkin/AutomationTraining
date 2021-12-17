using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationCSharpTraining
{
    class UsernamePage
    {
        IWebDriver _driver;
        const string EnterUsernameButtonLocator = "//button[@id = 'passp:sign-in']";
        const string UsernameFieldLocator = "passp-field-login";
        
        public IWebElement UsernameField { get; set; }
        public IWebElement EnterUsernameButton { get; set; }
        

        public UsernamePage(IWebDriver driver)
        {
            _driver = driver;
            UsernameField = _driver.FindElement(By.Id(UsernameFieldLocator));
            EnterUsernameButton = _driver.FindElement(By.XPath(EnterUsernameButtonLocator));
            

        }

        public void EnterUsername(string username)
        {
            UsernameField.Click();
            UsernameField.SendKeys(username);
            EnterUsernameButton.Click();
        }
    }
}

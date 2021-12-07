using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.Pages
{
    class EnterUsernamePage
    {
        IWebDriver _driver;
        const string EnterPasswordButtonLocator = "//button[@data-testid = 'enter-password']";
        const string UsernameFieldLocator = "//input[@name='login']";
        const string PasswordFieldLocator = "//input[@name='password']";
        public IWebElement UsernameField { get; set; }
        public IWebElement EnterPasswordButton { get; set; }
        public IWebElement PasswordField { get; set; }

        public EnterUsernamePage(IWebDriver driver)
        {
            _driver = driver;
            UsernameField = _driver.FindElement(By.XPath(UsernameFieldLocator));
            EnterPasswordButton = _driver.FindElement(By.XPath(EnterPasswordButtonLocator));
            PasswordField = _driver.FindElement(By.XPath(PasswordFieldLocator));

        }

        public void EnterUsername(string username)
        {
            UsernameField.Click();
            UsernameField.SendKeys(username);
            EnterPasswordButton.Click();
        }

       

    }

    
}

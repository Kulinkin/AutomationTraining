using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.Pages
{
    class EnterPasswordPage
    {
        IWebDriver _driver;
        
        const string PasswordFieldLocator = "//input[@name='password']";
        const string EnterButtonLocator = "//button[@data-testid = 'login-to-mail']";
        public IWebElement PasswordField { get; set; }
        public IWebElement EnterButton { get; set; }
        public EnterPasswordPage(IWebDriver driver)
        {
            _driver = driver;
            PasswordField = _driver.FindElement(By.XPath(PasswordFieldLocator));
            EnterButton = _driver.FindElement(By.XPath(EnterButtonLocator));
        }
        public void EnterPassword(string password)
        {
            PasswordField.Click();
            PasswordField.SendKeys(password);
            EnterButton.Click();
        }

    }
}

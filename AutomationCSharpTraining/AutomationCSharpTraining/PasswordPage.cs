using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationCSharpTraining
{
    class PasswordPage
    {
        //
        IWebDriver _driver;

        const string PasswordFieldLocator = "passwd";
        const string EnterButtonLocator = "//button[@id=\"passp:sign-in\"]";
        public IWebElement PasswordField { get; set; }
        public IWebElement EnterButton { get; set; }
        public PasswordPage(IWebDriver driver)
        {
            _driver = driver;
            PasswordField = _driver.FindElement(By.Name(PasswordFieldLocator));
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

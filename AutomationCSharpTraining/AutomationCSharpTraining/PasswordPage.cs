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
        IWebDriver _driver;

        private readonly By _passwordField = By.Name("passwd");
        private readonly By _enterButton = By.XPath("//button[contains(@id,\"sign-in\")]");
        public string CommonPassword => "1wsx@QAZ";

        IWebElement PasswordField => _driver.FindElement(_passwordField);
        IWebElement EnterButton => _driver.FindElement(_enterButton);        
        public PasswordPage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);     
        }
        public HomePage EnterPassword(string password)
        {
            PasswordField.Click();
            PasswordField.SendKeys(password);
            EnterButton.Click();
            return new HomePage(_driver);
        }
    }
}

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

        private static readonly By _passwordField = By.Name("passwd");
        private static readonly By _enterButton = By.XPath("//button[contains(@id,\"sign-in\")]");
        private static readonly string _commonPassword = "1wsx@QAZ";

        public IWebElement PasswordField { get; set; }
        public IWebElement EnterButton { get; set; }
        public PasswordPage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            PasswordField = _driver.FindElement(_passwordField);
            EnterButton = _driver.FindElement(_enterButton);


        }
        public HomePage EnterPassword()
        {
            PasswordField.Click();
            PasswordField.SendKeys(_commonPassword);
            EnterButton.Click();
            return new HomePage(_driver);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationCSharpTraining
{
    class MailPage
    {
        IWebDriver _driver;

        const string MailPageUsernameLocator = "desk-notif-card__user-name";
        
        public IWebElement MailPageUsername { get; set; }
        public MailPage(IWebDriver driver)
        {
            _driver = driver;
            MailPageUsername = _driver.FindElement(By.ClassName(MailPageUsernameLocator));
            
        }
        public bool IsLoggedIn(string username)
        {
            
            MailPageUsername.FindElement(By.XPath("//span[text()='" + username + "']"));
            return MailPageUsername.Displayed;
        }
    }
}

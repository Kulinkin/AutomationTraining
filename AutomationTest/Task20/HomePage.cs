using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task20
{
    class HomePage
    {
        IWebDriver _driver;
        const string MailLink = "//a[@href='/inbox/']/div/div/span/span";

        IReadOnlyCollection<IWebElement> NewList { get; set; }

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            NewList = _driver.FindElements(By.XPath(MailLink));
        }

        public List<string> GetNumberOfUnread()
        {
            return NewList.Select(x => x.Text).ToList();
        }
    }
}

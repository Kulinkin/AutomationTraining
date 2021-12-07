using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.Pages
{
    class MessagesPage
    {
        IWebDriver _driver;
        const string NumberOfUnreadLocator = "//a[@href='/inbox/']/div/div/span/span";

        IReadOnlyCollection<IWebElement> NewList { get; set; }

        public MessagesPage (IWebDriver driver)
        {
            _driver = driver;
            NewList = _driver.FindElements(By.XPath(NumberOfUnreadLocator));
        }

        public List<string> GetNumberOfUnread()
        {
            return NewList.Select(x => x.Text).ToList();
        }
    }
}

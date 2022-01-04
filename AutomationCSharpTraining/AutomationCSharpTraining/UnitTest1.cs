using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace AutomationCSharpTraining
{
    public class Tests
    {
        private IWebDriver driver;
        private static readonly By fiftyPercentElement = By.XPath("//div[contains(text(),\"50%\")]");
        private static readonly By downloadButton = By.XPath("//*[@id=\"cricle-btn\"]");  
        private static readonly By whenFiftyPercentAppearsElement = By.XPath("//*[contains(@class,\"clipauto\")]");//can be used as alternative solution
        private static readonly By zeroPercentElement = By.XPath("//div[contains(text(),\"0%\")]"); 

        [SetUp]
        public void Setup()
        {
            
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void SuccessfullLogin()
        {
            
            HomePage homePage = new HomePage(driver);
            homePage.URL();
            Thread.Sleep(2000);  //I think it is more like implicit waiter as the element which should be displayed is not indicated explicitly

            UsernamePage usernamePage = homePage.EnterLoginPage();
            PasswordPage passwordPage = usernamePage.EnterUsername1();
            homePage = passwordPage.EnterPassword();
            //Username is displayed in user card if logged in successfully
            Assert.IsTrue(homePage.IsLoggedIn("ifortest"));

            driver.Quit();
        }
        [Test]
        public void SuccessfullLogin2()
        {

            HomePage homePage = new HomePage(driver);
            homePage.URL();
            UsernamePage usernamePage = homePage.EnterLoginPage();
            PasswordPage passwordPage = usernamePage.EnterUsername2();
            homePage = passwordPage.EnterPassword();
            //Username is displayed in user card if logged in successfully
            Assert.IsTrue(homePage.IsLoggedIn("4vtest"));      

            driver.Quit();
        }
        [Test]
        public void RefreshDuringDownload()
        {            
            driver.Url= "https://demo.seleniumeasy.com/bootstrap-download-progress-demo.html";
            var DownloadButton = driver.FindElement(downloadButton);
            //click download button
            DownloadButton.Click();            
            //wait till 50% appears using explicit waiter
            var explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = explicitWait.Until(condition =>
            {
                try
                {
                    var FiftyPercent = driver.FindElement(fiftyPercentElement);
                    return FiftyPercent.Displayed;
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
            //refresh page
            driver.Navigate().Refresh();
            //check that the page is refreshed
            Assert.IsTrue(driver.FindElement(zeroPercentElement).Displayed);
            driver.Quit();
        }
        [Test]
        public void FilterByMinAgeMaxSalary()
        {
            TableSortPage tableSort = new TableSortPage(driver);
            //choose 10 values in entries drop-down
            tableSort.EntriesDropdown.SelectByText("10");
            //filter
            var FilteredList = tableSort.ByMinAgeMaxSalary(50, 200000);
            //verify that such users exist (as an example of verification)
            Assert.IsTrue(FilteredList.Count()>0);
            driver.Quit();
        }
    }
}
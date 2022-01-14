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
            usernamePage.WaitUsernameFieldButton(usernamePage.UsernameField);
            PasswordPage passwordPage = usernamePage.EnterUsername(usernamePage.Username1);
            homePage = passwordPage.EnterPassword(passwordPage.CommonPassword);
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
            PasswordPage passwordPage = usernamePage.EnterUsername(usernamePage.Username2);
            homePage = passwordPage.EnterPassword(passwordPage.CommonPassword);
            //Username is displayed in user card if logged in successfully
            Assert.IsTrue(homePage.IsLoggedIn("4vtest"));      

            driver.Quit();
        }
        [Test]
        public void Multiselect()
        {
            driver.Url = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
            SelectElement multiDropDown = new SelectElement(driver.FindElement(By.Id("multi-select")));
            //select 3 options 
            multiDropDown.SelectByText("New York");
            multiDropDown.SelectByText("California");
            multiDropDown.SelectByText("Pennsylvania");
            //collect all options
            var selectedOptions = multiDropDown.AllSelectedOptions;
            //verify 3 options are chosen
            Assert.AreEqual(3, selectedOptions.Count);
            driver.Quit();
        }
        [Test]
        public void WaitUser()
        {
            driver.Url = "https://demo.seleniumeasy.com/dynamic-data-loading-demo.html";
            IWebElement getUserButton = driver.FindElement(By.Id("save"));
            getUserButton.Click();
            //wait until loading... disapear
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));            
            var UserAreaElement = wait.Until(condition =>
            {
                try
                {
                    var UserArea = driver.FindElement(By.XPath("//div[@id=\"loading\"]"));
                    //get all text from User Area
                    string UserAreaText = UserArea.Text.ToString();
                    bool loadingIsDisplayed = UserAreaText.Contains("loading");                    
                    return !loadingIsDisplayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            var Image = driver.FindElement(By.XPath("//div[@id=\"loading\"]/img"));
            var UserArea = driver.FindElement(By.XPath("//div[@id=\"loading\"]"));
            string UserAreaText = UserArea.Text.ToString();
            //passed if all 3 elements are displayed
            Assert.IsTrue(UserAreaText.Contains("First Name") && UserAreaText.Contains("Last Name") && Image.Displayed, "User is not loaded");
            driver.Quit();
        }
        
        [Test]
        public void Alert()
        {
            driver.Url = "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";
            var lounchAlert = driver.FindElement(By.XPath("//button[@onclick=\"myAlertFunction()\"]"));
            lounchAlert.Click();
            IAlert alert = driver.SwitchTo().Alert();            
            alert.Dismiss();
            //check that alert is dismissed
            Assert.That(() => driver.SwitchTo().Alert(), Throws.TypeOf<NoAlertPresentException>());            
            driver.Quit();
        }
        [Test]
        public void CanceltConfirmBox()
        {
            driver.Url = "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";
            var lounchConfirmBox = driver.FindElement(By.XPath("//button[@onclick=\"myConfirmFunction()\"]"));
            lounchConfirmBox.Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Dismiss();
            //check that alert is dismissed
            Assert.That(() => driver.SwitchTo().Alert(), Throws.TypeOf<NoAlertPresentException>());
            //check that after combo box is cancelled appears corresponding text
            Assert.IsTrue(driver.FindElement(By.XPath("//p[@id=\"confirm-demo\"]")).Text.Contains("Cancel"));            
            driver.Quit();
        }
        [Test]
        public void AcceptConfirmBox()
        {
            driver.Url = "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";
            var lounchConfirmBox = driver.FindElement(By.XPath("//button[@onclick=\"myConfirmFunction()\"]"));
            lounchConfirmBox.Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            //check that alert is accepted
            Assert.That(() => driver.SwitchTo().Alert(), Throws.TypeOf<NoAlertPresentException>());
            //check that after combo box is accepted appears corresponding text
            Assert.IsTrue(driver.FindElement(By.XPath("//p[@id=\"confirm-demo\"]")).Text.Contains("OK"));            
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
            explicitWait.PollingInterval = TimeSpan.FromMilliseconds(100);
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
            try
            {
                Assert.IsTrue(FilteredList.Count > 0, "Filtered list doesn't contain any elements");
            }
            catch(Exception)
            {
                Console.WriteLine("Exception when counting filtered users");
            }
            driver.Quit();
        }
        [Test]
        public void Logout()
        {
            HomePage homePage = new HomePage(driver);
            homePage.URL();
            //make screenshot
            homePage.MakeHPScreenShot();
            UsernamePage usernamePage = homePage.EnterLoginPage();
            usernamePage.WaitUsernameFieldButton(usernamePage.UsernameField);
            PasswordPage passwordPage = usernamePage.EnterUsername(usernamePage.Username1);
            homePage = passwordPage.EnterPassword(passwordPage.CommonPassword);            
            //Open user menu. Switch to user menu and cick logout element
            homePage.LogOut();
            //Login link is displayed if successfully logged out
            Assert.IsTrue(homePage.LoginLink.Displayed);
            driver.Quit();
        }
    }
}
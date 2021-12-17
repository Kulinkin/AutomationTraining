using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;


namespace AutomationCSharpTraining
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito");
            driver = new ChromeDriver(options);
        }

        [Test]
        public void SuccessfullLogin()
        {
            
            driver.Url = "https://yandex.by";
            HomePage homePage = new HomePage(driver);
            Thread.Sleep(2000);            

            homePage.EnterMailLoginPage();
            Thread.Sleep(2000);

            UsernamePage usernamePage = new UsernamePage(driver);
            usernamePage.EnterUsername("iifortest");
            Thread.Sleep(2000);

            PasswordPage passwordPage = new PasswordPage(driver);
            passwordPage.EnterPassword("1wsx@QAZ");

            Thread.Sleep(5000);

            MailPage mailPage = new MailPage(driver);
            
            Assert.IsTrue(mailPage.IsLoggedIn("ifortest"));

            driver.Close();
        }
    }
}
using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using Selenium.Pages;

namespace Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito");
            options.AddArguments("--start-maximized");

            IWebDriver driver = new ChromeDriver(options);
            driver.Url = "https://mail.ru";
            
            EnterUsernamePage homePage = new EnterUsernamePage(driver);
            homePage.EnterUsername("goofyrulit");
            Thread.Sleep(2000);
            EnterPasswordPage passwordPage = new EnterPasswordPage(driver);
            passwordPage.EnterPassword("1wsx@QAZ");
            Thread.Sleep(2000);
            MessagesPage messagePage = new MessagesPage(driver);
            var unreadList = messagePage.GetNumberOfUnread();


            /*var usernameField = driver.FindElement(By.XPath("//input[@name='login']"));
            usernameField.Click();
            usernameField.SendKeys("goofyrulit");

            var nextButton = driver.FindElement(By.XPath("//button[@data-testid = 'enter-password']"));
            nextButton.Click();

            var passwordField = driver.FindElement(By.XPath("//input[@name='password']"));
            Thread.Sleep(2000);
            passwordField.Click();
            passwordField.SendKeys("1wsx@QAZ");
            nextButton = driver.FindElement(By.XPath("//button[@data-testid = 'login-to-mail']"));
            nextButton.Click();

            Thread.Sleep(2000);

            var unreadInIncoming = driver.FindElements(By.XPath("//a[@href='/inbox/']/div/div/span/span"));

            var numberOfUnread = unreadInIncoming.Select(x => x.Text).ToList();


            /*
            driver.Url = "https://mail.google.com/mail/?tab=rm&ogbl";
            var usernameField = driver.FindElement(By.XPath("//input"));
            usernameField.Click();
            usernameField.SendKeys("kulinkin.a.v@gmail.com");
            //usernameField.SendKeys("youjeepkrabs@gmail.com");

            var nextButton = driver.FindElement(By.XPath("//button"));
            nextButton.Click();

            Thread.Sleep(2000);

            var additionalField = driver.FindElement(By.XPath("//input"));
            //additionalField.Click();
            additionalField.SendKeys("+375298923637");
            nextButton.Click();
            

            var passwordField = driver.FindElement(By.Id("password"));
            passwordField.Click();
            passwordField.SendKeys("1wsx@QAZ");
            nextButton.Click();
            */


            //Console.WriteLine("Hello World!");

            driver.Close();

        }
    }
}

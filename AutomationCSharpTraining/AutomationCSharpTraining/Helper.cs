using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationCSharpTraining
{
    static class Helper
    {
        public static void MakeScreenShot(this IWebDriver driver)
        {   
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("./ScreenShot_Folder/Test1_Login.png", ScreenshotImageFormat.Png);
        }  
    }
}

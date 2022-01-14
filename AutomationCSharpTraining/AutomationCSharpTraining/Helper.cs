using OpenQA.Selenium;
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
            ss.SaveAsFile("C:/SS/Screenshot.png", ScreenshotImageFormat.Png);
        }

    }
}

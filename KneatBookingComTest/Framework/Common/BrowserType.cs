using System;
using KneatBookingComTest.Framework.SetUp;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace KneatBookingComTest.Framework.Common
{
    public class BrowserType
    {
        private static IWebDriver Driver;
        public static IWebDriver Initialize()
        {
            String BrowserType = TestBase.BaseBrowser;
            switch (BrowserType)
            {
                case "Chrome":
                    Driver = new ChromeDriver();
                    break;
                case "Firefox":
                    Driver = new FirefoxDriver();
                    break;
                default:
                    Console.WriteLine("No Browser found");
                    break;

            }
            return Driver;
        }
    }
}

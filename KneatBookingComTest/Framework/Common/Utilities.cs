using System;
using System.Diagnostics;
using System.Threading;
using KneatBookingComTest.Framework.POM;
using KneatBookingComTest.Framework.SetUp;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace KneatBookingComTest.Framework.Common
{
    public class Utilities
    {
        public static void OpenUrl(IWebDriver Driver)
        {
            Driver.Navigate().GoToUrl(TestBase.BaseUrl);
            Driver.Manage().Window.Maximize();
        }

        
        public static void WaitandClickID(IWebDriver Driver, string Element, int SleepTime=3)
        {
            var webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(SleepTime));
            webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(Element)));
            Driver.FindElement(By.Id(Element)).Click();

        }
        public static void WaitandClickXpath(IWebDriver Driver, string Element, int SleepTime = 5)
        {
            var webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(SleepTime));
            webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Element)));
            Driver.FindElement(By.XPath(Element)).Click();

        }
        public static void WaitandClickCSSSelector(IWebDriver Driver, string Element, int SleepTime = 3)
        {
            var webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(SleepTime));
            webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(Element)));
            Driver.FindElement(By.CssSelector(Element)).Click();

        }

        public static void WaitandSendInputID(IWebDriver Driver, string ElementID,string InputValue)
        {
            var Element = Driver.FindElement(By.Id(ElementID));
            Element.Click();
            Element.SendKeys(InputValue);
            Thread.Sleep(2000);

        }
        public static void WaitandSendInputXpath(IWebDriver Driver, string ElementID, string InputValue)
        {
           
            var Element = Driver.FindElement(By.XPath(ElementID));
            Element.Click();
            Element.SendKeys(InputValue);
            Thread.Sleep(2000);

        }

        // Move the focus to an element on the page.
        public static void MoveToElement(IWebDriver Driver, string Element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");

            var element = Driver.FindElement(By.Id(Element));
            Actions actions = new Actions(Driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public static void VerifyTextXpath(IWebDriver Driver, string ElementID,string ActualText, string FalseText)
        {
            string ExpectedText = Driver.FindElement(By.XPath(ElementID)).Text;
            Debug.WriteLine(ExpectedText);
            Thread.Sleep(5000);
            Assert.Equal(ActualText, ExpectedText);
            Assert.DoesNotMatch(ActualText, FalseText);


        }
        public static void WaitAndClickEitherXpath(IWebDriver Driver, string FirstElementID, string SecondElementID)
        {
            string ButtonText = Driver.FindElement(By.XPath(FirstElementID)).Text;
            //string SecondButtonText = Driver.FindElement(By.XPath(SecondElementID)).Text;
            //Debug.WriteLine(FirstButtonText);
            //Debug.Write(SecondButtonText);

            if( ButtonText.Contains("Show all 13"))
            {
                var FirstXpath = Driver.FindElement(By.XPath(FirstElementID));
                FirstXpath.Click();
                //WaitandClickXpath(Driver, HomePage.SpaAndWellnessXpath);

            }
            else if(ButtonText.Contains("Show more"))
            {
                var SecondXpath = Driver.FindElement(By.XPath(SecondElementID));
                SecondXpath.Click();
                WaitandSendInputXpath(Driver, HomePage.ShowAllFilterEnterInputXpath,"spa and");
                WaitandClickXpath(Driver, HomePage.SpaAndWellnessCenterXpath);
                WaitandClickXpath(Driver, HomePage.ApplyFilterXpath);
            }
            else
            {
                WaitandClickXpath(Driver, HomePage.SpaAndWellnessXpath);
                
            }

        }
        


    }
}

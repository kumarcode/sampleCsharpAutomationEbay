using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;

namespace Ebay.Global
{
    public static class Driver
    {
        public static IWebDriver driver { get; set; }

        #region Wait for Element
        public static void wait(int time)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(time));
        } 

        public static IWebElement WaitForElement(IWebDriver driver, By by,int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(ExpectedConditions.ElementIsVisible(by)));
        }
        #endregion

        #region Element Present
        public static bool isElementPresent(By by)
        {
            try
            {
                Driver.driver.FindElement(by);
                return true;
            }
            catch(NoSuchElementException)
            {
                return false;
            }
            
        }

        #endregion

        #region On Page
        public static void isOnPage(string pageTitle)
        {
            try
            {
                Assert.AreEqual(pageTitle, Driver.driver.Title);
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Navigated to" + pageTitle + "page successfully");
            }
            catch (AssertionException)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Navigation failed to" + pageTitle + "page");
                throw;
            }
           
        }

        #endregion
    }   
}
    
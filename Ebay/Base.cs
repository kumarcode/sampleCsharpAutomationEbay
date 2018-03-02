
using Ebay.Global;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebay
{
    public abstract class Base
    {

        #region To access path from resource file

        public static int Browser = Int32.Parse(EbayResource.Browser);
        public static string ReportPath = EbayResource.ReportPath;
        public static string ScreenshotPath = EbayResource.ScreenShotPath;

        #endregion

        #region reports

        public static ExtentTest test;
        public static ExtentReports extent;

        #endregion

        #region Setup and Tear down
        [SetUp]
        public void Initialize()
        {
            switch (Browser)
            {
                case 1:
                    Driver.driver = new FirefoxDriver();
                    Driver.driver.Manage().Window.Maximize();
                    break;
                case 2:
                    Driver.driver = new ChromeDriver();
                    Driver.driver.Manage().Window.Maximize();
                    break;
            }

            // Instance for Login
            Login loginObj = new Login();
            loginObj.LoginSuccessful();

            extent = new ExtentReports(ReportPath, true, DisplayOrder.NewestFirst);
            extent.LoadConfig(EbayResource.ReportXmlPath);
        }
        [TearDown]
        public void TearDown()
        {
            // Screenshot
            String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
            test.Log(LogStatus.Info, "Image example: " + img);
                        
            // End Test
            extent.EndTest(test);

            // Calling flush writes everything to Log file(Reports)
            extent.Flush();

            // Close the driver
            Driver.driver.Close();
        }
        #endregion
    }
    }


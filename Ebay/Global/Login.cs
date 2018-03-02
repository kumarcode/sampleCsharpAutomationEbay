using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebay.Global
{
    class Login
    {
        internal Login()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        private const string pageTitle = "Electronics, Cars, Fashion, Collectibles, Coupons and More | eBay";

        [FindsBy(How = How.XPath, Using = ".//*[@id='gh-ug']/a")]
        private IWebElement lnkSignin { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='userid']")]
        private IWebElement strUserId { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='pass']")]
        private IWebElement strPassword { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='sgnBt']")]
        private IWebElement btnSignin { get; set; }

        internal void LoginSuccessful()
        {
                Driver.driver.Navigate().GoToUrl("https://www.ebay.com.au/");
                lnkSignin.Click();
                strUserId.SendKeys("rumyathiru@gmail.com");
                strPassword.SendKeys("qwerty@12");
                btnSignin.Click();         
        }
    }
}

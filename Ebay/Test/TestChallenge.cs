using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebay.Test
{
    class TestChallenge
    {
        [TestFixture]
        class TestChallenge1 : Base
        {
            [Test]
            public void LoginTest()
            {
                try
                {
                    test = extent.StartTest("Login Test");
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed");
                }
                catch (Exception)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed");
                    throw;
                }
            }

        }
    }
}

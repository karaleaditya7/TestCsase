using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InflueriAutomation.Utils;
using InflueriAutomation.Models;
using InflueriAutomation.Pages;
using InflueriAutomation.Providers;
using NUnit.Framework.Internal;
using NUnit.Framework;
using OpenQA.Selenium;
using WebDriverManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;
using NLog.Fluent;
using NLog;
using Logger = NLog.Logger;
using AventStack.ExtentReports;
using System.Threading;

namespace InflueriAutomation.Core
{
    [TestClass]
    public class Initializer : BaseTestPage
    {
        static IWebDriver driver;
        public TestContext TestContext { get; set; }
        static ExtentReports extentReports;
        public ExtentTest extentTest;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            Console.WriteLine("***************Logs genrating on path /bin/debug**************************");
            Logger.Info("Initialising extent report config");
            extentReports = ExtentReportUtils.CreateInstance();

        }

        [TestInitialize]
        public void BeforeMethod()
        {
            Logger.Info("Creating extent test");
            extentTest = extentReports.CreateTest(TestContext.TestName, TestContext.TestName);
            ExtentTestLogger = extentTest;

            Logger.Info("Initialising driver instance for test method");
            driver = DriverUtils.CreateDriverInstance(ConfigurationProvider.WebDriverConfig);
            DriverUtils.InitDriver(driver);
 

        }

        [TestCleanup]
        public void AfterMethod()
        {
            afterMethod();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Logger.Info("Flushing extent report");
            extentReports.Flush();
            Logger.Info("Flushing Nlog");
            LogManager.Flush();

        }

        private void afterMethod()
        {             
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                Logger.Info("Failing the step in extent report");

                int currentStepNum = ExtentTestLogger.Model.LogContext.Count;
                ExtentTestLogger.Model.LogContext.Get(currentStepNum-1).Status = Status.Fail;
                ExtentTestLogger.Fail("Test failed, check the logs for more details");
            }

            Logger.Info("Deinitialising driver instance for test method");
            DriverUtils.DeInitDriver(DriverUtils.GetPrimaryWebDriver());
        }
    }
}

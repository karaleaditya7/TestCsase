using System.Collections.Generic;
using System.IO;
using System.Threading;
using InflueriAutomation.Utils;
using InflueriAutomation.Models;
using InflueriAutomation.Pages;
using InflueriAutomation.Providers;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace InflueriAutomation.Tests
{
    public abstract class BaseTest<TTestedAppPage>
    {
        public void SetupBeforeEverySingleTest()
        {
            User = DataProvider.Load<User>("User");

            var driverConfig = ConfigurationProvider.WebDriverConfig;
            var logger = new Logger("logger", InternalTraceLevel.Info, TextWriter.Null);
            driver = new WebDriverFactory().GetWebDriver(driverConfig, logger);
            

            TestedPageOrWindow = SelectTestedAppPage();
        }

        public void CleanUpAfterEverySingleTest()
        {
            
            driver.Quit();
        }

        protected abstract TTestedAppPage SelectTestedAppPage();

        protected TTestedAppPage TestedPageOrWindow { get; set; }
        protected User User { get; private set; }

        private IWebDriver driver;
    }
}
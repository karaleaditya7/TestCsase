using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InflueriAutomation.Enums;
using InflueriAutomation.Utils;
using InflueriAutomation.Providers;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.DriverConfigs;
using WebDriverManager;
using InflueriAutomation.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Threading;
using AngleSharp.Io;

namespace InflueriAutomation.Utils
{
    public class DriverUtils { 


       private static ThreadLocal<IWebDriver> webDriver = new ThreadLocal<IWebDriver>();

        public static void SetPrimaryWebDriver(IWebDriver driver)
        {
            webDriver.Value = driver;
        }

        public static IWebDriver GetPrimaryWebDriver()
        {
            return webDriver.Value;
        }

        public static void InitDriver(IWebDriver driver)
        {
            SetPrimaryWebDriver(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigurationProvider.WebDriverConfig.DefaultTimeout);
            driver.Navigate().GoToUrl(ConfigurationProvider.EnvConfig.ApplicationUrl);
        }
        public static void DeInitDriver(IWebDriver driver)
        {
            driver.Dispose();
            driver.Quit();
        }

        public static IWebDriver CreateDriverInstance(WebDriverConfiguration driverConfig)
        {
            switch (driverConfig.BrowserName)
            {
                case BrowserName.Chrome:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    return new ChromeDriver(WebDriverSettings.ChromeOptions(driverConfig));
                case BrowserName.Firefox:
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    return new FirefoxDriver(WebDriverSettings.FirefoxOptions(driverConfig));
                case BrowserName.IE:
                    new DriverManager().SetUpDriver(new InternetExplorerConfig());
                    return new InternetExplorerDriver(WebDriverSettings.InternetExplorerOptions());
                case BrowserName.Edge:
/*                    new DriverManager().SetUpDriver(new EdgeConfig());
                    return new EdgeDriver(WebDriverSettings.EdgeOptions());*/
                default:
                    throw new ArgumentOutOfRangeException(nameof(ConfigurationProvider.WebDriverConfig.BrowserName),
                        ConfigurationProvider.WebDriverConfig.BrowserName,
                        null);
            }
        }
 
    }
}

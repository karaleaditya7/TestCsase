﻿using System;
using InflueriAutomation.Enums;
using InflueriAutomation.Models;
using InflueriAutomation.Providers;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Chrome;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace InflueriAutomation.Utils
{
    public class WebDriverFactory
    {
        
        public WebDriverListener GetWebDriver(WebDriverConfiguration driverConfig, Logger logger)
        {
            switch (driverConfig.BrowserName)
            {
                case BrowserName.Chrome:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    var chromeDriver = new ChromeDriver(WebDriverSettings.ChromeOptions(driverConfig));
                    return new WebDriverListener(chromeDriver, logger);
                case BrowserName.Firefox:
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    var firefoxDriver = new FirefoxDriver(WebDriverSettings.FirefoxOptions(driverConfig));
                    return new WebDriverListener(firefoxDriver, logger);
                case BrowserName.IE:
                    new DriverManager().SetUpDriver(new InternetExplorerConfig());
                    var ieDriver = new InternetExplorerDriver(WebDriverSettings.InternetExplorerOptions());
                    return new WebDriverListener(ieDriver, logger);
                case BrowserName.Edge:
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    var edgeDriver = new EdgeDriver(WebDriverSettings.EdgeOptions());
                    return new WebDriverListener(edgeDriver, logger);
                default:
                    throw new ArgumentOutOfRangeException(nameof(ConfigurationProvider.WebDriverConfig.BrowserName),
                        ConfigurationProvider.WebDriverConfig.BrowserName,
                        null);
            }
        }
    }
}

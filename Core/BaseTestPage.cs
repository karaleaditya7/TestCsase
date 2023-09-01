using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Html5;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using AngleSharp.Dom;
using NUnit.Framework.Internal;
using System.Threading;
using InflueriAutomation.Utils;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using NLog;
using AventStack.ExtentReports;
using Logger = NLog.Logger;
using WebDriverManager;
using System.IO;
using AventStack.ExtentReports.Configuration;
using InflueriAutomation.Providers;
using OpenQA.Selenium.Interactions;
using Microsoft.CodeAnalysis;
using InflueriAutomation.Enums;

namespace InflueriAutomation.Core
{
    public class BaseTestPage
    {
        private const int MaxTimeoutInSec = 120;
        private const int ExistCheckMaxTimeoutSec = 5;
        private const int PollingIntervalMiliSec = 250;
        public static ExtentTest ExtentTestLogger { get; set; }
        public static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        protected IWebDriver GetWebDriver()
        {
            return DriverUtils.GetPrimaryWebDriver();
        }
        protected void Click(By locator)
        {
            Logger.Info("Clicking the element with locator : " + locator.ToString());
            IWebElement element = FindElementCustom(locator);
            Click(MaxTimeoutInSec, element);
        }

        protected void ClickByJavaScript(By locator)
        {
            Logger.Info("Clicking the element with locator : " + locator.ToString());

            IWebElement element = FindElementCustom(locator);

            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)GetWebDriver();
            jsExecutor.ExecuteScript("arguments[0].click();", element);
        }

        protected void Click(IWebElement element)
        {
            Logger.Info("Clicking the element with locator : " + element.ToString());
            Click(MaxTimeoutInSec, element);
        }

        protected void SetValue(string value, By locator)
        {
            Logger.Info("Entering the value: " + value + " in the text box with locator: " + locator.ToString());

            IWebElement element = FindElementCustom(locator);
            WebDriverWait wait = new WebDriverWait(GetWebDriver(), TimeSpan.FromSeconds(MaxTimeoutInSec));

            wait.Until(ExpectedConditions.ElementIsVisible(locator)).Clear();
            element.SendKeys(value);
        }


        protected void SetValue(long value, By locator)
        {
            Logger.Info("Entering the value: " + value + " in the text box with locator: " + locator.ToString());

            IWebElement element = FindElementCustom(locator);
            WebDriverWait wait = new WebDriverWait(GetWebDriver(), TimeSpan.FromSeconds(MaxTimeoutInSec));

            wait.Until(ExpectedConditions.ElementIsVisible(locator)).Clear();
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(value.ToString());
        }


        protected void SelectValueFromList(String value, By locator)
        {
            Logger.Info("Selecting the value : " + value + " in drop down with locator : " + locator.ToString());
            IWebElement element = FindElementCustom(locator);
            FluentWait(MaxTimeoutInSec)
                .Until(ExpectedConditions.ElementToBeClickable(element));
            new SelectElement(element).SelectByText(value);
        }

        protected IWebElement FindElementCustom(By locator)
        {
            Logger.Info("Finding element using locator : " + locator.ToString());
            return FindElement(MaxTimeoutInSec, locator);
        }

        protected IWebElement FindElementCustom(By locator, long timeoutInSec)
        {
            Logger.Info("Finding element using locator : " + locator.ToString()+ "in "+ timeoutInSec + "duration");
            return FindElement(timeoutInSec, locator);
        }

        protected IWebElement FindElement(long timeout, By locator)
        {
            Logger.Info("Finding element using locator : " + locator.ToString() + "in " + timeout + "duration");
            WaitUntilElementIsPresent(timeout, locator);
            return GetWebDriver().FindElement(locator);
        }

        protected IList<IWebElement> FindElements(By locator)
        {
            Logger.Info("Finding elements using locator: " + locator.ToString() + " in " + ExistCheckMaxTimeoutSec + " duration");
            WaitUntilElementIsPresent(ExistCheckMaxTimeoutSec, locator);
            return new List<IWebElement>(GetWebDriver().FindElements(locator));
        }

        protected IWebElement WaitUntilElementIsPresent(long timeout, By by)
        {
            Logger.Info("Waiting for element with locator : " + by.ToString() + "to be present");
            return FluentWait(timeout)
                .Until(ExpectedConditions.ElementExists(by));
        }

        protected IWebElement WaitUntilElementIsPresent(By by)
        {
            Logger.Info("Waiting for element with locator : " + by.ToString() + "to be present");
            return FluentWait(MaxTimeoutInSec)
                .Until(ExpectedConditions.ElementExists(by));
        }

        private void Click(long timeout, IWebElement element)
        {
            Logger.Info("Clicking the element with WebElement : " + element.ToString());
            FluentWait(timeout).Until(ExpectedConditions.ElementToBeClickable(element));
            element.Click();
        }

        private DefaultWait<IWebDriver> FluentWait(long timeoutSec)
        {
            Logger.Info("Fluent wait with polling and ignoring NosuchElement Exception");
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(GetWebDriver());
            fluentWait.Timeout = TimeSpan.FromSeconds(timeoutSec);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(PollingIntervalMiliSec);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return fluentWait;
        }

        protected Boolean IsElementExist(By locator)
        {
            Logger.Info("Checking if element exists");
            try{
                FindElementCustom(locator);
                return true;
            }
            catch (NoSuchElementException){
                return false;
            }
        }

        protected Boolean IsElementVisible(By locator)
        {
            Logger.Info("Checking if element is visible");
            IWebElement element = FindElementCustom(locator, ExistCheckMaxTimeoutSec);
            FluentWait(ExistCheckMaxTimeoutSec).Until(ExpectedConditions.ElementIsVisible(locator));
            return element.Displayed;
        }

        protected bool IsElementNotVisible(By locator)
        {
            Logger.Info("Checking if element is not visible");
            try
            {
                // Use ExpectedConditions.InvisibilityOfElementLocated directly to check invisibility
                FluentWait(ExistCheckMaxTimeoutSec).Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
                return true; // If the condition is met, the element is not visible
            }
            catch (NoSuchElementException)
            {
                // If the element is not found, it is not visible
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                // If the element is still visible after the timeout, return false
                return false;
            }
        }

        private BaseTestPage StaticWait(int secs)
        {
            try
            {
                Logger.Info("Static wait for " + secs + " Seconds");
                Thread.Sleep(secs * 1000);
            }
            catch (ThreadInterruptedException e)
            {
                Logger.Error(e.Message);
            }
            Logger.Info("Finished static wait " + secs + " Seconds");
            return this;
        }

        protected void ShortWait()
        {
            Logger.Info("Waiting for short time");
            StaticWait(ConfigurationProvider.WaitConfig.ShortWait);
        }

        protected void MediumWait()
        {
            Logger.Info("Waiting for medium time");
            StaticWait(ConfigurationProvider.WaitConfig.MediumWait);
        }

        protected void LongWait()
        {
            Logger.Info("Waiting for long time");
            StaticWait(ConfigurationProvider.WaitConfig.LongWait);
        }

        protected void ScrollToElement(By Locator)
        {
            Logger.Info("Scrolling upto the " + Locator.ToString()+ " element");
            IWebElement element = FindElementCustom(Locator);
            ((IJavaScriptExecutor)GetWebDriver()).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        protected void HitTabButton(By Locator)
        {
            Logger.Info("Hitting Tab Button ");
            IWebElement element = FindElementCustom(Locator);
            Actions actions = new Actions(GetWebDriver());
            actions.SendKeys(element, Keys.Tab).Perform();
        }

        protected void HitEnterButton(By locator)
        {
            Logger.Info("Hitting Enter Button");
            Actions actions = new Actions(GetWebDriver());
            actions.SendKeys(FindElementCustom(locator), Keys.Enter).Perform();
        }

        protected void HitControlClick(By locator)
        {
            Logger.Info("Hitting Enter Button");
            Actions actions = new Actions(GetWebDriver());
            actions.KeyDown(Keys.Control).Click(FindElementCustom(locator)).KeyUp(Keys.Control).Perform();
        }

        protected void SwitchToIframe(By locator)
        {
            Logger.Info("Switching to IFrame");
            IWebElement iframeElement = FindElementCustom(locator);
            GetWebDriver().SwitchTo().Frame(iframeElement);
        }


        protected String GetText(By locator)
        {
            Logger.Info("Getting Text of the "+locator.ToString()+" Element");
            return FindElementCustom(locator).Text;
        }

        protected String GetText(IWebElement element)
        {
            Logger.Info("Getting Text of the " + element.ToString() + " Element");
            return element.Text;
        }

        protected String GetAttributeByValue(String attributeName, IWebElement element)
        {
            Logger.Info("Getting " + attributeName + " value from " + element.ToString() + " element");
            return element.GetAttribute(attributeName);
        }

        protected String GetAttributeByValue(String attributeName, By locator)
        {
            Logger.Info("Getting " + attributeName + " value from " + locator.ToString() + " element");
            return GetAttributeByValue(attributeName, FindElementCustom(locator));
        }

        protected bool IsElementClickable(By locator)
        {
            Logger.Info("Validating "+ locator + "element is Clickable");
            try
            {
                WebDriverWait wait = new WebDriverWait(GetWebDriver(), TimeSpan.FromSeconds(ExistCheckMaxTimeoutSec));
                wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        protected static String GetEnumValue(Enum value)
        {
            return EnumDescription.GetEnumDescription(value);
        }

        protected void MouseOver(By locator) {
            IWebElement element = FindElementCustom(locator);

            // Create an instance of the Actions class
            Actions actions = new Actions(GetWebDriver());

            // Perform the mouseover/hover action on the element
            actions.MoveToElement(element).Perform();

        }

        protected void NavigateTo(String url) {
            GetWebDriver().Navigate().GoToUrl(url);
        }

        protected void SwitchToNewTab() {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)GetWebDriver();
            jsExecutor.ExecuteScript("window.open();");
            SwitchToLastTab();
        }

        protected void SwitchToLastTab() {
            GetWebDriver().SwitchTo().Window(GetWebDriver().WindowHandles.Last());
        }

        protected void SwitchToFirstTab()
        {
            GetWebDriver().SwitchTo().Window(GetWebDriver().WindowHandles.First());
        }

        protected void NaviagateToBackPage()
        {
            GetWebDriver().Navigate().Back();
        }

        protected void SwitchToNextTab()
        {
            // Get the current tab handle
            string currentTabHandle = GetWebDriver().CurrentWindowHandle;
            
            // Get all tab handles
            List<string> allTabHandles = new List<string>(GetWebDriver().WindowHandles);
            
            // Find the index of the current tab handle
            int currentIndex = allTabHandles.IndexOf(currentTabHandle);
            
            // Calculate the index of the next tab
            int nextIndex = (currentIndex + 1) % allTabHandles.Count;
            
                        // Switch to the next tab
            GetWebDriver().SwitchTo().Window(allTabHandles[nextIndex]);
            
        }

        protected void RefreshBrowser()
        {
            GetWebDriver().Navigate().Refresh();
        }

        protected Boolean IsElementEnabled(By locator)
        {
            Logger.Info("Checking if element is enabled");
            IWebElement element = FindElementCustom(locator, ExistCheckMaxTimeoutSec);
            try
            {
                FluentWait(ExistCheckMaxTimeoutSec).Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception ex)
            {
                Logger.Info(ex.Message);
                return false;
            }
            return element.Enabled;
        }

    }
}

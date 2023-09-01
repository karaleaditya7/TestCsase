using InflueriAutomation.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Microsoft.Edge.SeleniumTools;

namespace InflueriAutomation.Utils
{
    public class WebDriverSettings
    {
        public static ChromeOptions ChromeOptions(WebDriverConfiguration config)
        {
            var options = new ChromeOptions();
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.AddExcludedArgument("enable-automation");
            options.AddArgument("--disable-save-password-bubble");
            options.AddArgument("ignore-certificate-errors");
            options.AddArgument("start-maximized");
            options.AddArgument($"--lang={config.BrowserLanguage}");
            options.AddUserProfilePreference("intl.accept_languages", config.BrowserLanguage);
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("disable-infobars");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--no-proxy-server");
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-web-security");
            //options.AddArgument("--user-data-dir = D:\\ChromeProfile");
            //options.AddAdditionalCapability("credentials_enable_service", false);
            //options.AddAdditionalCapability("profile.password_manager_enabled", false);
            //options.AddAdditionalCapability("download.default_directory", "");
            return options;
        }

        public static FirefoxOptions FirefoxOptions(WebDriverConfiguration config)
        {
            var options = new FirefoxOptions { AcceptInsecureCertificates = true };
            options.SetPreference("intl.accept_languages", config.BrowserLanguage);

            return options;
        }

        public static InternetExplorerOptions InternetExplorerOptions()
        {
            return new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                IgnoreZoomLevel = true,
                EnsureCleanSession = true
            };
        }

        public static EdgeOptions EdgeOptions()
        {
            var options = new EdgeOptions();
            options.AddArgument("start-maximized");
            options.UseChromium = true;
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            options.UseInPrivateBrowsing = true;

            return options;
        }
    }
}

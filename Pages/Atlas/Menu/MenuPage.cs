using InflueriAutomation.Core;
using InflueriAutomation.Providers;
using InflueriAutomation.Tests;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.Atlas
{
    public class MenuPage : BaseTestPage
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private By GetMenuDrafts() => By.XPath(".//div[@class='sidebar']//a[normalize-space()='Drafts']");

        public DraftsPage ClickDrafts() {
            logger.Info("Clicking drafts");
            WaitUntilElementIsPresent(GetMenuDrafts());
            Click(GetMenuDrafts());
            return new DraftsPage();
        }

        private By GetBtnLogout() => By.XPath(".//button[contains(text(),'Log out')]");

        public MenuPage NaviagteToAltlas() {
            logger.Info("Navigating to Atlas module");
            SwitchToNewTab();
            NavigateTo(ConfigurationProvider.EnvConfig.AtlasUrl);
            WaitUntilElementIsPresent(GetBtnLogout());
            Click(GetBtnLogout());
            return this;
        }

        public MenuPage NavigateToInfluencers()
        {
            logger.Info("Navigating to Influencers");
            SwitchToNewTab();
            NavigateTo(ConfigurationProvider.EnvConfig.InfluencersUrl);
            new LoginTest().InfluencersLogin();
            return this;
        }

        public MenuPage NavigateToPostmark()
        {
            logger.Info("Navigating to Postmark");
            SwitchToNewTab();
            NavigateTo(ConfigurationProvider.EnvConfig.PostmarkUrl);
            new LoginTest().PostmarkLogin();
            return this;
        }
    }
}

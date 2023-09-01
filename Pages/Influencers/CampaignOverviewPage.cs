using InflueriAutomation.Core;
using InflueriAutomation.Pages.Influencers.CampaignOverview;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.Influencers
{
    public class CampaignOverviewPage : Initializer
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private By GetButtonMisssion() => By.XPath(".//span[contains(text(),'Mission')]/..");

        public MissionPage NavigateToMission() {
            logger.Info("Navigating to Mission");
            Click(GetButtonMisssion());
            return new MissionPage();
        }

        private By GetButtonContent() => By.XPath(".//span[contains(text(),'Content')]/..");

        public ContentPage NavigateToContent()
        {
            logger.Info("Navigating to Content");
            Click(GetButtonContent());
            return new ContentPage();
        }

        private By GetButtonInsights() => By.XPath(".//span[contains(text(),'Insights')]/..");

        public InsightsPage NavigateToInsights()
        {
            logger.Info("Navigating to Insights");
            Click(GetButtonInsights());
            RefreshBrowser();
            return new InsightsPage();
        }

        public CampaignOverviewPage NavigateToInfluencers() {
            SwitchToLastTab();
            return this;
        }
    }
}

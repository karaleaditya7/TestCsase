using InflueriAutomation.Core;
using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.Influencers
{
    public class CampaignsPage : Initializer
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private By GetCampaignName(String campaignName) => By.XPath($"//h6[contains(text(),'{campaignName}')]/..");

        public CampaignsPage ValidateCampaignName(String campaignName){
            logger.Info("Validating Campaign name");
            WaitUntilElementIsPresent(GetCampaignName(campaignName));
            Assert.IsTrue(IsElementVisible(GetCampaignName(campaignName)));
            return this;
        }

        public CampaignOverviewPage CampaignOverview(String campaignName) {
            logger.Info("Opening campaign overview");
            Click(GetCampaignName(campaignName));
            return new CampaignOverviewPage();
        }
    }
}

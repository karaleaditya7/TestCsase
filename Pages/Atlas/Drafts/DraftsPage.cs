using InflueriAutomation.Core;
using InflueriAutomation.Pages.Atlas.Drafts;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.Atlas
{
    public class DraftsPage : BaseTestPage
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private By GetLinkCampaignId(String campaignName) => By.XPath($".//td[contains(text(),'{campaignName}')]/..//td//a");

        public CampaignDraftDetailsPage OpenCampaignDraftDetails(Models.Campaign campaignData) {
            logger.Info("Opening Campaign draft details page");
            ScrollToElement(GetLinkCampaignId(campaignData.CampaignName));
            MediumWait();
            Click(GetLinkCampaignId(campaignData.CampaignName));
            return new CampaignDraftDetailsPage();
        }
    }
}

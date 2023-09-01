using InflueriAutomation.Core;
using InflueriAutomation.Pages.Atlas.Campaigns;
using InflueriAutomation.Pages.Campaign;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.Atlas.Drafts
{
    public class CampaignDraftDetailsPage : BaseTestPage
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        DraftInfluencersPage draftInfluencersPage = new DraftInfluencersPage();
        private By GetBtnActions() => By.XPath(".//button[contains(@class,'btn btn-secondary')]");

        public CampaignDraftDetailsPage OpenActionsMenu() {
            logger.Info("Opening actions menu");
            Click(GetBtnActions());
            return this;
        }

        private By GetBtnSetInfluencers() => By.XPath(".//ul[contains(@class,'dropdown-menu')]//a[contains(text(),'Set')]");

        public DraftInfluencersPage ClickSetInfluencers()
        {
            logger.Info("Clicking on Set influencers");
            Click(GetBtnSetInfluencers());
            return new DraftInfluencersPage();
        }

        private By GetBtnCreateCampaign() => By.XPath(".//button[contains(text(),'Create campaign')]");

        public CampaignDetailsPage ClickCreateCampaign() {
            logger.Info("Clicking create campaign");
            Click(GetBtnCreateCampaign());
            return new CampaignDetailsPage();
        }

        public CreateCampaignPage NaviagateToCutomater() {
            logger.Info("Navigating to customer module");
            SwitchToFirstTab();
            return new CreateCampaignPage();
        }

        public CampaignDraftDetailsPage AddInfluencersToCampaign(Models.Campaign campaignData,List<String> InstaInfluencersList) {
            logger.Info("Adding influencers to the campaign");
            new MenuPage().ClickDrafts();
            new DraftsPage().OpenCampaignDraftDetails(campaignData);
            OpenActionsMenu();
            ClickSetInfluencers();
            draftInfluencersPage.AddInfluencers(InstaInfluencersList);
            draftInfluencersPage.NaviagteToCampaignDraftsDetailsPage();
            return this;
        }
    }
}

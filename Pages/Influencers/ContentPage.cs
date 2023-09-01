using InflueriAutomation.Core;
using InflueriAutomation.Enums;
using InflueriAutomation.Pages.Influencers.CampaignOverview.Content;
using NLog;
using OpenQA.Selenium;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.Influencers.CampaignOverview
{
    public class ContentPage : Initializer
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private By GetButtonAdd() => By.XPath(".//button[contains(@class,'mud-button-filled')]");

        public AddProposalsPage ClickAddProposals() {
            logger.Info("Adding Proposals");
            Click(GetButtonAdd());
            return new AddProposalsPage();
        }

        private By GetButtonComments(String SocialMediaType) => By.XPath($".//h6[text()='{SocialMediaType}']/../following-sibling::div[1]//button[contains(@class,'mud-button-text-size-large mud-button-disable-elevation')]");

        public CommentsPage OpenComments(String SocialMediaType) {
            logger.Info("Opening Comments");
            Click(GetButtonComments(SocialMediaType));
            return new CommentsPage();
        }

        private By GetButtonEditCaption(String SocialMediaType) => By.XPath($".//h6[text()='{SocialMediaType}']/../following-sibling::div[1]//button[contains(@class,'mud-ripple')]");

        public EditCaptionPage OpenEditCaption(String SocialMediaType) {
            logger.Info("Clicking on edit caption");
            Click(GetButtonEditCaption(SocialMediaType)); 
            return new EditCaptionPage(); 
        }

        public ContentPage AddProposalsToCampaign(String MediaChoice,String filePath)
        {
            logger.Info("Adding Proposal to campaign");
            new CampaignOverviewPage().NavigateToContent();
            ClickAddProposals();
            new AddProposalsPage().SelectProposalType(MediaChoice);
            new UploadProposalsPage().SelectAndUploadFile(filePath);
            return this;
        }
    }

}

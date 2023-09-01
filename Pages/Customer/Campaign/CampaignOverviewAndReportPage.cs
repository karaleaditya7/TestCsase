using InflueriAutomation.Core;
using InflueriAutomation.Enums;
using InflueriAutomation.Pages.Campaign;
using InflueriAutomation.Pages.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.Customer.Campaign
{
    public class CampaignOverviewAndReportPage : Initializer
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private By GetButtonSeeYourOrder() => By.XPath(".//label[contains(text(),'See Your Order')]/../..");

        public CampaignDraftSummaryPage ClickSeeYourOrder() {
            logger.Info("Clicking see your order");
            Click(GetButtonSeeYourOrder());
            return new CampaignDraftSummaryPage();
        }

        private By GetButtonDuplicateCampaign() => By.XPath(".//label[contains(text(),'Duplicate Campaign')]/../..");

        public CreateCampaignPage ClickDuplicateCampaign(){
            logger.Info("Clicking duplicate campaign");
            Click(GetButtonDuplicateCampaign());
            return new CreateCampaignPage();
        }

        private By GetButtonSeeInfluencersStatus() => By.XPath(".//label[contains(text(),'See Influencer Status')]/../..");
        
        public CampaignOverviewAndReportPage ClickSeeInfluencersStatus(){
            logger.Info("Clicking See influencers status");
            Click(GetButtonSeeInfluencersStatus());
            return this;
        }

        private By GeButtonReviewThemHere() => By.XPath(".//label[contains(text(),'Review Them Here')]/../..");

        public AllContentProposalsPage ClickReviewThemHere(){
            logger.Info("Clicking Review them here");
            Click(GeButtonReviewThemHere());
            return new AllContentProposalsPage();
        }

        private By getButtonViewAllcontentProposals() => By.XPath(".//div[@class='pb-10']//span[contains(text(),'View all content proposals')]");

        public CampaignOverviewAndReportPage ViewAllContentProposals(){
            logger.Info("Clicking on All Content Proposals");
            Click(getButtonViewAllcontentProposals());
            return new CampaignOverviewAndReportPage();
        }

        private By GetButtonExportDeliveryDetails() => By.XPath(".//label[contains(text(),'Export delivery details')]/../..");

        public CampaignOverviewAndReportPage ExportDelivertDetails(){
            logger.Info("Clicking Export Delivery details");
            Click(GetButtonExportDeliveryDetails());
            return this;
        }

        private By GetButtonFinalizeThemHere() => By.XPath(".//label[contains(text(),'Finalize Them Here')]/../..");

        public UtmTagsPage FinalizeThemHere() {
            logger.Info("Clicking Finalize them here");
            Click(GetButtonFinalizeThemHere());
            return new UtmTagsPage();
        }

        private By GetButtonViewInfluencers() => By.XPath(".//label[contains(text(),'View Influencers')]/../..");

        public CampaignOverviewAndReportPage ViewInfluencers() {
            logger.Info("Viewing Influencers");
            Click(GetButtonViewInfluencers());
            return this;
        }

        private By GetButtonViewAllUploads() => By.XPath(".//div[@class='pb-10']//span[contains(text(),'View all uploads')]");

        public AllContentProposalsPage ViewAllUploads() {
            logger.Info("Viewing All proposals");
            Click(GetButtonViewAllUploads());
            return new AllContentProposalsPage();
        }

        public CampaignOverviewAndReportPage ApproveProposalForCampaign(String campaignName,String mediaChoice)
        {
            logger.Info("Approving Proposal");
            new DashboardPage().NaviagteToCustomer();
            new DashboardPage().OpenCreatedCampaign(campaignName);
            ClickReviewThemHere();
            new AllContentProposalsPage().ExpandProposals();
            new AllContentProposalsPage().ApproveProposal(mediaChoice);
            return this;
        }

        private By GetLabelLikesCount(String postType) => By.XPath($".//table//p[contains(text(),'{postType}')]/../../..//td[2]//p");

        public CampaignOverviewAndReportPage ValidateProposalLikes(String postType,int expected) {
            logger.Info("Validating Proposal Likes Count");
            String actaulText = GetText(GetLabelLikesCount(postType));
            Assert.AreEqual(expected.ToString(), actaulText);
            return this;
        }

        private By GetLabelCommentOrRepliesCount(String postType) => By.XPath($".//table//p[contains(text(),'{postType}')]/../../..//td[3]//p");

        public CampaignOverviewAndReportPage ValidateProposalRepliesCount(String postType, int expected)
        {
            logger.Info("Validating Proposal Replies count");
            String actaulText = GetText(GetLabelCommentOrRepliesCount(postType));
            Assert.AreEqual(expected.ToString(), actaulText);
            return this;
        }

        private By GetLabelSharesCount(String postType) => By.XPath($".//table//p[contains(text(),'{postType}')]/../../..//td[4]//p");

        public CampaignOverviewAndReportPage ValidateProposalSharesCount(String postType, int expected)
        {
            logger.Info("Validating Proposal Shares Count");
            String actaulText = GetText(GetLabelSharesCount(postType));
            Assert.AreEqual(expected.ToString(), actaulText);
            return this;
        }

        private By GetLabelSavesCount(String postType) => By.XPath($".//table//p[contains(text(),'{postType}')]/../../..//td[5]//p");

        public CampaignOverviewAndReportPage ValidateProposalSavesCount(String postType, int expected)
        {
            logger.Info("Validating proposals saves count");
            String actaulText = GetText(GetLabelSavesCount(postType));
            Assert.AreEqual(expected.ToString(), actaulText);
            return this;
        }

        public CampaignOverviewAndReportPage ValidateInsightsForFeedVideo(int count, String campaignName) {
            logger.Info("Validating insights for Feed Video");
            String postType = GetEnumValue(AppDataShared.FeedVideoPost);
            new AllContentProposalsPage().naviagteToCampaignOverview(campaignName);
            ValidateProposalLikes(postType, count);
            ValidateProposalRepliesCount(postType, count);
            ValidateProposalSharesCount(postType, count);
            ValidateProposalSavesCount(postType, count);
            return this;
        }



    }
}

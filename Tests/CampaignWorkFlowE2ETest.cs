using AventStack.ExtentReports;
using InflueriAutomation.Core;
using InflueriAutomation.DataUtils;
using InflueriAutomation.Enums;
using InflueriAutomation.Models;
using InflueriAutomation.Pages.Atlas.Drafts;
using InflueriAutomation.Pages.Atlas;
using InflueriAutomation.Pages.Campaign;
using InflueriAutomation.Pages.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InflueriAutomation.Pages.Atlas.Campaigns;
using InflueriAutomation.Providers;
using InflueriAutomation.Pages.Influencers;
using InflueriAutomation.Pages.PostMark;
using InflueriAutomation.Pages.Influencers.CampaignOverview;
using InflueriAutomation.Pages.Influencers.CampaignOverview.Content;
using InflueriAutomation.Pages.Customer.Campaign;

namespace InflueriAutomation.Tests
{
    [TestClass]
    public class CampaignWorkFlowE2ETest : Initializer
    {
        [TestMethod("Validate Create End to End test case"), TestCategory("Regression")]
        public void CreateEndToEndTestCase() {
            DashboardPage dashboardPage;
            CampaignDraftDetailsPage campaignDraftDetailsPage = new CampaignDraftDetailsPage();
            EditInfluencersInfoPage editInfluencersInfoPage = new EditInfluencersInfoPage();
            MenuPage menuPage =new MenuPage();

            Campaign campaignData = TestDataGenerator.GenerateCampaignData();
            ExtentTestLogger.AssignCategory(EnumDescription.GetEnumDescription(TestCategory.Campaign));

            ExtentTestLogger.Log(Status.Pass, "Login to the app as customer");
            dashboardPage = new LoginTest().LoginShared();

            ExtentTestLogger.Log(Status.Pass, "Create campaign with below fields data");
            CreateCampaignPage createCampaignPage = new CampaignTest().CreateCampaignShared(campaignData);

            ExtentTestLogger.Log(Status.Pass, "Navigate to Atlas Module");
            menuPage.NaviagteToAltlas();

            ExtentTestLogger.Log(Status.Pass, "Add influencers to the campaign");
            List<String> InstaInfluencersList = new List<String> { GetEnumValue(AppDataShared.Alexandrapizzoni) };
            campaignDraftDetailsPage.AddInfluencersToCampaign(campaignData, InstaInfluencersList);

            ExtentTestLogger.Log(Status.Pass, "Click create campaign");
            campaignDraftDetailsPage.ClickCreateCampaign();

            ExtentTestLogger.Log(Status.Pass, "Configure influencers");
            editInfluencersInfoPage.ConfigureInfluencers(ConfigurationProvider.EnvConfig.InfluencerEmail, campaignData.BudgetAmount);

            ExtentTestLogger.Log(Status.Pass, "Naviagate to Influencers page");
            menuPage.NavigateToInfluencers();

            ExtentTestLogger.Log(Status.Pass, "Validate Campaign present on Influencers module");
            new CampaignsPage().ValidateCampaignName(campaignData.CampaignName);

        }


        [TestMethod("Validate - Create End to End test case with Accepting campaign invitation"), TestCategory("Regression")]

        public void EndToEndTestCase() {
            MenuPage menuPage = new MenuPage();
            EmailInboxPage emailInboxPage = new EmailInboxPage();
            DashboardPage dashboardPage;
            CampaignDraftDetailsPage campaignDraftDetailsPage = new CampaignDraftDetailsPage();
            EditInfluencersInfoPage editInfluencersInfoPage = new EditInfluencersInfoPage();
            CampaignsPage campaignsPage = new CampaignsPage();
            ContentPage contentPage = new ContentPage();
            CampaignOverviewAndReportPage campaignOverviewAndReportPage =new CampaignOverviewAndReportPage();
            InsightsPage insightsPage = new InsightsPage();
            string filePath = @"C:\Users\shrip\OneDrive\Documents\Influri test data images\Photo_1.png";

            Campaign campaignData = TestDataGenerator.GenerateCampaignData();
            ExtentTestLogger.AssignCategory(EnumDescription.GetEnumDescription(TestCategory.Campaign));

            ExtentTestLogger.Log(Status.Pass, "Login to the app as customer");
            dashboardPage = new LoginTest().LoginShared();

            ExtentTestLogger.Log(Status.Pass, "Create campaign with below fields data");
            CreateCampaignPage createCampaignPage = new CampaignTest().CreateCampaignShared(campaignData);

            ExtentTestLogger.Log(Status.Pass, "Navigate to Atlas Module");
            menuPage.NaviagteToAltlas();

            ExtentTestLogger.Log(Status.Pass, "Add influencers to the campaign");
            List<String> InstaInfluencersList = new List<String> { GetEnumValue(AppDataShared.Alexandrapizzoni) };
            campaignDraftDetailsPage.AddInfluencersToCampaign(campaignData, InstaInfluencersList);

            ExtentTestLogger.Log(Status.Pass, "Click create campaign");
            campaignDraftDetailsPage.ClickCreateCampaign();

            ExtentTestLogger.Log(Status.Pass, "Configure influencers");
            editInfluencersInfoPage.ConfigureInfluencers(ConfigurationProvider.EnvConfig.InfluencerEmail, campaignData.BudgetAmount);

            ExtentTestLogger.Log(Status.Pass, "Send Invitation To Influencer");
            new CampaignInfluencersPage().SendInvitationToInfluencers();

            ExtentTestLogger.Log(Status.Pass, "Navigate to Postmark");
            menuPage.NavigateToPostmark();

            ExtentTestLogger.Log(Status.Pass, "Search an Email");
            emailInboxPage.SearchEmail(GetEnumValue(EmailTemplates.CampaignInvitation), campaignData.CompanyName);

            ExtentTestLogger.Log(Status.Pass, "Open desired Email");
            emailInboxPage.OpenEmail(ConfigurationProvider.EnvConfig.InfluencerEmail);

            ExtentTestLogger.Log(Status.Pass, "Click see mission");
            new EmailMessagesPage().ClickSeeMission();

            ExtentTestLogger.Log(Status.Pass, "Accept invitation");
            new YourMissionPage().ClickAcceptInvitation();

            ExtentTestLogger.Log(Status.Pass, "Navigate to influencers");
            menuPage.NavigateToInfluencers();

            ExtentTestLogger.Log(Status.Pass, "Open Campaign");
            campaignsPage.CampaignOverview(campaignData.CampaignName);

            ExtentTestLogger.Log(Status.Pass, "Add Proposals to campaign");
            contentPage.AddProposalsToCampaign(GetEnumValue(AppDataShared.FeedVideoPost), filePath);

            ExtentTestLogger.Log(Status.Pass, "Approve proposal");
            campaignOverviewAndReportPage.ApproveProposalForCampaign(campaignData.CampaignName, GetEnumValue(AppDataShared.FeedVideoPost));

            ExtentTestLogger.Log(Status.Pass, "Upload insights for proposal");
            insightsPage.UploadInsightsForProposal(GetEnumValue(AppDataShared.FeedVideoPost), campaignData.ProductValue, filePath);

            ExtentTestLogger.Log(Status.Pass, "Validate insights for proposal");
            campaignOverviewAndReportPage.ValidateInsightsForFeedVideo(campaignData.ProductValue, campaignData.CampaignName);


        }
    }
}

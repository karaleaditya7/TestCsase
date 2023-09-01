using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using InflueriAutomation.Enums;
using InflueriAutomation.DataUtils;
using InflueriAutomation.Pages.Campaign;
using InflueriAutomation.Core;
using InflueriAutomation.Models;
using InflueriAutomation.Pages.Core;
using InflueriAutomation.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InflueriAutomation.Utils;
using InflueriAutomation.Pages.Atlas;
using InflueriAutomation.Pages.Atlas.Drafts;

namespace InflueriAutomation.Tests
{
    [TestClass]
    public class CampaignTest : Initializer
    {
        DashboardPage dashboardPage;
        CampaignDraftSummaryPage draftSummaryPage = new CampaignDraftSummaryPage();
        CampaignConfirmationPage campaignConfirmationPage = new CampaignConfirmationPage();

        [TestMethod("Create campaign with Test data object and mandatory fields"), TestCategory("Regression")]
        public void Validate_Create_Campaign()
        {
            ExtentTestLogger.AssignCategory(EnumDescription.GetEnumDescription(TestCategory.Campaign));

            Campaign campaignData = TestDataGenerator.GenerateCampaignData();

            ExtentTestLogger.Log(Status.Pass, "Login to the app as customer");
            dashboardPage = new LoginTest().LoginShared();

            ExtentTestLogger.Log(Status.Pass, "Create campaign with below fields data");
            CreateCampaignPage createCampaignPage = CreateCampaignShared(campaignData);

            ExtentTestLogger.Log(Status.Pass, "Validate campaign created");
            dashboardPage.ValidateCampaignCreated(campaignData.CampaignName);
        }

        [TestMethod("Validate Delete campaign Draft"), TestCategory("Regression")]
        public void Validate_Campaign_Draft_Deleted()
        {
            Campaign campaignData = TestDataGenerator.GenerateCampaignData();
            String CampaignName = campaignData.CampaignName;

            ExtentTestLogger.AssignCategory(EnumDescription.GetEnumDescription(TestCategory.Campaign));

            ExtentTestLogger.Log(Status.Pass, "Login to the app as customer");
            dashboardPage = new LoginTest().LoginShared();

            ExtentTestLogger.Log(Status.Pass, "Create campaign with below fields data");
            CreateCampaignPage createCampaignPage = CreateCampaignShared(campaignData);

            ExtentTestLogger.Log(Status.Pass, "Navigate to dashboard");
            campaignConfirmationPage.GoToDashboard();

            ExtentTestLogger.Log(Status.Pass, "Click on Delete Draft");
            dashboardPage.DeleteDraft(CampaignName);

            ExtentTestLogger.Log(Status.Pass, "Validate Campaign is Deleted successfully");
            dashboardPage.ValidateCampaignDeletedSuccessfully(CampaignName);
        }

        [TestMethod("Validate Delete all campaign Draft created by automated test"), TestCategory("Regression")]
        public void Validate_All_Automated_Campaign_Draft_Deleted()
        {
            Campaign campaignData = TestDataGenerator.GenerateCampaignData();
            String CampaignName = campaignData.CampaignName;

            ExtentTestLogger.AssignCategory(EnumDescription.GetEnumDescription(TestCategory.Campaign));

            ExtentTestLogger.Log(Status.Pass, "Login to the app as customer");
            dashboardPage = new LoginTest().LoginShared();

            ExtentTestLogger.Log(Status.Pass, "Finad all automated draft and Delete Draft");
            dashboardPage.DeleteAllDraft("auto");

            ExtentTestLogger.Log(Status.Pass, "Validate Campaign is Deleted successfully");
            dashboardPage.ValidateAllCampaignDraftDeletedSuccessfully("auto");
        }

        [TestMethod("Create duplicate campaign"), TestCategory("Regression")]
        public void Validate_Duplicate_Campaign_Created()
        {
            Campaign campaignData = TestDataGenerator.GenerateCampaignData();
            String CampaignName = campaignData.CampaignName;

            ExtentTestLogger.AssignCategory(EnumDescription.GetEnumDescription(TestCategory.Campaign));

            ExtentTestLogger.Log(Status.Pass, "Login to the app as customer");
            dashboardPage = new LoginTest().LoginShared();

            ExtentTestLogger.Log(Status.Pass, "Create campaign with below fields data");
            CreateCampaignPage createCampaignPage = CreateCampaignShared(campaignData);

            ExtentTestLogger.Log(Status.Pass, "Navigate to dashboard");
            campaignConfirmationPage.GoToDashboard();

            ExtentTestLogger.Log(Status.Pass, "Click on Create duplicate campaign");
            dashboardPage.CreateDuplicateCampaign(CampaignName);

            ExtentTestLogger.Log(Status.Pass, "Clicks on save draft");
            createCampaignPage.ClickSaveDraft();

            ExtentTestLogger.Log(Status.Pass, "Navigate to dashboard");
            campaignConfirmationPage.ClickGoBackToDashboard();

            ExtentTestLogger.Log(Status.Pass, "Validate duplicate campaign created..");
            dashboardPage.ValidateDuplicateCampaignCreated(CampaignName);
        }

        [TestMethod("Edit Instagram campaign Draft With mandatory fields"), TestCategory("Regression")]
        public void Validate_Edit_Campaign()
        {
            Campaign campaignData = TestDataGenerator.GenerateCampaignData();
            Campaign editedCampaignData = TestDataGenerator.GenerateEditCampaignData();

            ExtentTestLogger.AssignCategory(EnumDescription.GetEnumDescription(TestCategory.Campaign));

            ExtentTestLogger.Log(Status.Pass, "Login to the app as customer");
            dashboardPage = new LoginTest().LoginShared();

            ExtentTestLogger.Log(Status.Pass, "Provide below campaign details ");
            CreateCampaignPage createCampaignPage = ProvideCampaignDetailsShared(campaignData);

            ExtentTestLogger.Log(Status.Pass, "Click on create new campaign");
            createCampaignPage.ClickSaveDraft();

            ExtentTestLogger.Log(Status.Pass, "Navigate To Dashboard page");
            campaignConfirmationPage.ClickGoBackToDashboard();

            ExtentTestLogger.Log(Status.Pass, "Click edit draft");
            dashboardPage.ClickEditDraft(campaignData.CampaignName);

            ExtentTestLogger.Log(Status.Pass, "Edit Campaign info");
            createCampaignPage.SetCampaignName(editedCampaignData.CampaignName);

            ExtentTestLogger.Log(Status.Pass, "Edit Campaign info");
            createCampaignPage.EnterBasicInfo(editedCampaignData);

            ExtentTestLogger.Log(Status.Pass, "Select Format");
            createCampaignPage.SelectFormat(editedCampaignData);

            ExtentTestLogger.Log(Status.Pass, "Select target audience");
            createCampaignPage.EnterTargetAudienceInfo(editedCampaignData);

            ExtentTestLogger.Log(Status.Pass, "Select social media posts");
            List<String> EditedInstaPostList = new List<String> { GetEnumValue(AppDataShared.Reels) };
            createCampaignPage.SelectSocialMediaPlatform(GetEnumValue(AppDataShared.GetOptionInstagram), EditedInstaPostList);

            ExtentTestLogger.Log(Status.Pass, "Enter Product/service details");
            createCampaignPage.EnterProductOrServiceInfo(editedCampaignData);

            ExtentTestLogger.Log(Status.Pass, "Click on create new campaign");
            createCampaignPage.ClickCreateCampaign();

            ExtentTestLogger.Log(Status.Pass, "Navigate to Dashboard");
            campaignConfirmationPage.GoToDashboard();

            ExtentTestLogger.Log(Status.Pass, "Click see your order");
            dashboardPage.ClickSeeYourOrder(editedCampaignData.CampaignName);

            ExtentTestLogger.Log(Status.Pass, "Validate Campaign info");
            draftSummaryPage.ValidateCampaignInfo(editedCampaignData);

            ExtentTestLogger.Log(Status.Pass, "Validate Product or service info");
            draftSummaryPage.ValidateProductOrServiceInfo(editedCampaignData);

            ExtentTestLogger.Log(Status.Pass, "Validate Social media info");
            draftSummaryPage.ValidateSocialMediaInfo(GetEnumValue(AppDataShared.GetOptionInstagram), editedCampaignData);

            ExtentTestLogger.Log(Status.Pass, "Validate Target audience info");
            draftSummaryPage.ValidateTargetAudience(editedCampaignData);
        }

        [TestMethod("Validate Draft summary validation information"), TestCategory("Regression")]

        public void Validate_Campaign_Draft_Summary_Validation() {

            Campaign campaignData = TestDataGenerator.GenerateCampaignData();
            ExtentTestLogger.AssignCategory(EnumDescription.GetEnumDescription(TestCategory.Campaign));

            ExtentTestLogger.Log(Status.Pass, "Login to the app as customer");
            dashboardPage = new LoginTest().LoginShared();

            ExtentTestLogger.Log(Status.Pass, "Create campaign with below fields data");
            CreateCampaignPage createCampaignPage = CreateCampaignShared(campaignData);

            ExtentTestLogger.Log(Status.Pass, "Navigate to Dashboard");
            campaignConfirmationPage.GoToDashboard();

            ExtentTestLogger.Log(Status.Pass, "Click see your order");
            dashboardPage.ClickSeeYourOrder(campaignData.CampaignName);

            ExtentTestLogger.Log(Status.Pass, "Validate Campaign info");
            draftSummaryPage.ValidateCampaignInfo(campaignData);

            ExtentTestLogger.Log(Status.Pass, "Validate Product or service info");
            draftSummaryPage.ValidateProductOrServiceInfo(campaignData);

            ExtentTestLogger.Log(Status.Pass, "Validate Social media info");
            draftSummaryPage.ValidateSocialMediaInfo(GetEnumValue(AppDataShared.GetOptionInstagram), campaignData);

            ExtentTestLogger.Log(Status.Pass, "Validate Target audience info");
            draftSummaryPage.ValidateTargetAudience(campaignData);
        }

        [TestMethod("Validate Campaign Closed"), TestCategory("Regression")]
        public void Validate_Campaign_Closed() {

            Campaign campaignData = TestDataGenerator.GenerateCampaignData();
            ExtentTestLogger.AssignCategory(EnumDescription.GetEnumDescription(TestCategory.Campaign));

            ExtentTestLogger.Log(Status.Pass, "Login to the app as customer");
            dashboardPage = new LoginTest().LoginShared();

            ExtentTestLogger.Log(Status.Pass, "Create campaign with below fields data");
            CreateCampaignPage createCampaignPage = CreateCampaignShared(campaignData);

            ExtentTestLogger.Log(Status.Pass, "Navigate to Atlas Module");
            new MenuPage().NaviagteToAltlas();

            ExtentTestLogger.Log(Status.Pass, "Navigate to the Drafts");
            DraftsPage draftsPage = new MenuPage().ClickDrafts();

            ExtentTestLogger.Log(Status.Pass, "Open Campaign draft details");
            CampaignDraftDetailsPage campaignDraftDetailsPage = draftsPage.OpenCampaignDraftDetails(campaignData);

            ExtentTestLogger.Log(Status.Pass, "Open Action menu and Click set influencers");
            campaignDraftDetailsPage.OpenActionsMenu();
            DraftInfluencersPage draftInfluencersPage = campaignDraftDetailsPage.ClickSetInfluencers();

            ExtentTestLogger.Log(Status.Pass, "Attach influencers");
            List<String> InstaInfluencersList = new List<String> { GetEnumValue(AppDataShared.Alexandrapizzoni), GetEnumValue(AppDataShared.forlossningspodden) };
            draftInfluencersPage.AddInfluencers(InstaInfluencersList);

            ExtentTestLogger.Log(Status.Pass, "Naviagate to Drafts page and create Campaign");
            draftInfluencersPage.NaviagteToCampaignDraftsDetailsPage();
            campaignDraftDetailsPage.ClickCreateCampaign();

            ExtentTestLogger.Log(Status.Pass, "Navigate to Customer module");
            campaignDraftDetailsPage.NaviagateToCutomater();

            ExtentTestLogger.Log(Status.Pass, "Navigate to Dashboard and Close Campaign");
            campaignConfirmationPage.GoToDashboard();
            dashboardPage.CloseCampaign(campaignData.CampaignName);

            ExtentTestLogger.Log(Status.Pass, "Validate Campaign Closed");
            dashboardPage.ValidateCampaignClosed(campaignData.CampaignName);
        }

        public CreateCampaignPage CreateCampaignShared(Campaign campaignData)
        {
            CreateCampaignPage createCampaignPage = ProvideCampaignDetailsShared(campaignData);

            ExtentTestLogger.Log(Status.Pass, "Click on create new campaign");
            return createCampaignPage.ClickCreateCampaign();

        }

        CreateCampaignPage ProvideCampaignDetailsShared(Campaign campaignData)
        {
            ExtentTestLogger.Log(Status.Pass, "Provide campaign name and click on create campaign");
            CreateCampaignPage createCampaignPage = new DashboardPage().SetCampaignName(campaignData.CampaignName).ClickCreateCampaign();

            ExtentTestLogger.Log(Status.Pass, "Enter basic info");
            createCampaignPage.EnterBasicInfo(campaignData);

            ExtentTestLogger.Log(Status.Pass, "Enter purpose");
            createCampaignPage.EnterPuproseInfo(campaignData);

            ExtentTestLogger.Log(Status.Pass, "Select Format");
            createCampaignPage.SelectFormat(campaignData);

            ExtentTestLogger.Log(Status.Pass, "Select target audience");
            createCampaignPage.EnterTargetAudienceInfo(campaignData);

            ExtentTestLogger.Log(Status.Pass, "Select social media post");
            List<String> InstaPostList = new List<String> { GetEnumValue(AppDataShared.StoryVideoPost), GetEnumValue(AppDataShared.FeedVideoPost) };
            createCampaignPage.SelectSocialMediaPlatform(GetEnumValue(AppDataShared.GetOptionInstagram), InstaPostList);

            ExtentTestLogger.Log(Status.Pass, "Set publication period");
            createCampaignPage.SetPublicationPeriod(DateUtils.GetFromDate(), DateUtils.GetToDate());

            ExtentTestLogger.Log(Status.Pass, "Enter Product/service details");
            return createCampaignPage.EnterProductOrServiceInfo(campaignData);
        }
    }
}
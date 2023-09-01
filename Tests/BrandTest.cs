using AventStack.ExtentReports;
using InflueriAutomation.Core;
using InflueriAutomation.DataUtils;
using InflueriAutomation.Enums;
using InflueriAutomation.Models;
using InflueriAutomation.Pages.BrandsDivison;
using InflueriAutomation.Pages.Campaign;
using InflueriAutomation.Pages.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Tests
{
    [TestClass]
    public class BrandTest : Initializer
    {
        DashboardPage dashboardPage;
        CampaignConfirmationPage campaignConfirmationPage = new CampaignConfirmationPage();
        CreateCampaignPage createCampaignPage;
        AddBrandsDivisionPage AddBrandsDivisionPage = new AddBrandsDivisionPage();

        [TestMethod("Move draft to brand/division"), TestCategory("Regression")]
        public void Validate_Draft_Moved_To_Brand_Or_Division()
        {
            Campaign campaignData = TestDataGenerator.GenerateCampaignData();

            ExtentTestLogger.AssignCategory(EnumDescription.GetEnumDescription(TestCategory.BrandOrDivision)); 
            String CampaignName = campaignData.CampaignName;
            String Brand = campaignData.Brand;

            ExtentTestLogger.Log(Status.Pass, "Login to the app as customer");
            dashboardPage = new LoginTest().LoginShared();

            ExtentTestLogger.Log(Status.Pass, "Set Campaign Name");
            dashboardPage.SetCampaignName(CampaignName);

            ExtentTestLogger.Log(Status.Pass, "Click on create new campaign");
            dashboardPage.ClickCreateCampaign();

            ExtentTestLogger.Log(Status.Pass, "Navigate to Dashboard");
            createCampaignPage = new CreateCampaignPage().ClickSaveDraft();

            ExtentTestLogger.Log(Status.Pass, "Navigate to dashboard");
            campaignConfirmationPage.ClickGoBackToDashboard();

            ExtentTestLogger.Log(Status.Pass, "Open option list");
            dashboardPage.ClickOnEllipsisIcon(CampaignName);

            ExtentTestLogger.Log(Status.Pass, "Select option Move draft to brand/division");
            dashboardPage.ClicksOnMoveDraftToBrandOrDivision();

            ExtentTestLogger.Log(Status.Pass, "Select Brand/Division from dropdown");
            AddBrandsDivisionPage.SelectBrandsFromDropdown(Brand);

            ExtentTestLogger.Log(Status.Pass, "Click on move campaign");
            AddBrandsDivisionPage.ClickMoveCampaign();

            ExtentTestLogger.Log(Status.Pass, "Navigate to Dashboard");
            dashboardPage.ClickOnInfluriHeader();

            ExtentTestLogger.Log(Status.Pass, "Validate draft successfully move to the brand");
            dashboardPage.SelectBrand(Brand);
            dashboardPage.ValidateCampaignPresent(CampaignName);
        }

        [TestMethod("Create new brand"), TestCategory("Regression")]
        public void Validate_Create_New_Brand()
        {
            Campaign campaignData = TestDataGenerator.GenerateCampaignData();

            ExtentTestLogger.AssignCategory(EnumDescription.GetEnumDescription(TestCategory.BrandOrDivision));
            String brandName = campaignData.Brand;

            ExtentTestLogger.Log(Status.Pass, "Login to the app as customer");
            dashboardPage = new LoginTest().LoginShared();

            ExtentTestLogger.Log(Status.Pass, "Create brand by following below steps");
            AddBrandShared(dashboardPage, brandName);

            ExtentTestLogger.Log(Status.Pass, "Brand is created successfully");
            dashboardPage.ValidateBrandPresent(brandName);
        }

        [TestMethod("Delete brand"), TestCategory("Regression")]
        public void Validate_Brand_Deleted() {

            Campaign campaignData = TestDataGenerator.GenerateCampaignData();

            ExtentTestLogger.AssignCategory(EnumDescription.GetEnumDescription(TestCategory.BrandOrDivision));
            String brandName = campaignData.Brand;

            ExtentTestLogger.Log(Status.Pass, "Login to the app as customer");
            dashboardPage = new LoginTest().LoginShared();

            ExtentTestLogger.Log(Status.Pass, "Create brand by following below steps");
            AddBrandShared(dashboardPage, brandName);

            ExtentTestLogger.Log(Status.Pass, "Clicks on edit brand");
            dashboardPage.ClickEditBrand(brandName);

            ExtentTestLogger.Log(Status.Pass, "Clicks on delete brand");
            AddBrandsDivisionPage.ClickDeleteBrand();

            ExtentTestLogger.Log(Status.Pass, "Validate brand is deleted");
            dashboardPage.ValidateBrandDeleted(brandName);
        }

        public DashboardPage AddBrandShared(DashboardPage dashboardPage, String brandName)
        {
            ExtentTestLogger.Log(Status.Pass, "Clicks on create new brand");
            dashboardPage.ClickOnCreateNewBrand();

            ExtentTestLogger.Log(Status.Pass, "Enter brand name");
            AddBrandsDivisionPage.EnterNewBrandName(brandName);

            ExtentTestLogger.Log(Status.Pass, "Clicks on Add brand");
            return AddBrandsDivisionPage.ClickOnAddBrand();
        }
    }
}

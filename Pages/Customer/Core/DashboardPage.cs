using InflueriAutomation.Pages.Campaign;
using InflueriAutomation.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using OpenQA.Selenium.Support.PageObjects;
using NLog;
using InflueriAutomation.Pages.BrandsDivison;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using static ICSharpCode.SharpZipLib.Zip.ExtendedUnixData;
using Bogus.DataSets;
using AngleSharp.Dom;
using InflueriAutomation.Pages.Customer.Campaign;

namespace InflueriAutomation.Pages.Core
{
    public class DashboardPage : BaseTestPage
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        private By GetCreateCampaignButton() => By.XPath(".//label[contains(text(), 'Create new campaign')]");
        public DashboardPage ValidateLoginSuccess()
        {
            logger.Info("Validating Login successfully");
            Assert.IsTrue(IsElementVisible(GetCreateCampaignButton()),
                "Login unsuccessful as create campaign button did not appear post login");
            return this;
        }

        public DashboardPage ValidateDashboardVisible()
        {
            logger.Info("Validating Dashboard visible");
            Assert.IsTrue(IsElementVisible(GetCreateCampaignButton()),
                "Failed to validate Dashboard visible");
            return this;
        }

        public CreateCampaignPage ClickCreateCampaign()
        {
            logger.Info("Clicking on create campaign button");
            Click(GetCreateCampaignButton());
            WaitUntilElementIsPresent(GetLabelCreateCampaign());
            return new CreateCampaignPage();
        }


        private By GetInputCampaignName() => By.XPath(".//input[@placeholder='Campaign Name']");
        public DashboardPage SetCampaignName(String value)
        {
            logger.Info("Entering campaign name");
            MediumWait();
            SetValue(value, GetInputCampaignName());
            return this;
        }

        private By GetBtnCreateNewBrand() => By.XPath(".//p[contains(text(),'Create New')]/../..//div//p");
        public AddBrandsDivisionPage ClickOnCreateNewBrand()
        {
            logger.Info("Creating new brand");
            Click(GetBtnCreateNewBrand());
            Thread.Sleep(10000);
            return new AddBrandsDivisionPage();
        }

        private By GetEllipsisIcon(String CampaignName) => By.XPath($".//div[contains(@class,'w-100 mb-10')]//h4[contains(text(),'{CampaignName}')]/../../../../..//button");
        public DashboardPage ClickOnEllipsisIcon(String CampaignName)
        {
            logger.Info("Clicking on Ellipsis Icon");
            Click(GetEllipsisIcon(CampaignName));
            return this;
        }

        public DashboardPage ValidateCampaignPresent(String CampaignName)
        {
            logger.Info("Validating campaign is present");
            Assert.IsTrue(IsElementVisible(GetEllipsisIcon(CampaignName)), "Failed to validate Campaign is present on dashboard");
            return this;
        }

        public DashboardPage ValidateCampaignDeletedSuccessfully(String CampaignName)
        {
            logger.Info("Validating campaign is not present");
            Assert.IsTrue(IsElementNotVisible(GetEllipsisIcon(CampaignName)), "Failed to validate Campaign is not present on dashboard");
            return this;
        }

        public DashboardPage ValidateCampaignCreated(String CampaignName)
        {
            logger.Info("Validating campaign is created");
            new CampaignConfirmationPage().GoToDashboard();
            Assert.IsTrue(IsElementVisible(GetEllipsisIcon(CampaignName)), "Failed to validate Campaign is present on dashboard");
            return this;
        }

        private By GetBtnDuplicateCampaign() => By.XPath(".//p[contains(text(),'Duplicate Campaign')]");
        public CreateCampaignPage ClickOnCreateDuplicateCampaign()
        {
            logger.Info("Clicking button create duplicate campaign");
            Click(GetBtnDuplicateCampaign());
            return new CreateCampaignPage();
        }

        private By GetLabelCreateCampaign() => By.XPath(".//h5[contains(text(),'Create campaign')]");
        public DashboardPage ValidateDuplicateCampaignCreated(String campaignName)
        {
            logger.Info("Validating duplicate campaign created");
            IList<IWebElement> element = FindElements(GetEllipsisIcon(campaignName));
            if (element.Count >= 2) { logger.Info("Duplicate campaign created successfully"); }
            else { logger.Info("Something went wrong, please try again....!"); }
            return this;
        }

        public DashboardPage ValidateOrderPageVisible()
        {
            logger.Info("Validating order page is visible");
            Assert.IsTrue(IsElementVisible(GetLabelCreateCampaign()), "Failed to validate order page is present");
            return this;
        }

        private By GetInfluriHeader() => By.XPath(".//div[contains(@class,'mud-toolbar')]//a");
        public DashboardPage ClickOnInfluriHeader()
        {
            logger.Info("Clicking on header");
            Click(GetInfluriHeader());
            WaitUntilElementIsPresent(GetCreateCampaignButton());
            return this;
        }

        private By GetBtnDeleteDraft() => By.XPath(".//p[contains(text(),'Delete Draft')]");
        public DashboardPage ClickOnDeleteDraft()
        {
            logger.Info("Clicking on delete draft");
            Click(GetBtnDeleteDraft());
            return this;
        }

        public void DeleteDraft(String CampaignName) {
            logger.Info("Deleting draft");
            ClickOnInfluriHeader();
            ClickOnEllipsisIcon(CampaignName);
            ClickOnDeleteDraft();
        }

        public DashboardPage CreateDuplicateCampaign(String CampaignName)
        {
            logger.Info("Creating duplicate Campaign");
            ClickOnInfluriHeader();
            ClickOnEllipsisIcon(CampaignName);
            ClickOnCreateDuplicateCampaign();
            return this;
        }

        private By GetEllipsisIconForOngoingCampaign(String CampaignName) => By.XPath($".//div//h4[contains(text(),'{CampaignName}')]/../../../../..//button");
        public DashboardPage ClickOnEllipsisIconForOnGoingCampaign(String CampaignName)
        {
            logger.Info("Clicking on Ellipsis Icon");
            Click(GetEllipsisIconForOngoingCampaign(CampaignName));
            return this;
        }

        private By GetBtnCloseCampaign() => By.XPath(".//p[contains(text(),'Close campaign')]/../..");
        public DashboardPage ClickOnCloseCampaign()
        {
            logger.Info("Clicking button close campaign");
            Click(GetBtnCloseCampaign());
            return this;
        }

        public DashboardPage CloseCampaign(String CampaignName)
        {
            logger.Info("Closing campaign");
            ClickOnInfluriHeader();
            ClickOnEllipsisIconForOnGoingCampaign(CampaignName);
            ClickOnCloseCampaign();
            ClickYesForCloseCampaign();
            return this;
        }

        private By GetBtnYesForCloseCampaign() => By.XPath(".//span//label[normalize-space()='Yes!']");

        public DashboardPage ClickYesForCloseCampaign() {
            Click(GetBtnYesForCloseCampaign());
            return this;
        }

        private By GetDropdownBrand() => By.XPath(".//div[contains(@class,'mud-input-adornment mud-input-adornment-end mud-select-input')]");
        private By GetBrandFromDropdown(String Brand) => By.XPath($".//div[contains(@class,'mud-list-item-text')]//p[text()='{Brand}']");
        public DashboardPage SetBrandFromDropdown(String Brand)
        {
            logger.Info("Selecting brand from dropdown");
            Click(GetDropdownBrand());
            Click(GetBrandFromDropdown(Brand));
            return this;
        }

        private By GetBtnMoveDraft() => By.XPath(".//p[contains(text(),'Move draft')]");
        public DashboardPage ClicksOnMoveDraftToBrandOrDivision()
        {
            logger.Info("Clicking on move draft to brand or division");
            Click(GetBtnMoveDraft());
            return this;
        }

        public DashboardPage ValidateBrandPresent(String Brand)
        {
            logger.Info("Validating brand is present");
            Click(GetDropdownBrand());
            Assert.IsTrue(IsElementVisible(GetBrandFromDropdown(Brand)), "Failed to validate Brand is present");
            return this;
        }

        private By GetOptionSelectBrand(String BrandName) => By.XPath($".//p[contains(text(),'{BrandName}')]");

        public DashboardPage SelectBrand(String BrandName)
        {
            logger.Info("Selecting brand");
            Click(GetOptionSelectBrand(BrandName));
            return this;
        }

        private By GetBtnHamburger() => By.XPath(".//header//span[@class='mud-icon-button-label']");
        public DashboardPage ClickOnHamburger()
        {
            logger.Info("Clicking on Hamburger");
            Click(GetBtnHamburger());
            return this;
        }

        private By GetOptionOverview() => By.XPath(".//div[text()='Overview']");
        public DashboardPage ClickOverview()
        {
            logger.Info("Clicking on Hamburger");
            Click(GetOptionOverview());
            return this;
        }


        private By GetBtnSignOut() => By.XPath(".//div[text()='Sign out']");
        public DashboardPage ClickOnSignOut()
        {
            logger.Info("Clicking on Sign-out");
            Click(GetBtnSignOut());
            return this;
        }

        private By GetBtnEditDraft(String CampaignName) => By.XPath($".//div[contains(@class,'w-100')]//h4[contains(text(),'{CampaignName}')]/parent::div/parent::div//a");

        public CreateCampaignPage ClickEditDraft(String CampaignName){
            logger.Info("Clicking on Edit draft");
            Click(GetBtnEditDraft(CampaignName));
            return new CreateCampaignPage();
        }

        private By GetBtnSeeYourOrder(String CampaignName) => By.XPath($".//div[contains(@class,'w-100')]//h4[contains(text(),'{CampaignName}')]/parent::div/parent::div//a");
        public CampaignDraftSummaryPage ClickSeeYourOrder(String CampaignName)
        {
            logger.Info("Clicking on Edit draft");
            Click(GetBtnSeeYourOrder(CampaignName));
            return new CampaignDraftSummaryPage();
        }

        private By GetBtnEditBrand(String BrandName) => By.XPath($".//p[contains(text(),'{BrandName}')]/../parent::div//button");
        private By GetBtnNavigateToNextBrandsList() => By.XPath(".//button[contains(@class,'page-button')][2]");

        public AddBrandsDivisionPage ClickEditBrand(String brandName)
        {
            ShortWait();
            if(FindCreatedBrand(brandName))
            {
                logger.Info("Clicking on edit brand");
                MouseOver(GetBtnEditBrand(brandName));
                Click(GetBtnEditBrand(brandName));
            } else
            {
                logger.Info("Failed to find created brand");
            }
            return new AddBrandsDivisionPage();
        }

        public DashboardPage ValidateBrandDeleted(String BrandName) {
            logger.Info("Validating brand deleted");
            while (IsElementClickable(GetBtnNavigateToNextBrandsList()))
            {
                if (IsElementExist(GetBtnEditBrand(BrandName)))
                {
                    logger.Error("Someting is wrong Brand is not deleted");
                }
                else {
                    Assert.IsTrue(!IsElementExist(GetBtnEditBrand(BrandName)), "Failed to Validate Brand is deleted");
                    Click(GetBtnNavigateToNextBrandsList()); }
            }
            return this;
        }

        private By GetBrandElement() => By.XPath(".//div[contains(@class, 'd-flex flex-row justify-space-between gap')]//p");
        private By GetBrandArrowElement() => By.XPath("//button[contains(@class, ' mud-button-filled-size-large shadow-1 page-button')]");
        private bool FindCreatedBrand(String brandName)
        {
            bool flagFoundBrand = false;
            int countOfBrandElements = 0;
            while (! flagFoundBrand)
            {
                IList<IWebElement> brandElements = FindElements(GetBrandElement());
                countOfBrandElements = brandElements
                    .Where(b => GetText(b).Equals(brandName, StringComparison.OrdinalIgnoreCase))
                    .ToList().Count;

                if (countOfBrandElements > 0)
                {
                    flagFoundBrand = true;
                    break;
                } else
                {
                    Click(FindElements(GetBrandArrowElement()).ElementAt(1));
                }
            }
            return flagFoundBrand;
        }

        public DashboardPage ValidateCampaignClosed(String CampaignName)
        {
            logger.Info("Validating campaign closed");
            ClickOnEllipsisIconForOnGoingCampaign(CampaignName);
            String GetClassAttributeValue = GetAttributeByValue("class", GetBtnCloseCampaign());
            if (GetClassAttributeValue.Contains("mud-list-item-disabled")) {
                logger.Info("Campaign Closed Successfully");
            }
            else { logger.Error("Failed to valiedate campaign closed, check manually"); }
            return this;
        }

        private By GetAutomatedCampaignElement(String draftNameSubString, int index) => 
            By.XPath(".//h5[text()='Drafts']/following-sibling::div//h4[contains(text(), '"+draftNameSubString + "')]["+index+"]");

        private By GetAutomatedDraftCampaignElement(String draftNameSubString) =>
            By.XPath(".//h5[text()='Drafts']/following-sibling::div//h4[contains(text(), '" + draftNameSubString + "')]");

        public void FindAndDeleteDrafts(String draftNameSubString)
        {
            logger.Info("Deleting all draft");

            int deletedCampCount = 0;
            IList<IWebElement> listOfDraftElements = FindElements(GetAutomatedDraftCampaignElement(draftNameSubString));
            for(int i = 1; i <= listOfDraftElements.Count; i++)
            {
                Console.WriteLine("Deleted :" + deletedCampCount);
                ClickOnInfluriHeader();
                ClickOnEllipsisIcon(GetText(GetAutomatedDraftCampaignElement(draftNameSubString)));
                ClickOnDeleteDraft();
                deletedCampCount++;
            }

        }
        public void DeleteAllDraft(String draftNameSubString)
        {
            FindAndDeleteDrafts(draftNameSubString);

        }

        public DashboardPage ValidateAllCampaignDraftDeletedSuccessfully(String campaignNameSubString)
        {
            logger.Info("Validating campaign draft is not present");
            int count = FindElements(GetAutomatedDraftCampaignElement(campaignNameSubString)).Count;
            Assert.IsTrue((count < 1), "All drafts not deleted, still remaining :" + count);
            return this;
        }

        private By GetCampaignTile(String campaignName) => By.XPath($".//div[contains(@class,'w-100')]//h4[contains(text(),'{campaignName}')]/parent::div/parent::div//div[contains(@class,'shadow-1 w-100')]");

        public CampaignOverviewAndReportPage OpenCreatedCampaign(String campaignName) {
            //this method is used when campaign is created from Atlas and wants to open campaign
            logger.Info("Opening created campaign");
            Click(GetCampaignTile(campaignName));
            return new CampaignOverviewAndReportPage();
        }

        public DashboardPage NaviagteToCustomer(){
            SwitchToFirstTab();
            new CampaignConfirmationPage().GoToDashboard();
            RefreshBrowser();
            return this;
        }

    }
}
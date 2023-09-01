using InflueriAutomation.Core;
using InflueriAutomation.Pages.Core;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.BrandsDivison
{
    public class AddBrandsDivisionPage : BaseTestPage
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        private By GetInputNewBrand() => By.XPath(".//div[contains(@class,'w-100 mt-2')]//div[contains(@class,'mud-input')]//input");
        public AddBrandsDivisionPage EnterNewBrandName(String brandName)
        {
            logger.Info("Entering brand name");
            SetValue(brandName, GetInputNewBrand());
            return this;
        }

        private By GetBtnAddBrand() => By.XPath(".//button[contains(@class,'w-100 mt-8')]//span");
        public DashboardPage ClickOnAddBrand()
        {
            logger.Info("Clicking on add brand");
            Click(GetBtnAddBrand());
            return new DashboardPage();
        }

        private By GetDropdownForMoveDraftToBrandOrDivision(String Brand) => By.XPath($".//div[@class='mud-list mud-list-padding']//p[contains(text(),'{Brand}')]");
        private By GetBrandsDropdown() => By.XPath("//div[@class='w-100 pt-2']//div[contains(@class,'mud-input-adorned-end')]");
        public AddBrandsDivisionPage SelectBrandsFromDropdown(String BrandName)
        {
            logger.Info("Selecting brand from dropdown");
            Click(GetBrandsDropdown());
            Click(GetDropdownForMoveDraftToBrandOrDivision(BrandName));
            return this;
        }

        private By GetBtnMoveCampaign() => By.XPath(".//button//label[normalize-space()='Move campaign']");
        public DashboardPage ClickMoveCampaign()
        {
            logger.Info("Clicking on move campaign");
            Click(GetBtnMoveCampaign());
            return new DashboardPage();
        }

        private By GetBtnDeleteBrand() => By.XPath("//span[contains(text(),'Delete brand')]/parent::button");

        public DashboardPage ClickDeleteBrand() {
            Click(GetBtnDeleteBrand());
            return new DashboardPage() ;
        }
    }
}

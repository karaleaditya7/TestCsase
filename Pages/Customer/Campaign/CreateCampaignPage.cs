using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InflueriAutomation.Core;
using InflueriAutomation.DataUtils;
using InflueriAutomation.Pages.Core;
using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using InflueriAutomation.Models;
using InflueriAutomation.Enums;

namespace InflueriAutomation.Pages.Campaign
{
    public class CreateCampaignPage : BaseTestPage
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        public CreateCampaignPage EnterBasicInfo(Models.Campaign campaignData)
        {
            logger.Info("Entering basic info");
            SetCompanyName(campaignData.CompanyName);
            SetWebsiteUrl(campaignData.WebsiteUrl);
            SelectCurrencyDropdown(campaignData.BudgetCurrency);
            EnterBudget(campaignData.BudgetAmount);
            SelectIndustry(campaignData.Industry);
            return this;
        }

        private By GetCampaignNameInput() => By.XPath(".//div[contains(text(), 'Campaign Name')]/../following-sibling::div[1]//input");

        public CreateCampaignPage SetCampaignName(String value)
        {
            logger.Info("Entering campaign name");
            SetValue(value, GetCampaignNameInput());
            return this;
        }

        private By GetCompanyNameInput() => By.XPath(".//div[contains(text(), 'Company Name')]/../following-sibling::div[1]//input");

        public CreateCampaignPage SetCompanyName(String value)
        {
            logger.Info("Entering company name");
            SetValue(value, GetCompanyNameInput());
            return this;
        }

        private By GetWebsiteInput() => By.XPath(".//div[contains(text(), 'Website Url')]/../following-sibling::div[1]//input");

        public CreateCampaignPage SetWebsiteUrl(String value)
        {
            logger.Info("Entering website url");
            SetValue(value, GetWebsiteInput());
            return this;
        }

        private By GetIndustryDropdown() => By.XPath("//div[normalize-space()='Industry']/../following-sibling::div[@class=\"mud-select\"]//div[contains(@class,'mud-input-adornment')]");
        private By GetIndustryElement(String industry) => By.XPath($"//p[text()='{industry}']");

        public CreateCampaignPage SelectIndustry(String industry)
        {
            logger.Info("Selecting Industry");
            ScrollToElement(GetWebsiteInput());
            Click(GetIndustryDropdown());
            Click(GetIndustryElement(industry));
            return this;
        }

        private By GetInputComapnyName() => By.XPath("//div[normalize-space()='Company Name']/../following-sibling::div[@class=\"w-100 \"][1]//input");

        public CreateCampaignPage EnterComapanyName(String input)
        {
            logger.Info("Entering Company name");
            SetValue(input, GetInputComapnyName());
            return this;
        }

        private By GetInputWebsiteURL() => By.XPath("//div[normalize-space()='Website Url']/../following-sibling::div[@class=\"w-100 \"]//input");

        public CreateCampaignPage EnterWebsiteURL(String input)
        {
            logger.Info("Entering Website URL");
            SetValue(input, GetInputWebsiteURL());
            return this;
        }

        private By GetInputPurpose() => By.XPath("//div[normalize-space()='Campaign invitation intro text']/../following-sibling::div[@class=\"w-100 \"]//textarea");

        public CreateCampaignPage EnterPurpose(String purpose)
        {
            logger.Info("Entering purpose of the campaign");
            SetValue(purpose, GetInputPurpose());
            return this;
        }

        private By GetInputCountry() => By.XPath("//div[normalize-space()='Geographic Targeting']/../following-sibling::div[contains(@class,\"mud-tooltip-inline w-100\")]//input");
        private By GetCountryFromDropdown(String Country) => By.XPath($".//h6[@class='mud-typography mud-typography-subtitle2']//strong[text()='{Country}']");
        private By GetSelectedCountry() => By.XPath(".//button[contains(@class,'mud-ripple px-3')]");
        public CreateCampaignPage SelectCountry(String country)
        {
            logger.Info("Selecting country");
            if (IsElementNotVisible(GetSelectedCountry()))
            {
                SetValue(country, GetInputCountry());
                Click(GetCountryFromDropdown(country));
                
            }
            else
            {
                ScrollToElement(GetInputCountry());
                Click(GetSelectedCountry());
                SetValue(country, GetInputCountry());
                Click(GetCountryFromDropdown(country));
            }
            return this;
        }

        public CreateCampaignPage EnterTargetAudienceInfo(Models.Campaign campaignData){
            logger.Info("Enetering Target audience info");
            SelectCountry(campaignData.Country);
            return this;
        }

        public CreateCampaignPage EnterProductOrServiceInfo(Models.Campaign campaignData)
        {
            logger.Info("Entering product/service info");
            EnterProductName(campaignData.Product);
            EnterProductWebsiteURL(campaignData.WebsiteUrl);
            SetProductValue(campaignData.ProductValue);
            return this;
        }

        private By GetInputProductName() => By.XPath("//input[@placeholder='Name of product']");
        public CreateCampaignPage EnterProductName(String productName)
        {
            logger.Info("Entering product name");
            SetValue(productName, GetInputProductName());
            return this;
        }

        private By GetInputProductWebsiteURL() => By.XPath("//input[@placeholder='Product website url']");
        public CreateCampaignPage EnterProductWebsiteURL(String productURL)
        {
            logger.Info("Entering website URL");
            SetValue(productURL, GetInputProductWebsiteURL());
            return this;
        }

        private By GetInputProductValue() => By.XPath($".//div[contains(text(),'Value')]/../..//div[contains(@class,'mud-input-adorned-end')]//input");
        public CreateCampaignPage SetProductValue(int value)
        {
            logger.Info("Entering product value");
            SetValue(value, GetInputProductValue());
            HitTabButton(GetInputProductValue());
            return this;
        }



        private By GetBtnCreateCampaign() => By.XPath("//button//span[normalize-space()='Create Campaign']");
        public CreateCampaignPage ClickCreateCampaign()
        {
            logger.Info("Clicking on create campaign button");
            MediumWait();
            Click(GetBtnCreateCampaign());
            return new CreateCampaignPage();
        }

        private By GetLabelThankyou() => By.XPath("//h2[normalize-space()='Thank you!']");

        private By GetLabelCalender() => By.XPath(".//h6//div[contains(text(),'Publication period')]");
        private By GetDatePickerElement(String Date) => By.XPath($".//div[@class='mud-picker-calendar-container'][2]//button[contains(@class,'mud-button-root mud-icon-button') and not(contains(@class,'mud-hidden'))]//p[text()='{Date}']/..");

        public CreateCampaignPage SetPublicationPeriod(int fromDate, int toDate)
        {
            logger.Info("Selecting publication period");
            ScrollToElement(GetLabelCalender());

            Boolean isEnabledFrom = IsElementEnabled(GetDatePickerElement(fromDate.ToString()));
            Boolean isEnabledTo = IsElementEnabled(GetDatePickerElement(toDate.ToString()));
            while (!isEnabledFrom || !isEnabledTo)
            {
                if (!isEnabledFrom)
                {
                    fromDate += 2;
                    isEnabledFrom = IsElementEnabled(GetDatePickerElement(fromDate.ToString()));
                }

                if (!isEnabledTo)
                {
                    toDate += 2;
                    isEnabledTo = IsElementEnabled(GetDatePickerElement(toDate.ToString()));
                }
            }
                Click(GetDatePickerElement(fromDate.ToString()));
                Click(GetDatePickerElement(toDate.ToString()));
            return this;
        }
        


        private By GetBtnSaveDraft() => By.XPath("//button//span[normalize-space()='Save Draft']");

        public CreateCampaignPage ClickSaveDraft()
        {
            logger.Info("Clicking save draft");
            Click(GetBtnSaveDraft());
            return this;
        }

        public CreateCampaignPage ValidateCampaignName(String ExpectedText)
        {
            logger.Info("Validating campaign name");
            String ActualText = GetAttributeByValue("value", GetCampaignNameInput());
            Assert.AreEqual(ExpectedText, ActualText, "Failed to validate campaign name");
            return this;
        }

        public CreateCampaignPage ValidateCompanyName(String ExpectedText)
        {
            logger.Info("Validating company name");
            String ActualText = GetAttributeByValue("value", GetCompanyNameInput());
            Assert.AreEqual(ExpectedText, ActualText, "Failed to validate company name");
            return this;
        }

        private By GetCurrencyDropdown() => By.XPath(".//div[@class='d-flex flex-row align-start gap-3 mb-5']//div[contains(@class,'mud-input-root-adorned-end mud')]");
        private By GetCurrencyFromDropdown(String Currency) => By.XPath($"//p[text()='{Currency}']");
        public CreateCampaignPage SelectCurrencyDropdown(String Currency)
        {
            logger.Info("Selecting Currentcy From dropdown");
            Click(GetCurrencyDropdown());
            Click(GetCurrencyFromDropdown(Currency));
            return this;
        }

        private By GetInputBudget() => By.XPath(".//div[contains(@class,'d-flex flex-row align')]//div[contains(@class,'w-100')]//input");
        public CreateCampaignPage EnterBudget(long Budget)
        {
            logger.Info("Entering budget");
            SetValue(Budget, GetInputBudget());
            return this;
        }


        private By GetPurposeSection(String Purpose) => By.XPath($"//h5[text()='{Purpose}']");

        public CreateCampaignPage SelectPurpose(String Purpose)
        {
            logger.Info("Selecting purpose");
            Click(GetPurposeSection(Purpose));
            return this;
        }

        public CreateCampaignPage EnterPuproseInfo(Models.Campaign campaignData)
        {
            logger.Info("Entering purpose");
            SelectPurpose(campaignData.PurposeSection);
            EnterPurpose(campaignData.Purpose);
            return this;
        }

        private By GetFormatSection(String FormatSection) => By.XPath($".//Label//h6[contains(text(),'{FormatSection}')]");
        public CreateCampaignPage SelectFormat(Models.Campaign campaignData)
        {
            logger.Info("Selecting Format");
            ScrollToElement(GetInputPurpose());
            Click(GetFormatSection(campaignData.Format));
            return this;
        }

        private By GetInputKeyWordForInfluencerMatching() => By.XPath("//div[normalize-space()='Keywords For Influencer Matching']/../following-sibling::div//div[contains(@class,\"mud-input\")]//input");
        private By GetOptionSocialMediaPosts(String Option) => By.XPath($".//strong[contains(text(),'{Option}')]/../../../../..//div[contains(@class,'mud-t')]//span[@class='mud-fab-label']");
        private By GetSocialMediaPlatformOption(String Option) => By.XPath($".//h6[contains(text(),'{Option}')]");
        public CreateCampaignPage SelectSocialMediaPlatform(String socialMediaPlatform, List<String> posts)
        {
            logger.Info("Select social media and posts");
            ScrollToElement(GetInputKeyWordForInfluencerMatching());
            Click(GetSocialMediaPlatformOption(socialMediaPlatform));
            switch (socialMediaPlatform.ToUpper())
            {
                case "INSTAGRAM":
                    int counter = 0;
                    foreach (String post in posts)
                    {
                        if (counter < 3)
                        {
                            ScrollToElement(GetSocialMediaPlatformOption(socialMediaPlatform));
                            Click(GetOptionSocialMediaPosts(post));
                        } else
                        {
                            logger.Info("Instagram posts can not be more than 3 ");
                            break;
                        }
                        counter++;
                    }                   
                    break;
                case "TIKTOK":
                    int postCount = 0;
                    foreach (String post in posts)
                    {
                        if (postCount < 2)
                        {
                            Click(GetOptionSocialMediaPosts(post));
                        }
                        else
                        {
                            logger.Info("Tiktok posts can not be more than 3 ");
                            break;
                        }
                        postCount++;
                    }
                    break;
                default:
                    logger.Info("Invalid social media platform: " + socialMediaPlatform);
                    return this;
            }
            return this;
        }

    }
}

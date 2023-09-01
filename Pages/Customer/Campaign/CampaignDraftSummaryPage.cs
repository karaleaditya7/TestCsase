using InflueriAutomation.Core;
using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace InflueriAutomation.Pages.Campaign
{
    public class CampaignDraftSummaryPage : BaseTestPage
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private By GetCampaignName() => By.XPath(".//h5[contains(text(),'Campaign name')]/parent::div//p");

        public CampaignDraftSummaryPage ValidateCampaignName(String ExpectedText)
        {
            logger.Info("Validating Campaign Name");
            String ActualText = GetText(GetCampaignName());
            ActualText = ActualText.TrimEnd();
            Assert.IsTrue(ActualText.Contains(ExpectedText),"Failed to validate Campaign name.");
            return this;
        }

        private By GetCompanyName() => By.XPath(".//h5[contains(text(),'Company name')]/parent::div//p");

        public CampaignDraftSummaryPage ValidateCompanyName(String ExpectedText)
        {
            logger.Info("Validating Company Name");
            String ActualText = GetText(GetCompanyName());
            ActualText = ActualText.TrimEnd();
            Assert.IsTrue(ActualText.Contains(ExpectedText), "Failed to validate Company name.");
            return this;
        }

        private By GetWebsiteUrl() => By.XPath(".//h5[contains(text(),'Website URL')]/parent::div//p");

        public CampaignDraftSummaryPage ValidateWebsiteUrl(String ExpectedText)
        {
            logger.Info("Validating Wesite URL");
            String ActualText = GetText(GetWebsiteUrl());
            ActualText = ActualText.TrimEnd();
            Assert.IsTrue(ActualText.Contains(ExpectedText), "Failed to validate Website URL.");
            return this;
        }

        private By GetBudget() => By.XPath(" .//h5[contains(text(),'Budget')]/parent::div//p");

        public CampaignDraftSummaryPage ValidateBudget(long ExpectedText)
        {
            logger.Info("Validating Campaign Budget");
            String ActualText = GetText(GetBudget());
            ActualText = ActualText.TrimEnd();
            Assert.IsTrue(ActualText.Contains(ExpectedText.ToString()), "Budget validation failed.");
            return this;
        }

        private By GetIndustry() => By.XPath(".//h5[contains(text(),'Industry')]/parent::div//p");

        public CampaignDraftSummaryPage ValidateIndustry(String ExpectedText)
        {
            logger.Info("Validating Industry Name");
            String ActualText = GetText(GetIndustry());
            ActualText = ActualText.TrimEnd();
            Assert.IsTrue(ActualText.Contains(ExpectedText),"Failed to validate Industry");
            return this;
        }

        private By GetPurpose() => By.XPath(".//h5[contains(text(),'Purpose')]/parent::div//p");

        public CampaignDraftSummaryPage ValidatePurpose(String ExpectedText)
        {
            logger.Info("Validating Purpose Name");
            String ActualText = GetText(GetPurpose());
            ActualText = ActualText.TrimEnd();
            Assert.IsTrue(ActualText.Contains(ExpectedText), "Failed to validate Purpose");
            return this;
        }

        private By GetProductOrServiceWebsiteUrl() => By.XPath(".//h5[contains(text(),'Website Url')]/parent::div//p");

        public CampaignDraftSummaryPage ValidateProductOrServiceWebsiteUrl(String ExpectedText)
        {
            logger.Info("Validating Product/Service Website URL");
            String ActualText = GetText(GetProductOrServiceWebsiteUrl());
            ActualText = ActualText.TrimEnd();
            Assert.IsTrue(ActualText.Contains(ExpectedText), "Failed to validate Product/Service Website URL");
            return this;
        }

        private By GetProductValue() => By.XPath(".//h5[contains(text(),'Value')]/parent::div//p");

        public CampaignDraftSummaryPage ValidateProductValueWithoutCurrency(String ExpectedText)
        {
            logger.Info("Validating Product value");
            String ActualText = GetText(GetProductValue());
            ActualText = ActualText.Substring(0, ActualText.Length - 6);
            Assert.IsTrue(ActualText.Equals(ExpectedText), "Failed to validate Product Value");
            return this;
        }

        private By GetSocialMediaPlatform() => By.XPath(".//h5[contains(text(),'Social Media Platform')]/parent::div//p");
        public CampaignDraftSummaryPage ValidateSocialMediaPlatform(String ExpectedText)
        {
            logger.Info("Validating Social media platform");
            String ActualText = GetText(GetSocialMediaPlatform());
            ActualText = ActualText.TrimEnd();
            Assert.AreEqual(ActualText, ExpectedText, "Failed to validate Social media platform");
            return this;
        }

        private By GetFormat() => By.XPath(".//h5[contains(text(),'Format')]/parent::div//p");
        public CampaignDraftSummaryPage ValidateFormat(String ExpectedText) 
        {
            logger.Info("Validating Campaign Format");
            String ActualText = GetText(GetFormat());
            ActualText = ActualText.TrimEnd();
            Assert.IsTrue(ActualText.Contains(ExpectedText), "Failed to validate Format");
            return this;
        }

        private By GetGeographicalTergeting() => By.XPath(".//h5[contains(text(),'Geographical Targeting')]/parent::div//p");

        public CampaignDraftSummaryPage ValidateGeographicalTarget(String ExpectedText)
        {
            logger.Info("Validating Targeted Country");
            String ActualText = GetText(GetGeographicalTergeting());
            ActualText = ActualText.TrimEnd();
            Assert.IsTrue(ActualText.Contains(ExpectedText), "Failed to validate Country");
            return this;
        }

        private By GetLabelCampaignInfo() => By.XPath(".//h4[contains(text(),'Campaign Info')]");

        public CampaignDraftSummaryPage ValidateCampaignInfo(Models.Campaign campaignData) {
            logger.Info("Validating Campaign info");
            ScrollToElement(GetLabelCampaignInfo());
            ValidateCampaignName(campaignData.CampaignName);
            ValidateCompanyName(campaignData.CompanyName);
            ValidateWebsiteUrl(campaignData.WebsiteUrl);
            ValidateIndustry(campaignData.Industry);
            return this;
        }

        private By GetLabelProductServiceInfo() => By.XPath(".//h4[contains(text(),'Product/Service')]");
        public CampaignDraftSummaryPage ValidateProductOrServiceInfo(Models.Campaign campaignData) {
            logger.Info("Validating Product/Service info");
            ScrollToElement(GetLabelProductServiceInfo());
            ValidateProductValueWithoutCurrency(campaignData.ProductValue.ToString());
            return this;
        }

        private By GetLabelSocialMedia() => By.XPath(".//h4[contains(text(),'Social Media')]");
        public CampaignDraftSummaryPage ValidateSocialMediaInfo(String platform,Models.Campaign campaignData) {
            logger.Info("Validating social media info");
            ScrollToElement(GetLabelSocialMedia());
            ValidateSocialMediaPlatform(platform);
            ValidateFormat(campaignData.Format);
            return this;
        }

        private By GetLabelTargetAudience() => By.XPath(".//h4[contains(text(),'Target Audience')]");
        public CampaignDraftSummaryPage ValidateTargetAudience(Models.Campaign campaignData) {
            logger.Info("Validating Target audience info");
            ScrollToElement(GetLabelTargetAudience()); 
            ValidateGeographicalTarget(campaignData.Country);
            return this;
        }
    }
}

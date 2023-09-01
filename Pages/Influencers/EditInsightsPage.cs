using InflueriAutomation.Core;
using InflueriAutomation.Pages.Influencers.CampaignOverview;
using NLog;
using OpenQA.Selenium;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.Influencers
{
    public class EditInsightsPage : Initializer
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private By GetInputAccountReached() => By.XPath(".//input[@placeholder='Accounts Reached']");

        public EditInsightsPage EnterNoOFAccountsReached(int input) {
            logger.Info("Entering no of account reached");
            SetValue(input,GetInputAccountReached());
            return this;
        }

        private By GetInputImpressions() => By.XPath(".//input[@placeholder='Impressions']");

        public EditInsightsPage EnterNoOfImpressions(int input){
            logger.Info("Entering no of impression reached");
            SetValue(input,GetInputImpressions());
            return this;
        }

        private By GetInputLikes() => By.XPath(".//input[@placeholder='Likes']");

        public EditInsightsPage EnterNoOfLikes(int input){
            logger.Info("Entering no of likes");
            SetValue(input, GetInputLikes());
            return this;
        }

        private By GetInputComments() => By.XPath(".//input[@placeholder='Comments']");

        public EditInsightsPage EnterNoOfComments(int input){
            logger.Info("Entering no of comments");
            SetValue(input, GetInputComments());
            return this;
        }

        private By GetInputSaves() => By.XPath(".//input[@placeholder='Saves']");

        public EditInsightsPage EnterNoOfSaves(int input) {
            logger.Info("Entering no of saves");
            SetValue(input ,GetInputSaves());
            return this;
        }

        private By GetInputShares() => By.XPath(".//input[@placeholder='Shares']");

        public EditInsightsPage EnterNoOfShares(int input) {
            logger.Info("Entering no of shares");
            SetValue (input ,GetInputShares());
            return this;
        }

        private By GetButtonUpload() => By.XPath(".//span[contains(text(),'Upload')]/..");

        public InsightsPage UploadInsights() {
            logger.Info("Clicking on upload insights");
            Click(GetButtonUpload());
            return new InsightsPage();
        }

        private By GetButtonCancel() => By.XPath(".//span[contains(text(),'Cancel')]/..");

        public InsightsPage CancelUploadInsights() {
            logger.Info("Cancelling upload insights");
            Click(GetButtonCancel());
            return new InsightsPage();
        }

        private By GetInputProposalScreenshot() => By.XPath("//form//input[@id='imageInput']");

        public EditInsightsPage SelectAndUploadFile(String filePath)
        {
            IWebElement input = FindElementCustom(GetInputProposalScreenshot());

            string remoteFilePath = "file://" + filePath.Replace("\\", "/");

            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)GetWebDriver();
            jsExecutor.ExecuteScript("document.getElementById('imageInput').removeAttribute('hidden');");

            SetValue(filePath, GetInputProposalScreenshot());
            return this;
        }

        public InsightsPage EnterAllInsights(int input,String path) {
            SelectAndUploadFile(path);
            EnterNoOFAccountsReached(input);
            EnterNoOfImpressions(input);
            EnterNoOfLikes(input);
            EnterNoOfComments(input);
            EnterNoOfSaves(input);
            EnterNoOfShares(input);
            UploadInsights();
            return new InsightsPage();
        }
    }
}

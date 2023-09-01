using InflueriAutomation.Core;
using NLog;
using OpenQA.Selenium;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace InflueriAutomation.Pages.Influencers.CampaignOverview
{
    public class InsightsPage : Initializer
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private By GetButtonEditInsights(String MediaOption) => By.XPath($".//div[text()='{MediaOption}']/..//button//label[contains(text(),'Edit')]");

        public EditInsightsPage EditInsights(String MediaOption){
            logger.Info("Clicking on edit insights");
            Click(GetButtonEditInsights(MediaOption));
            return new EditInsightsPage();
        }

        private By GetButtonUploadInsights(String MediaOption) => By.XPath($".//div[text()='{MediaOption}']//label[text()='Upload insights']");

        private By GetLabelSocialMediaOptions(String MediaOption) => By.XPath($".//div[text()='{MediaOption}']");

        public EditInsightsPage ClickUploadInsights(String MediaOption)
        {
            logger.Info("Clicking on upload insights");
            if (MediaOption.Contains(" "))
            {
                string[] words = MediaOption.Split(' ');
                for (int i = 1; i < words.Length; i++)
                {
                    words[i] = words[i].ToLower();
                }
               MediaOption = string.Join(" ", words);
            }
            Click(GetButtonUploadInsights(MediaOption));
            return new EditInsightsPage();
        }

        public InsightsPage UploadInsightsForProposal(String mediaChoice,int impressions,String filePath) {
            logger.Info("Uploading insights for Proposals");
            new CampaignOverviewPage().NavigateToInfluencers();
            new CampaignOverviewPage().NavigateToInsights();
            ClickUploadInsights(mediaChoice);
            new EditInsightsPage().EnterAllInsights(impressions, filePath);
            return this;
        }
    }
}

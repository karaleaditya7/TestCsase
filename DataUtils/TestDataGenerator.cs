using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InflueriAutomation.Models;
using InflueriAutomation.Providers;
using InflueriAutomation.DataUtils;

namespace InflueriAutomation.DataUtils
{
    public class TestDataGenerator
    {
        private static Campaign LoadCampaignDataProvider()
        {
            return DataProvider.Load<Campaign>("Campaign");
        }

        private static Campaign LoadEditedCampaignDataProvider()
        {
            return DataProvider.Load<Campaign>("EditCampaignDetails");
        }

        public static Campaign GenerateCampaignData()
        {
            Campaign campaignData = LoadCampaignDataProvider();

            return new Campaign(
                MockDataGenerator.GenerateCampaignName(),
                MockDataGenerator.GenerateCompanyName(),
                MockDataGenerator.GenerateWebsiteUrl(),
                campaignData.BudgetCurrency,
                30000,
                campaignData.Industry,
                MockDataGenerator.GenerateBrandName(),
                campaignData.Country,
                campaignData.Product,
                campaignData.PurposeSection,
                MockDataGenerator.GeneratePurpose(),
                campaignData.Format,
                campaignData.SocialMediaPostsForInstagram,
                campaignData.SocialMediaPostsForTiktok,
                campaignData.ProductValue,
                campaignData.FromDate,
                campaignData.ToDate
            );
        }

        public static Campaign GenerateEditCampaignData()
        {
            Campaign campaignDataEdit = LoadEditedCampaignDataProvider();

            return new Campaign(
                MockDataGenerator.GenerateCampaignName(),
                MockDataGenerator.GenerateCompanyName(),
                MockDataGenerator.GenerateWebsiteUrl(),
                campaignDataEdit.BudgetCurrency,
                15000,
                campaignDataEdit.Industry,
                campaignDataEdit.Brand,
                campaignDataEdit.Country,
                campaignDataEdit.Product,
                campaignDataEdit.PurposeSection,
                MockDataGenerator.GeneratePurpose(),
                campaignDataEdit.Format,
                campaignDataEdit.SocialMediaPostsForInstagram,
                campaignDataEdit.SocialMediaPostsForTiktok,
                campaignDataEdit.ProductValue,
                campaignDataEdit.FromDate,
                campaignDataEdit.ToDate
            );
        }
    }
}

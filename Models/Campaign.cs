using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Models
{
    public class Campaign
    {
        public String CampaignName { get; set; }
        public String CompanyName { get; set; }
        public String WebsiteUrl { get; set; }
        public String BudgetCurrency { get; set; }
        public long BudgetAmount { get; set; }
        public String Industry { get; set; }
        public String Brand { get; set; }
        public String Country { get; set; }
        public String Product { get; set; }
        public String PurposeSection { get; set; }
        public String Purpose { get; set; }
        public String Format { get; set; }
        public List<String> SocialMediaPostsForInstagram { get; set; }
        public List<String> SocialMediaPostsForTiktok { get; set; }
        public int ProductValue { get; set; }
        public int FromDate { get; set; }
        public int ToDate { get; set; }


        public Campaign(String campaignName, String companyName, String websiteUrl, String budgetCurrency, long budgetAmount, String industry, String brand, String country, String product, String purposeSection, String purpose, String format, List<String> socialMediaPostsForInstagram, List<String> socialMediaPostsForTiktok,int productValue,int fromDate, int toDate)
        {
            CampaignName = campaignName;
            CompanyName = companyName;
            WebsiteUrl = websiteUrl;
            BudgetCurrency = budgetCurrency;
            BudgetAmount = budgetAmount;
            Industry = industry;
            Brand = brand;
            Country = country;
            Product = product;
            PurposeSection = purposeSection;
            Purpose = purpose;
            Format = format;
            SocialMediaPostsForInstagram = socialMediaPostsForInstagram;
            SocialMediaPostsForTiktok = socialMediaPostsForTiktok;
            ProductValue = productValue;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}

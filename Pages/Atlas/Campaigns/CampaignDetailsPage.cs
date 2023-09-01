using InflueriAutomation.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.Atlas.Campaigns
{
    public class CampaignDetailsPage : Initializer
    {
        private By GetHyperLinkInfluencers() => By.XPath(".//a[text()='Influencers']");

        public CampaignInfluencersPage ClickOnInfluencers() {
            Click(GetHyperLinkInfluencers());
            return new CampaignInfluencersPage();
        }
    }
}

using InflueriAutomation.Core;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.Atlas.Drafts
{
    public class DraftInfluencersPage : BaseTestPage
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private By GetInputAddInfluencers() => By.XPath(".//textarea[@class='form-control']");
        private By GetBtnAttach() => By.XPath(".//button[normalize-space()='Attach']");

        public DraftInfluencersPage AddInfluencers(List<string> influencersList)
        {
            logger.Info("Adding influencers to campaign");
            StringBuilder influencersText = new StringBuilder();

            for (int i = 0; i < influencersList.Count; i++)
            {
                influencersText.Append(influencersList[i]);

                if (i < influencersList.Count - 1)
                {
                    influencersText.Append(", ");
                }

                SetValue(influencersText.ToString(), GetInputAddInfluencers());
                HitEnterButton(GetInputAddInfluencers());
            }

            Click(GetBtnAttach());
            MediumWait();
            return this;
        }

        public CampaignDraftDetailsPage NaviagteToCampaignDraftsDetailsPage() {
            logger.Info("Navigating to Drafts Details page");
            NaviagateToBackPage();
            return new CampaignDraftDetailsPage();
        }
    }
}

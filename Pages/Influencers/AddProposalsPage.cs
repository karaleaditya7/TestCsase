using InflueriAutomation.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.Influencers.CampaignOverview.Content
{
    public class AddProposalsPage : Initializer
    {
        private By GetSelectOptionForAddProposals(String socialMediaPost) => By.XPath($".//div[@role='dialog']//button//div[contains(normalize-space(), '{socialMediaPost}')]");

         private By GetButtonOk() => By.XPath("//button//span[contains(normalize-space(), 'Ok')]");

        public UploadProposalsPage SelectProposalType(String ProposalType)
        {
           Click(GetSelectOptionForAddProposals(ProposalType));
            Click(GetButtonOk());
           return new UploadProposalsPage();
        }

    }
}

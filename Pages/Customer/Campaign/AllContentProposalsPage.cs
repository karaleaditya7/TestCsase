using InflueriAutomation.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.Customer.Campaign
{
    public class AllContentProposalsPage : Initializer
    {
        private By GetOptionExpandProposals() => By.XPath(".//div[contains(@class,'square ml-4')]");

        public AllContentProposalsPage ExpandProposals() {
            Click(GetOptionExpandProposals());
            return this;
        }

        private By GetButtonApprove(String socialMediaChoice) => By.XPath($".//h6[contains(text(),'{socialMediaChoice}')]/..//button//span[contains(text(),'Approve')]");

        public AllContentProposalsPage ApproveProposal(String socialMediaChoice) {
            Click(GetButtonApprove(socialMediaChoice.ToLower()));
            return this;
        }

        private By GetButtonDecline(String socialMediaChoice) => By.XPath($".//h6[contains(text(),'{socialMediaChoice}')]/..//button//span[contains(text(),'Decline')]");

        public AllContentProposalsPage DeclineProposal(String socialMediaChoice) {
            Click(GetButtonDecline(socialMediaChoice));
            return this;
        }

        private By GetButtonBoost(String socialMediaChoice) => By.XPath($".//h6[contains(text(),'{socialMediaChoice}')]/..//span[normalize-space()='Boost']");

        public BoostPage BoostProposal(String socialMediaChoice) {
            Click(GetButtonBoost(socialMediaChoice));
            return new BoostPage();
        }

        private By GetButtonComments(String socialMediaChoice) => By.XPath($".//h6[contains(text(),'{socialMediaChoice}')]/..//button//span[contains(text(),'Comment')]");

        public ProposalCommentsPage OpenComments(String socialMediaChoice) {
            Click(GetButtonComments(socialMediaChoice));
            return new ProposalCommentsPage();
        }

        private By GetButtonBoostAgain(String socialMediaChoice) => By.XPath($".//h6[contains(text(),'{socialMediaChoice}')]/..//span[normalize-space()='Boost Again']");

        public BoostPage BoostAgain(String socialMediaChoice) {
            Click(GetButtonBoostAgain(socialMediaChoice));
            return new BoostPage();
        }

        private By GetLabelCampaign(String campaignName) => By.XPath($".//h6[contains(text(),'{campaignName}')]");

        public CampaignOverviewAndReportPage naviagteToCampaignOverview(String campaignName) {
            SwitchToFirstTab();
            RefreshBrowser();
            Click(GetLabelCampaign(campaignName));
            return new CampaignOverviewAndReportPage();
        }
    }
}

using InflueriAutomation.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.Customer.Campaign
{
    public class ProposalCommentsPage : Initializer
    {
        private By GetButtonCloseComments() => By.XPath(".//div[contains(@class,'mud-dialog')]//span[contains(@class,'mud-icon-button-label')]");

        public AllContentProposalsPage CloseComments() {
            Click(GetButtonCloseComments());
            return new AllContentProposalsPage();
        }

        private By GetInputAddComment() => By.XPath(".//textarea[contains(@class,'comment-area')]");

        public ProposalCommentsPage EnterComment(String comment) {
            SetValue(comment, GetInputAddComment());
            return this;
        }

        private By GetButtonPostComment() => By.XPath(".//span[contains(text(),'Post')]");

        public ProposalCommentsPage PostComment() {
            Click(GetButtonPostComment());
            return this;
        }
    }
}

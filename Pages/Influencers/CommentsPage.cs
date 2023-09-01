using InflueriAutomation.Core;
using InflueriAutomation.Pages.Influencers.CampaignOverview;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.Influencers
{
    public class CommentsPage : Initializer
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private By GetButtonNavigateToContent() => By.XPath("//div[contains(@class,'d-flex flex-row gap-3 w-100 h-100')]//button");

        public ContentPage NavigateToContent() {
            logger.Info("Navigating to Content");
            Click(GetButtonNavigateToContent());
            return new ContentPage();
        }

        private By GetInputAddComment() => By.XPath(".//textarea[@placeholder='Add a comment']");

        public CommentsPage EnterComments(String comment) {
            logger.Info("Entering Comments");
            SetValue(comment, GetInputAddComment());
            return this;
        }

        private By GetButtonPostComment() => By.XPath(".//span[contains(text(),'Post')]/..");

        public CommentsPage PostComment() {
            logger.Info("Posting comments");
            Click(GetButtonPostComment());
            return this;
        }
    }
}

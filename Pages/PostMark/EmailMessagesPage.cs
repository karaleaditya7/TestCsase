using InflueriAutomation.Core;
using InflueriAutomation.Pages.Influencers;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.PostMark
{
    public class EmailMessagesPage : Initializer
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private By GetButtonSeeMission() => By.XPath(".//a[contains(text(),'See mission')]");

        private By GetIframe() => By.XPath("//div[@class='email-preview_html']//iframe");

        public YourMissionPage ClickSeeMission() {
            logger.Info("Clicking on See mission");
            SwitchToIframe(GetIframe());
            ScrollToElement(GetButtonSeeMission());
            HitControlClick(GetButtonSeeMission());
            SwitchToNextTab();
            return new YourMissionPage();
        }

        private By GetButtonActivity() => By.XPath(".//a[text()='Activity']");

        public EmailInboxPage ClickActivity()
        {
            logger.Info("Clicking activity Button");
            Click(GetButtonActivity());
            return new EmailInboxPage();
        }

    }
}

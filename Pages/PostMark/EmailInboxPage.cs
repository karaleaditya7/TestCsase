using InflueriAutomation.Core;
using NLog;
using OpenQA.Selenium;
using PostmarkDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.PostMark
{
    public class EmailInboxPage : Initializer
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private By GetInputMail() => By.XPath(".//input[@id='f_query']");

        public EmailInboxPage SearchEmail(String Subject,String companyName)
        {
            logger.Info("Searching an Email");
            SetValue(Subject+" "+companyName, GetInputMail());
            HitEnterButton(GetInputMail());
            return this;
        }

        private By GetExpectedMail(String receipient) => By.XPath($".//a[contains(text(),'{receipient}')]/parent::div/..//a[text()='Delivered']/../../../..//div[contains(@class,'message_subject')]");
        public EmailMessagesPage OpenEmail(String recipient) {
            logger.Info("Opening desired Email");
            LongWait();
            RefreshBrowser();
            Click(GetExpectedMail(recipient));
            return new EmailMessagesPage();
        }

        public EmailInboxPage NavigateToInbox() {
            logger.Info("Navigating to Inbox");
            NaviagateToBackPage();
            return this;
        }

        public async Task<EmailInboxPage> GetExpectedMailAsync(String recipientAddress,String subject)
        {
            logger.Info("Getting expected mail");
            var client = new PostmarkClient("<server token>");

            var matchedInboundMessages = await client
                .GetInboundMessagesAsync(0, 100, recipientAddress,
                null,
                subject);
            return this;
        }
    }
}

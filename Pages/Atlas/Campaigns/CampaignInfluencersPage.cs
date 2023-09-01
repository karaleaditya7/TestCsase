using AventStack.ExtentReports;
using InflueriAutomation.Core;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.Atlas.Campaigns
{
    public class CampaignInfluencersPage : Initializer
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private By GetButtonEditInfluencerInfo() => By.XPath(".//button[@class='btn btn-secondary btn-sm']");

        public EditInfluencersInfoPage EditInfluencer() {
            logger.Info("Clicking on Editing Influencer");
            Click(GetButtonEditInfluencerInfo());
            return new EditInfluencersInfoPage();
        }

        private By GetCheckboxInfluencer() => By.XPath(".//td//input[@type='checkbox']");

        public CampaignInfluencersPage SelectInfluencer()
        {
            logger.Info("Selecting Influencer");
            try
            {
                Click(GetCheckboxInfluencer());
                logger.Error("Catching Stale element reference exception");
            }
            catch (StaleElementReferenceException)
            {
                RefreshBrowser();
                Click(GetCheckboxInfluencer());
               
            }
            catch (NoSuchElementException)
            {
                logger.Error("Influencer checkbox not found");
            }
            return this; // Exit the method if successful
        }

        private By GetActionMenu() => By.XPath(".//button[contains(@class,'btn btn-secondary')]//span[contains(@class,'document')]");

        public CampaignInfluencersPage OpenActionMenu() {
            Click(GetActionMenu());
            return this;
        }

        private By GetOptionSendInvitation() => By.XPath(".//a[contains(text(),'Send invitations')]");

        public CampaignInfluencersPage ClickOptionSendInvitation()
        {
            Click(GetOptionSendInvitation());
            return this;
        }

        private By GetButtonSendInvitation() => By.XPath(".//button[contains(text(),'Send invitation')]");

        public CampaignInfluencersPage SendInvitation()
        {
            Click(GetButtonSendInvitation());
            return this;
        }

        public CampaignInfluencersPage SendInvitationToInfluencers() {
            logger.Info("Sending invitation to influencers");
            SelectInfluencer();
            OpenActionMenu();
            ClickOptionSendInvitation();
            SendInvitation();
            return this;
        }
    }
}

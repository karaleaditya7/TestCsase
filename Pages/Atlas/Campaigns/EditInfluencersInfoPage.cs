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
    public class EditInfluencersInfoPage : Initializer
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private By GetInputSearchInfluencers() => By.XPath(".//table[@class='table table-sm']//input");

        private By GetButtonSearch() => By.XPath(".//button[text()='Search']");

        public EditInfluencersInfoPage SearchInfluencersName(string name) {
            logger.Info("Selecting influencers email from dropdown");
            Click(GetInputSearchInfluencers());
            SetValue(name, GetInputSearchInfluencers());
            Click(GetButtonSearch());
            return this;
        }

        private By GetButtonAdd() => By.XPath(".//button[text()='Add']");

        public EditInfluencersInfoPage ClickOnAddName(){
            logger.Info("Clicking on Add name");
            Click(GetButtonAdd());
            return this;
        }

        private By GetInputEmailAddress() => By.XPath(".//textarea"); 
        public EditInfluencersInfoPage EnterEmailAddress(String email)
        {
            SetValue(email,GetInputEmailAddress());
            return this;
        }

        private By GetInputBaseCompensation() => By.XPath(".//label[text()='Base compensation']/..//input");

        public EditInfluencersInfoPage EnterBaseCompensation(long BaseCompensation)
        {
            SetValue(BaseCompensation, GetInputBaseCompensation());
            return this;
        }

        private By GetInputIndividualCompensation() => By.XPath(".//label[text()='Individual compensation']/..//input");

        public EditInfluencersInfoPage EnterIndividualCompensation(long IndividualCompensation)
        {
            SetValue(IndividualCompensation, GetInputIndividualCompensation());
            return this;
        }

        private By GetInputTotalCompensation() => By.XPath(".//label[text()='Total compensation']/..//input");

        public EditInfluencersInfoPage EnterTotalCompensation(long TotalCompensation)
        {
            SetValue(TotalCompensation, GetInputTotalCompensation());
            return this;
        }

        private By GetButtonSaveInfluencers() => By.XPath(".//button[text()='Save influencer']");

        public EditInfluencersInfoPage SaveInfluencer() {
            Click(GetButtonSaveInfluencers());
            return this;
        }

        public EditInfluencersInfoPage ConfigureInfluencers(String email, long compensation) {
            logger.Info("Configuring influencers");
            new CampaignDetailsPage().ClickOnInfluencers();
            new CampaignInfluencersPage().EditInfluencer();
            SearchInfluencersName(email);
            ClickOnAddName();
            EnterEmailAddress(email);
            EnterBaseCompensation(compensation);
            EnterIndividualCompensation(compensation);
            EnterTotalCompensation(compensation);
            SaveInfluencer();
            return this;

        }
    }
}

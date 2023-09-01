using InflueriAutomation.Core;
using InflueriAutomation.Pages.Core;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.Campaign
{
    public class CampaignConfirmationPage : BaseTestPage
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private By GetBtnGoBackToDashboard() => By.XPath("//button//span[normalize-space()='Go back to dashboard']");

        public DashboardPage ClickGoBackToDashboard()
        {
            logger.Info("Clicking on go back to dashboard");
            Click(GetBtnGoBackToDashboard());
            return new DashboardPage();
        }

        private By GetBtnGoToDashboard() => By.XPath("//button//span[contains(text(),'dashboard')]");

        public DashboardPage GoToDashboard()
        {
            logger.Info("Navigating to dashboard");
            Click(GetBtnGoToDashboard());
            return new DashboardPage();
        }
    }
}

using InflueriAutomation.Core;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.Influencers
{
    public class YourMissionPage : Initializer
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private By GetButtonAcceptInvitation() => By.XPath(".//span//label[normalize-space()='Accept']");

        public YourMissionPage ClickAcceptInvitation() {
            logger.Info("Clicking on Accept invitation");
            Click(GetButtonAcceptInvitation());
            return this;
        }
    }
}

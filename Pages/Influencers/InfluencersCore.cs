using InflueriAutomation.Core;
using InflueriAutomation.Models;
using InflueriAutomation.Pages.Core;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.Influencers
{
    public class InfluencersCore : Initializer
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        public InfluencersCore LoginInfluencer(User userData)
        {
            logger.Info("Influencer user login....");
            new LoginPage().SetUsername(userData.Email).SetPassword(userData.Password).ClickContinue();
            return this;
        }
    }
}

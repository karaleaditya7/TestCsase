using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InflueriAutomation.Core;
using InflueriAutomation.Models;
using InflueriAutomation.Pages.Atlas.Drafts;
using InflueriAutomation.Pages.Core;
using InflueriAutomation.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InflueriAutomation.Tests
{
    [TestClass]
    public class CampaignDraftAtlastTests : Initializer
    {

        [TestMethod]
        public void AttachInfluencers()
        {
            User userData = new User
            {
                Email = ConfigurationProvider.EnvConfig.CustomerEmail,
                Password = ConfigurationProvider.EnvConfig.CustomerPassword
            };

            String atlasLoginUrl = ConfigurationProvider.EnvConfig.AtlasUrl;
            NavigateTo(atlasLoginUrl);

            new LoginAtlasPage().Login2(userData, new HomeAtlasPage());     
        }
    }
}

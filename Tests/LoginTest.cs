using System;
using AventStack.ExtentReports;
using InflueriAutomation.Enums;
using InflueriAutomation.Core;
using InflueriAutomation.Models;
using InflueriAutomation.Pages.Core;
using InflueriAutomation.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.IO;
using NLog;
using InflueriAutomation.Pages.Influencers;
using InflueriAutomation.Pages.PostMark;

namespace InflueriAutomation.Tests
{
    [TestClass]
    public class LoginTest : Initializer
    {
        DashboardPage dashboardPage;
        LoginPage loginPage = new LoginPage();
        LoginPagePostmark login=new LoginPagePostmark();
        EmailInboxPage emailEventsPage;

        [TestMethod("Validate customer login with valid credentials"), TestCategory("Regression")]
        public void LoginTest_Valid_User()
        {
            ExtentTestLogger.AssignCategory(EnumDescription.GetEnumDescription(TestCategory.OnboardingLogin));

            ExtentTestLogger.Log(Status.Pass, "Login to the app as customer");
            dashboardPage = LoginShared();

            ExtentTestLogger.Log(Status.Pass, "Validate login is successful");
            dashboardPage.ValidateLoginSuccess();

        }

        [TestMethod("Validate Logout successfully"), TestCategory("Regression")]
        public void Validate_Logout_Successfully()
        {
            ExtentTestLogger.AssignCategory(EnumDescription.GetEnumDescription(TestCategory.OnboardingLogin));

            ExtentTestLogger.Log(Status.Pass, "Login to the app as customer");
            dashboardPage = LoginShared();

            ExtentTestLogger.Log(Status.Pass, "Click on Hamburger");
            dashboardPage.ClickOnHamburger();

            ExtentTestLogger.Log(Status.Pass, "Click on Sign-out");
            dashboardPage.ClickOnSignOut();

            ExtentTestLogger.Log(Status.Pass, "Validate Logout successfully");
            loginPage.ValidateLogoutSuccess();
        }

        public DashboardPage LoginShared()
        {
            User userData = new User
            {
                Email = ConfigurationProvider.EnvConfig.CustomerEmail,
                Password = ConfigurationProvider.EnvConfig.CustomerPassword
            };

            return  dashboardPage = loginPage.Login(userData);
        }

        public DashboardPage AtlasLogin()
        {
            User userData = new User
            {
                Email = ConfigurationProvider.EnvConfig.AtlasEmail,
                Password = ConfigurationProvider.EnvConfig.AtlasPassword
            };

            ExtentTestLogger.Log(Status.Pass, "Login to the Atlas Module");
            return dashboardPage = loginPage.Login(userData);
        }

        public InfluencersCore InfluencersLogin()
        {
            User userData = new User
            {
                Email = ConfigurationProvider.EnvConfig.InfluencerEmail,
                Password = ConfigurationProvider.EnvConfig.InfluencerPassword
            };

            ExtentTestLogger.Log(Status.Pass, "Login to the Influencers Module");
            return new InfluencersCore().LoginInfluencer(userData);
        }

        public EmailInboxPage PostmarkLogin()
        {
            User userData = new User
            {
                Email = ConfigurationProvider.EnvConfig.PostmarkUsername,
                Password = ConfigurationProvider.EnvConfig.PostmarkPassword
            };

            ExtentTestLogger.Log(Status.Pass, "Login to the Postmark");
            return emailEventsPage = login.LoginInPostmark(userData);
        }
    }


}

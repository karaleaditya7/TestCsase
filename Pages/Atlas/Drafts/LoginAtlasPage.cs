using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InflueriAutomation.Core;
using InflueriAutomation.Models;
using InflueriAutomation.Pages.Atlas.Drafts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;

namespace InflueriAutomation.Pages.Core
{
    public class LoginAtlasPage : BaseTestPage 
    {

        Logger logger = LogManager.GetCurrentClassLogger();

        private By GetUserNameInput() => By.XPath(".//input[@id='username']");
        public LoginAtlasPage SetUsername(String userEmail)
        {
            logger.Info("Entering email as username");
            SetValue(userEmail, GetUserNameInput());
            return this;
        }

        private By GetPasswordInput() => By.XPath(".//input[@id='password']");
        public LoginAtlasPage SetPassword(String password)
        {
            logger.Info("Entering password");
            SetValue(password, GetPasswordInput());
            return this;
        }

        private By GetContinueButton() => By.XPath(".//button[@name='action' and @data-action-button-primary ]");
        public HomeAtlasPage ClickContinue()
        {
            logger.Info("Clicking continue button");
            Click(GetContinueButton());
            return new HomeAtlasPage();
        }

        public T ClickContinue2<T>(T landingPage)
        {
            logger.Info("Clicking continue button");
            Click(GetContinueButton());
            return landingPage;
        }


        private By GetLogInLink() => By.XPath(".//a[text()='Log in']");
        public LoginAtlasPage ClickLogin()
        {
            logger.Info("Clicking log in link");
            Click(GetLogInLink());
            return this;
        }

        public HomeAtlasPage Login(User userData)
        {
            logger.Info("User login....");
            return SetUsername(userData.Email)
                .SetPassword(userData.Password).ClickContinue();
        }

        public T Login2<T>(User userData, T landingPage)
        {
            logger.Info("User login....");
            return SetUsername(userData.Email)
                .SetPassword(userData.Password).ClickContinue2(landingPage);
        }

        public LoginAtlasPage ValidateLogoutSuccess()
        {
            logger.Info("Validate login button present");
            Assert.IsTrue(IsElementVisible(GetLogInLink()), "Logout test failed");
            return this;
        }
    }
}

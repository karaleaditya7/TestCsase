using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InflueriAutomation.Core;
using InflueriAutomation.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;

namespace InflueriAutomation.Pages.Core
{
    internal class LoginPage : BaseTestPage 
    {

        Logger logger = LogManager.GetCurrentClassLogger();

        private By GetUserNameInput() => By.XPath(".//input[@id='username']");
        public LoginPage SetUsername(String userEmail)
        {
            logger.Info("Entering email as username");
            SetValue(userEmail, GetUserNameInput());
            return this;
        }

        private By GetPasswordInput() => By.XPath(".//input[@id='password']");
        public LoginPage SetPassword(String password)
        {
            logger.Info("Entering password");
            SetValue(password, GetPasswordInput());
            return this;
        }

        private By GetContinueButton() => By.XPath(".//button[@name='action' and @data-action-button-primary ]");
        public DashboardPage ClickContinue()
        {
            logger.Info("Clicking continue button");
            Click(GetContinueButton());
            return new DashboardPage();
        }

        private By GetLogInLink() => By.XPath(".//a[text()='Log in']");
        public LoginPage ClickLogin()
        {
            logger.Info("Clicking log in link");
            Click(GetLogInLink());
            return this;
        }

        public DashboardPage Login(User userData)
        {
            logger.Info("User login....");
            return ClickLogin().SetUsername(userData.Email)
                .SetPassword(userData.Password).ClickContinue();
        }

        public LoginPage ValidateLogoutSuccess()
        {
            logger.Info("Validate login button present");
            Assert.IsTrue(IsElementVisible(GetLogInLink()), "Logout test failed");
            return this;
        }
    }
}

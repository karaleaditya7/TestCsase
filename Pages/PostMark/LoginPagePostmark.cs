using InflueriAutomation.Core;
using InflueriAutomation.Models;
using InflueriAutomation.Pages.Core;
using InflueriAutomation.Pages.Influencers;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Pages.PostMark
{
    public class LoginPagePostmark : Initializer
    {
        Logger logger = LogManager.GetCurrentClassLogger();

         private By GetInputUsername() => By.XPath(".//input[@id='user_session_login']");
        public LoginPagePostmark SetUsername(String userEmail)
        {
            logger.Info("Entering email as username");
            SetValue(userEmail, GetInputUsername());
            return this;
        }

        private By GetInputPassword() => By.XPath(".//input[@id='user_session_password']");
        public LoginPagePostmark SetPassword(String password)
        {
            logger.Info("Entering password");
            SetValue(password, GetInputPassword());
            return this;
        }

        private By GetButtonLogin() => By.XPath(".//button[contains(text(),'Log In')]");
        public EmailInboxPage ClickContinue()
        {
            logger.Info("Clicking continue button");
            Click(GetButtonLogin());
            return new EmailInboxPage();
        }

        public EmailInboxPage LoginInPostmark(User userData)
        {
            logger.Info("PostMark user login....");
          return SetUsername(userData.Email)
                .SetPassword(userData.Password)
                .ClickContinue();
            
        }
    }
}

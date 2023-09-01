using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InflueriAutomation.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace InflueriAutomation.Pages.Atlas.Drafts
{
    public class HomeAtlasPage : Initializer
    {
        private By GetHeaderElement() => By.XPath("//h1[contains(text(), 'Welcome to your new app')");

        public HomeAtlasPage ValidateLoginSuccessful()
        {
            Assert.IsTrue(IsElementVisible(GetHeaderElement()), "Atlas login failed");
            return this;
        }
    }
}

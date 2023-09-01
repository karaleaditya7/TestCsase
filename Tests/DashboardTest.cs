using AventStack.ExtentReports;
using InflueriAutomation.Core;
using InflueriAutomation.DataUtils;
using InflueriAutomation.Enums;
using InflueriAutomation.Models;
using InflueriAutomation.Pages.BrandsDivison;
using InflueriAutomation.Pages.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Tests
{
    [TestClass]
    public class DashboardTest : Initializer
    {
        DashboardPage dashboardPage;

        [TestMethod("Validate overview on dashboard"), TestCategory("Regression")]
        public void Validate_Overview_Menu_Option_In_Navigation_Panel()
        {
            ExtentTestLogger.AssignCategory(EnumDescription.GetEnumDescription(TestCategory.Dashboard));

            ExtentTestLogger.Log(Status.Pass, "Login to the app as customer");
            dashboardPage = new LoginTest().LoginShared();

            ExtentTestLogger.Log(Status.Pass, "Click hamburger");
            dashboardPage.ClickOnHamburger();

            ExtentTestLogger.Log(Status.Pass, "Clicks on overview");
            dashboardPage.ClickOverview();

            ExtentTestLogger.Log(Status.Pass, "Login to the app as customer");
            dashboardPage.ValidateDashboardVisible();

        }
    }
}

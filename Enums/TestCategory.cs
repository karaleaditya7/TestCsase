using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Enums
{
    public enum TestCategory
    {
        Regression,
        Smoke,
        Sanity,

        [Description("Onboarding & Login")]
        OnboardingLogin,

        [Description("Dashboard")]
        Dashboard,

        [Description("Campaign")]
        Campaign,

        [Description("Brand/Division")]
        BrandOrDivision,
    }

}

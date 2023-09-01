using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Bogus.DataSets;
using InflueriAutomation.Core;

namespace InflueriAutomation.DataUtils
{
    public class MockDataGenerator : BaseTestPage
    {
        static Faker faker = new Faker("en");
        const String namePrefix = "TestAuto_";

        public static String GenerateCampaignName()
        {
            Logger.Info("Generating random campaign name");
            return $"{namePrefix}Campaign_" + faker.Random.String2(10);
        }

        public static String GenerateCompanyName()
        {
            Logger.Info("Generating random company name");
            return $"{namePrefix}Company_" + faker.Random.String2(10);
        }

        public static String GenerateWebsiteUrl()
        {
            Logger.Info("Generating random website url");
            return "http://www." + faker.Random.String2(10) + ".com";
        }

        public static String GeneratePurpose()
        {
            Logger.Info("generating random purpose");
            return "this is for demo " + faker.Random.String2(10) + ".";
        }

        public static String GenerateBrandName()
        {
            Logger.Info("Generating random brand name");
            return $"{namePrefix}Brand_" + faker.Random.String2(10);
        }
    }
}

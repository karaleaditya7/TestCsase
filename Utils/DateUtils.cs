using InflueriAutomation.DataUtils;
using InflueriAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Utils
{
    internal class DateUtils
    {
        static String _dateFormat_yyyy_mm_dd = "yyyy/MM/dd/";
        public static String GetDateTimeStampNoFormat()
        {
            return DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "");
        }

        public static String GetTodaysDate()
        {
            DateTime now = DateTime.Today;
            return now.ToString(_dateFormat_yyyy_mm_dd);
        }

        public static String GetYesterDayDate()
        {
            DateTime now = DateTime.Today.AddDays(-1);
            return now.ToString(_dateFormat_yyyy_mm_dd);
        }

        public static String GetTomorrowDate()
        {
            DateTime now = DateTime.Today.AddDays(1);
            return now.ToString(_dateFormat_yyyy_mm_dd);
        }

        public static int GetFromDate()
        {
            DateTime currentDate = DateTime.Now;
            Campaign campaignData = TestDataGenerator.GenerateCampaignData();
            int daysToAdd = Math.Min(campaignData.FromDate, 30);
            DateTime targetFromDate = currentDate.AddDays(daysToAdd);
            int targetFromDay = targetFromDate.Day;
            return targetFromDay;
        }

        public static int GetToDate()
        {
            DateTime currentDate = DateTime.Now;
            Campaign campaignData = TestDataGenerator.GenerateCampaignData();
            int daysToAdd = Math.Min(campaignData.ToDate, 30);
            DateTime targetToDate = currentDate.AddDays(daysToAdd);
            int targetToDateDay = targetToDate.Day;
            return targetToDateDay;
        }
    }
}

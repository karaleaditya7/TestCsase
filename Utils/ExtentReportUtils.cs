using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace InflueriAutomation.Utils
{
    public class ExtentReportUtils
    {

        private static String _fileName;

        private static ExtentReports _extentReports = ExtentReportUtils.CreateInstance();
        private static ThreadLocal<ExtentTest> extentTest = new ThreadLocal<ExtentTest>();
        public static ExtentTest ExtentTestHandle {get; set;}

        public static void SetExtentTest(ExtentTest value)
        {
            extentTest.Value = value;
        }

        public static ExtentTest GetExtentTest()
        {
            return extentTest.Value;
        }

        public static ExtentReports GetInstance()
        {
            if (_extentReports == null)
                CreateInstance();
            return _extentReports;
        }

        public static String GetReportFileName()
        {
            return _fileName;
        }

        private static void SetReportFileName(String name)
        {
            _fileName = name;
        }

        //Create an extent report instance
        public static ExtentReports CreateInstance()
        {
            String dateTime = DateUtils.GetDateTimeStampNoFormat();
            String reportName = "Influeri_ " + dateTime + ".html";
            String reportDir = Path.Combine(FileUtils.GetProjectRootPath(), "Reports" , reportName);
            SetReportFileName(reportDir);
            ExtentReports extentReports = new ExtentReports();
            ExtentHtmlReporter extentHtmlReporter = new ExtentHtmlReporter(reportDir);

            extentHtmlReporter.Config.Theme = Theme.Dark;
            extentHtmlReporter.Config.DocumentTitle = "Influeri Automation Report";
            extentHtmlReporter.Config.Encoding = "utf-8";
            extentHtmlReporter.Config.ReportName = "Influeri Automation Report";
            extentHtmlReporter.Config.EnableTimeline = true;    

            extentReports.AttachReporter(extentHtmlReporter);

            return extentReports;
        }
    }
}

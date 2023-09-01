using InflueriAutomation.Enums;

namespace InflueriAutomation.Models
{
    public class WebDriverConfiguration
    {
        public BrowserName BrowserName { get; set; }
        public string ScreenshotsPath { get; set; }
        public int DefaultTimeout { get; set; }
        public string BrowserLanguage { get; set; }
    }
}
using System;
using System.IO;
using InflueriAutomation.Models;
using Newtonsoft.Json.Linq;
using NLog;

namespace InflueriAutomation.Providers
{
    public class ConfigurationProvider
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        private const String WebDriverConfigSectionName = "webdriver";
        private const String RunConfigSectionName = "runConfiguration";

        private const String FilePath = @"TestConfig.json";
        private const String FilePathOverride = @"..\..\TestConfigOverride.json";
        private static readonly String SettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath);
        private static readonly String SettingsPathOverride = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath);

        public static WebDriverConfiguration WebDriverConfig =>
            Load<WebDriverConfiguration>(SettingsPath, WebDriverConfigSectionName);

        public static RunConfiguration EnvironmentConfig =>
            Load<RunConfiguration>(SettingsPath, RunConfigSectionName);

        public static EnvConfiguration EnvConfig =>
            Load<EnvConfiguration>(SettingsPath, EnvironmentConfig.Env);

        public static WaitConfig WaitConfig =>
            Load<WaitConfig>(SettingsPath, "wait");

        private static T Load<T>(String jsonFilePath, String sectionName)
        {
            string executablePath = System.Reflection.Assembly.GetEntryAssembly().Location;
            string baseDirectory = Path.GetDirectoryName(executablePath);
            string projectDirectory = Path.GetDirectoryName(baseDirectory);
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            try
            {
                return JObject.Parse(File.ReadAllText(jsonFilePath)).SelectToken(sectionName).ToObject<T>();
            }
            catch (Exception ex)
            {
                logger.Info("Failed to load config JSON file : " + ex.Message);
                throw;
            }
        }

        
    }
}

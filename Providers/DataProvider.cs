using System;
using System.IO;
using Newtonsoft.Json;

namespace InflueriAutomation.Providers
{
    public static class DataProvider
    {
        public static T Load<T>(String filename)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(Path.Combine(AppDomain
                .CurrentDomain
                .BaseDirectory,
                $@"TestData/{filename}.json")));
        }
    }
}

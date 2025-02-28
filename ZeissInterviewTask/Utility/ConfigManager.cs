using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZeissInterviewTask.Utility
{
    public class ConfigManager
    {
        private static IConfiguration _config { get; set; }
        public ConfigManager()
        {
            _config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("Config.json", optional: false, reloadOnChange: true)
                 .AddEnvironmentVariables()
                 .Build();
        }

        /// <summary>
        /// get the key value based on key name
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfiguration(string key)
        {
            return _config.GetValue<string>(key);
        }
        
    }
}

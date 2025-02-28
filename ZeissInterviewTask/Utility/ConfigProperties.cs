using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeissInterviewTask.Utility
{
    public class ConfigProperties
    {
        public static string AuthenticationAPI { get; set; } = ConfigManager.GetConfiguration("AuthenticationAPI");
    }
}

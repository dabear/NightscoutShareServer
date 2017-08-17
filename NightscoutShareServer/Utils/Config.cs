using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NightscoutShareServer.Utils
{
    public class Config
    {

        public static string NsHost => "https://bjorningedia4.herokuapp.com";
        //public static string NsHost => (Environment.GetEnvironmentVariable("NS_Host") ?? "").TrimEnd(new[] { '/' });
        public static bool EnableMockedGlucoseMode => Environment.GetEnvironmentVariable("Enable_Mocked_Mode")?.ToLower() == "true";
    }
}

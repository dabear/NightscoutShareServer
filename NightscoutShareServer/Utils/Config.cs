using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NightscoutShareServer.Utils
{
    public class Config
    {
        

        public static string NsHost => Environment.GetEnvironmentVariable("NS_Host") ?? "";
        public static bool EnableMockedGlucoseMode => Environment.GetEnvironmentVariable("Enable_Mocked_Mode") == "true";
    }
}
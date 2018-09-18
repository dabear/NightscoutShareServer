using System;
using System.IO;

namespace NightscoutShareServer.Utils
{

    public class ConfigProduction : IMyAppConfig
    {
        public ConfigProduction()
        {
        }

        public string NsHost => (Environment.GetEnvironmentVariable("NS_Host") ?? "").TrimEnd(new[] { '/' });
        public bool EnableMockedGlucoseMode => Environment.GetEnvironmentVariable("Enable_Mocked_Mode")?.ToLower() == "true";
    }

}

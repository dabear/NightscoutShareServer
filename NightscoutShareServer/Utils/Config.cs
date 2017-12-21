using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace NightscoutShareServer.Utils
{
    public class Config
    {
#if DEBUG
        private static string homedir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        //we want this to throw exception if file not found, so don't fall back to empty string here!
        public static string NsHost => File.ReadAllText(Path.Combine(homedir, "nshost.txt")).TrimEnd();
        public static bool EnableMockedGlucoseMode => false;
        public static string DebugViewLogSecret => "IWannaSeeMyLogs";

#else
        public static string DebugViewLogSecret => Environment.GetEnvironmentVariable("Log_Secret") ?? "");
        public static string NsHost => (Environment.GetEnvironmentVariable("NS_Host") ?? "").TrimEnd(new[] { '/' });
        public static bool EnableMockedGlucoseMode => Environment.GetEnvironmentVariable("Enable_Mocked_Mode")?.ToLower() == "true";
#endif
    }

}

using System;
using NightscoutShareServer.Utils;
namespace NightscoutShareServer
{
    
    public class Logger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void LogInfo(string msg) {
            if (Config.DebugViewLogSecret.Length > 11)
            {
                log.Info(msg);
            }
        }
    }
}

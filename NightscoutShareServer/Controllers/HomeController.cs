using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using NightscoutShareServer.Utils;
using System.IO;
using System.Globalization;
using System.Web.Hosting;

namespace NightscoutShareServer.Controllers
{
    public class HomeController : Controller
    {
      

        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";
            Logger.LogInfo("Accesing Home");
            return View();
        }

        public ActionResult ViewLogs()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";
            Logger.LogInfo("Accesing Logs");
            return View("LogsIndex");
        }

        [HttpPost]
        public ActionResult VerifyViewLog(string logsecret)
        {
            if(logsecret != null && logsecret.Length > 11 && Config.DebugViewLogSecret == logsecret) {
                var today = DateTime.Now.ToString("dddd", CultureInfo.InvariantCulture);
                var logfile = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Logs",$"{today}.log");

                try
                {
                    ViewBag.logdata = System.IO.File.ReadAllText(logfile);
                    return View("LogsIndex");
                } catch (Exception ex) {
                    return Content($"Could not read log file due to exception: {ex}");
                }
            }
            return View("Error");
        }

        /*
        Example flow from the official site
 Sending json {"accountName":"foo","password":"bar","applicationId":"d89443d2-327c-4a6f-89e5-496bbb0317db"}
 to endpoint https://share1.dexcom.com/ShareWebServices/Services/General/LoginPublisherAccountByName

Response from endpoint https://share1.dexcom.com/ShareWebServices/Services/General/LoginPublisherAccountByName:
"5b4f6f2f-5fc6-4cd7-a921-39ddedd4d24f"

Sending json post null to endpoint
https://share1.dexcom.com/ShareWebServices/Services/Publisher/ReadPublisherLatestGlucoseValues?sessionId=5b4f6f2f-5fc6-4cd7-a921-39ddedd4d24f&minutes=1440&maxCount=3

Response from endpoint
https://share1.dexcom.com/ShareWebServices/Services/Publisher/ReadPublisherLatestGlucoseValues?sessionId=5b4f6f2f-5fc6-4cd7-a921-39ddedd4d24f&minutes=1440&maxCount=3: [{"DT":"\/Date(1489768983000-0700)\/","ST":"\/Date(1489743783000)\/","Trend":4,"Value":104,"WT":"\/Date(1489743778000)\/"},{"DT":"\/Date(1489768442000-0700)\/","ST":"\/Date(1489743242000)\/","Trend":4,"Value":102,"WT":"\/Date(1489743237000)\/"},{"DT":"\/Date(1489768199000-0700)\/","ST":"\/Date(1489742999000)\/","Trend":4,"Value":102,"WT":"\/Date(1489742994000)\/"}]

*/
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

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

            return View();
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
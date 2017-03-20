using Newtonsoft.Json;
using NightscoutShareServer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NightscoutShareServer.Controllers
{
    public class GlucoseController : Controller
    {
        private bool CheckAuth(string sessionId)
        {
            //do any checks here to ensure users applicationid and sessionid is authenticated
            //currently there is no authentication needed to access this shareserver, so simply return true
            return true;
        }

        private string encodeGlucose(List<ShareGlucose> glucose)
        {
            var settings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };

            return JsonConvert.SerializeObject(glucose, settings);
        }

        private List<ShareGlucose> mockupGlucoseValues()
        {
            //examples on generating fake data
            var glucose = new List<ShareGlucose>();
            var now = DateTime.Now;
            var threeminsago = now - TimeSpan.FromMinutes(3);
            glucose.Add(
                new ShareGlucose { DT = now, ST = now, WT = now.ToUniversalTime(), Trend = (ShareGlucoseSlopeOrdinals)4, Value = 166 }
            );

            glucose.Add(
                new ShareGlucose { DT = now, ST = now, WT = now.ToUniversalTime(), Trend = ShareGlucoseSlopeOrdinals.UP_45, Value = 163 }
            );

            return glucose;
        }

        public ActionResult Index(string sessionId, string minutes, string maxCount)
        {
            //the minutes parameter is often 1440 (24 hours), telling you how long back you should do the search
            //In nightscout context it is mostly redundant as the maxCount will search as long back as needed.
            //we ignore that parameter

            sessionId = sessionId ?? "";
            int count = int.TryParse(maxCount, out count) ? count : 3;

            if (!this.CheckAuth(sessionId))
            {
                return Json("Some error validating sessionid!!", JsonRequestBehavior.AllowGet);
            }

            var glucose = mockupGlucoseValues();

            return Content(this.encodeGlucose(glucose), "application/json");
        }
    }
}
using Newtonsoft.Json;
using NightscoutShareServer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        private NightscoutPebble fetchNightscoutPebbleData(string baseurl, int count = 3)
        {
            var url = $"{baseurl}/pebble?count={count}&units=mgdl";
            var client = new WebClient();

            var contents = client.DownloadString(url);
            return JsonConvert.DeserializeObject<NightscoutPebble>(contents);
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

            //var glucose = mockupGlucoseValues();
            NightscoutPebble nsglucose = null;
            Exception lasterror = null;
            var i = 0;
            do
            {
                try
                {
                    nsglucose = this.fetchNightscoutPebbleData("https://XXXXX.azurewebsites.net", count);
                }
                catch (Exception err)
                {
                    lasterror = err;
                }

            } while (i++ < 2);

            if(lasterror != null)
            {
                throw lasterror;
            }
            var shareglucose = new List<ShareGlucose>();

            foreach (var entry in nsglucose.bgs)
            {
                var glucosedate = DateTimeOffset.FromUnixTimeMilliseconds(entry.datetime).DateTime;
                decimal val;
                Decimal.TryParse(entry.sgv, out val);

                var trend = SlopeConvert.NsDirectionToShareTrend(entry.direction);

                shareglucose.Add(
                new ShareGlucose
                {
                    DT = glucosedate,
                    ST = glucosedate,
                    WT = glucosedate.ToUniversalTime(),
                    Value = (int)val,
                    Trend = trend
                }

                );
            }

            return Content(this.encodeGlucose(shareglucose), "application/json");
        }
    }
}
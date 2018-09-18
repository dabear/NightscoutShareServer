using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NightscoutShareServer.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NightscoutShareServer.Api
{
    [Route("ShareWebServices/Services/Publisher/ReadPublisherLatestGlucoseValues")]
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
                new ShareGlucose { DT = threeminsago, ST = threeminsago, WT = threeminsago.ToUniversalTime(), Trend = ShareGlucoseSlopeOrdinals.UP_45, Value = 163 }
            );

            return glucose;
        }



        private List<NightscoutApiEntries> fetchNightscoutGlucoseEntries(string baseurl, int count = 3)
        {

            var url = $"{baseurl}/api/v1/entries.json?count={count}&units=mgdl&find[sgv][$gt]=0";
            var client = new WebClient();
            //Logger.LogInfo($"Calling url {url}");

            var contents = client.DownloadString(url);
            return JsonConvert.DeserializeObject<List<NightscoutApiEntries>>(contents);
        }


        public ActionResult Get(string sessionId, string minutes, string maxCount)
        {
            //the minutes parameter is often 1440 (24 hours), telling you how long back you should do the search
            //In nightscout context it is mostly redundant as the maxCount will search as long back as needed.
            //we ignore that parameter
            //Logger.LogInfo("Accesing Glucose Index");
            sessionId = sessionId ?? "";
            int count = int.TryParse(maxCount, out count) ? count : 3;

            if (!this.CheckAuth(sessionId))
            {
                //Logger.LogInfo($"Error in checking sessionId");
                return Json("Some error validating sessionid!!");
            }

            if (Config.Instance.EnableMockedGlucoseMode)
            {
               //Logger.LogInfo($"Mocking up glucose value");
                var glucose = mockupGlucoseValues();
                return Content(this.encodeGlucose(glucose), "application/json");
            }



            //NightscoutPebble nsglucose = null;
            List<NightscoutApiEntries> nsglucose = null;
            Exception lasterror = null;
            var i = 0;
            do
            {
                var n = i + 1;
                try
                {
                    //Logger.LogInfo($"Attempt {n} to fetch glucose from {Config.NsHost}");
                    nsglucose = this.fetchNightscoutGlucoseEntries(Config.Instance.NsHost, count);
                    //Logger.LogInfo($"Got {nsglucose.Count} entries from nightscout");
                    lasterror = null;
                }
                catch (Exception err)
                {
                    lasterror = err;
                }

            } while (i++ < 2 && lasterror != null);

            if (lasterror != null)
            {
                throw lasterror;
            }
            var shareglucose = new List<ShareGlucose>();

            foreach (var entry in nsglucose)
            {
                var glucosedate = DateTimeOffset.FromUnixTimeMilliseconds(entry.date).DateTime;
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


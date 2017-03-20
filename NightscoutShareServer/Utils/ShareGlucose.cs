using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace NightscoutShareServer.Utils
{
    //json2csharp.com
    internal class ShareGlucose
    {
        public DateTime DT { get; set; }
        public DateTime ST { get; set; }

        //public long Trend { get; set; }
        public ShareGlucoseSlopeOrdinals Trend { get; set; }

        //value should always be in mgdl
        public int Value { get; set; }

        public DateTime WT { get; set; }

        [JsonIgnore]
        public decimal ValueMgdl => this.Value;

        [JsonIgnore]
        public decimal ValueMmol => Decimal.Round(this.Value / 18.01559M, 1);

        [JsonIgnore]
        public DateTime LocalTime => this.WT.ToLocalTime();
    }
}
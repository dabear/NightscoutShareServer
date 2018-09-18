using System;
namespace NightscoutShareServer.Utils
{
    //json2csharp.com
    public class NightscoutApiEntries
    {
        //public string _id { get; set; }
        //public string device { get; set; }
        public long date { get; set; }
        //this should be datetime, but for some reason in some cgm-in-the-cloud instances it is not
        //we don't use the dateString for anything, so just convert it to string
        public string dateString { get; set; }
        public string sgv { get; set; }
        //public double delta { get; set; }
        public string direction { get; set; }
        //public string type { get; set; }
        //public int filtered { get; set; }
        //public int unfiltered { get; set; }
        //public int rssi { get; set; }
        //public int noise { get; set; }
        //public DateTime sysTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NightscoutShareServer.Utils
{
    public class NightscoutApiEntries
    {
        //public string _id { get; set; }
        //public string device { get; set; }
        public long date { get; set; }
        public DateTime dateString { get; set; }
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
    /*
    //json2csharp.com
    public class NightscoutPebble
    {
        public List<Status> status { get; set; }
        public List<Bg> bgs { get; set; }
        public List<Cal> cals { get; set; }
    }

    public class Status
    {
        public long now { get; set; }
    }

    public class Bg
    {
        public string sgv { get; set; }
        public int trend { get; set; }
        public string direction { get; set; }
        public long datetime { get; set; }
        public double filtered { get; set; }
        public double unfiltered { get; set; }
        public double noise { get; set; }
        public string bgdelta { get; set; }
        public string battery { get; set; }
    }

    public class Cal
    {
        public double slope { get; set; }
        public double intercept { get; set; }
        public double scale { get; set; }
    }*/
}
using HybridModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NightscoutShareServer.Models
{
    public class GlucoseModel
    {
        [From(Source.Body, Source.QueryString, Source.Route)]
        public string sessionId { get; set; } = "";

        [From(Source.Body, Source.QueryString, Source.Route)]
        public string minutes { get; set; } = "";

        [From(Source.Body, Source.QueryString, Source.Route)]
        public string maxCount { get; set; } = "";

       
    }
}

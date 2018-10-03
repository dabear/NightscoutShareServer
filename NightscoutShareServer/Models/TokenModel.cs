using HybridModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NightscoutShareServer.Models
{
    public class TokenModel
    {
        [From(Source.Body, Source.QueryString, Source.Route)]
        public string accountName { get; set; } 

        [From(Source.Body, Source.QueryString, Source.Route)]
        public string password { get; set; } 

        [From(Source.Body, Source.QueryString, Source.Route)]
        public string applicationId { get; set; } 
    }
}

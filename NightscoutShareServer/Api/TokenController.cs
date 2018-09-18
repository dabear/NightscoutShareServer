using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NightscoutShareServer.Api
{
    [Route("ShareWebServices/Services/General/LoginPublisherAccountByName")]
    public class TokenController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "tokenvalue1", "tokenvalue" };
        }


    }
}

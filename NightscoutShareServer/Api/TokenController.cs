using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HybridModelBinding;
using Microsoft.AspNetCore.Mvc;
using NightscoutShareServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NightscoutShareServer.Api
{
    [Route("ShareWebServices/Services/General/LoginPublisherAccountByName")]
    public class TokenController : Controller
    {
        public TokenController() { }
        private bool checkValidUser(string accountName, string password, string applicationId)
        {
            if (accountName.Length == 0 || password.Length == 0 || applicationId.Length == 0)
            {
                //Logger.LogInfo($"Invalid request, account or password was invalid");
                return false;
            }

            //future: do additional checks here
            //For now we just allow any combination of username and password
            return true;
        }

        private Guid createGuidAndStoreIt()
        {
            var g = Guid.NewGuid();
            //future: store the guid somewhere
            //For now we don't have any authentication, and accept any guid/sessionid for retrieving glucose
            //so just return it!
            //Logger.LogInfo($"Created GUID for user");
            return g;
        }

        // GET: api/values
        [HttpGet]
        [HttpPost]
        public ActionResult Get([FromHybrid]TokenModel model)
        {
            if(model == null)
            {
                return Json(
                new
                {
                    Error = "true",
                    Message = "You should specify an accountname, password and applicationid in a post to this endpoint"
                }
                );
            }

            
          
            if (this.checkValidUser(model.accountName??"", model.password ?? "", model.applicationId ?? ""))
            {
                
                return Json(this.createGuidAndStoreIt());
            }

            return Json(
                new
                {
                    Error = "true",
                    Message = "Check that parameters to this endpoint is correct. CheckValidUser failed"
                }
                );
        }
    }



}

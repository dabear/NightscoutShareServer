using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NightscoutShareServer.Controllers
{
    public class TokenController : Controller
    {
        private bool checkValidUser(string accountName, string password, string applicationId)
        {
            if (accountName.Length == 0 || password.Length == 0 || applicationId.Length == 0)
            {
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

            return g;
        }

        public ActionResult Index(string accountName, string password, string applicationId)
        {
            accountName = accountName ?? "";
            password = password ?? "";
            applicationId = applicationId ?? "";

            if (this.checkValidUser(accountName, password, applicationId))
            {
                return Json(this.createGuidAndStoreIt(), JsonRequestBehavior.AllowGet);
            }

            return Json(
                new
                {
                    Error = "true",
                    Message = "You should specify an accountname, password and applicationid in a post to this endpoint"
                },
                JsonRequestBehavior.AllowGet);
        }
    }
}
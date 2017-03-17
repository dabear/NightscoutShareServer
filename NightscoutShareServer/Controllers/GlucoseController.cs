using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NightscoutShareServer.Controllers
{
    public class GlucoseController : Controller
    {
        public ActionResult Index()
        {
            return Json("Not implemented!", JsonRequestBehavior.AllowGet);
        }
    }
}
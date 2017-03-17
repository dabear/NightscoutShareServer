using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NightscoutShareServer.Controllers
{
    public class TokenController : Controller
    {
        /*public ActionResult Index()
        {
            return View();
        }*/

        private static bool IsNullOrDefault<T>(T value)
        {
            return object.Equals(value, default(T));
        }

        public ActionResult Index(string accountName, string password, string applicationId)
        {
            if (IsNullOrDefault(accountName) || IsNullOrDefault(password) || IsNullOrDefault(applicationId))
            {
                return Json(
                new
                {
                    Error = "true",
                    Message = "You should specify an accountname, password and applicationid in a post to this endpoint"
                },
                JsonRequestBehavior.AllowGet);
            }

            var g = Guid.NewGuid();
            return Json(g, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NighscoutShareServer.Controllers
{
    public class TokenController : Controller
    {
        [HttpPost]
        [HttpGet]
        public ActionResult Index(string accountName, string password, string applicationId)
        {

            var guid = Guid.NewGuid();

            return Json(
                guid.ToString(), JsonRequestBehavior.AllowGet

            );
        }
        public ActionResult Index()
        {




            return Json(
                new
                {
                    Error = "true",
                    Message = "You should specify an accountname, password and applicationid in a post to this endpoint"
                },
                JsonRequestBehavior.AllowGet);
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
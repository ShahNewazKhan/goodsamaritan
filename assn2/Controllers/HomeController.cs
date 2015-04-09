using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace assn2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "ASP.net Assignment 3";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.name1 = "Aarin Smith / A00857633";
            ViewBag.name2 = "Shahnewaz Khan / A00261182";
            ViewBag.email1 = "aarinsmith@gmail.com";
            ViewBag.email2 = "shahnewazkhan@gmail.com";

            return View();
        }
    }
}
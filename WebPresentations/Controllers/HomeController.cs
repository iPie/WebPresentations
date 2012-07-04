using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPresentations.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Web Presentations template project";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}

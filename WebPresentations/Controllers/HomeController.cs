using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebPresentations.TagCloud;
using WebPresentations.Models;

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

        [HttpGet]
        public string GetTags()
        {
            var cloud = new TagCloud.TagCloud();
            var javaScriptSerializer = new JavaScriptSerializer();
            return javaScriptSerializer.Serialize(cloud.Cloud);
        }
    }
}

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
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            return javaScriptSerializer.Serialize(cloud.Cloud);
        }

        //[HttpGet]
        //public JsonResult GetTags()
        //{
        //    var cloud = new TagCloud.TagCloud();
        //    JsonResult answer = Json(cloud.Cloud);
        //    answer.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        //    return answer;
        //}
    }
}

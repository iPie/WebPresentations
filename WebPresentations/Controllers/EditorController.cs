using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPresentations.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace WebPresentations.Controllers
{
    public class EditorController : Controller
    {

        //
        // GET: /Editor/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Save/

        [HttpPost]
        public ActionResult Index(String Data)
        {
            return View();
        }

        //
        // GET: /Editor/Browse

        public ActionResult Browse()
        {
            return View();
        }
    }
}

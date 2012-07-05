using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Data.Entity;
using System.Web.Mvc;
using WebPresentations.Models;
using WebPresentations.ViewModels;

namespace WebPresentations.Controllers
{
    [Authorize]
    public class EditorController : Controller
    {
        PresentationsEntities presentationsDB = new PresentationsEntities();

        //
        // GET: /Editor/Index

        public ActionResult Index()
        {
            return View(presentationsDB.Presentations.ToList());
        }

        //
        // GET: /Create/

        public ActionResult Create()
        {
            return View();
        }

        //
        // GET: /Create/

        [HttpPost]
        public ActionResult Create(EditorViewModel model)
        {
            if (ModelState.IsValid)
            {

                var tags = (from string tag in Regex.Split(model.TagString, @"\s|,")
                            where tag != null
                            select new Tag { Text = tag }).ToList();
                var presentation = new Presentation
                                       {
                                           Title = model.Title,
                                           Description = model.Description,
                                           Json = model.Json,
                                           Tags = tags,
                                           UserName = User.Identity.Name
                                       };
                presentationsDB.Presentations.Add(presentation);
                presentationsDB.SaveChanges();
                return View("Success");
            }
            else
            {
                return View(model);
            }
        }

        protected override void Dispose(bool disposing)
        {
            presentationsDB.Dispose();
            base.Dispose(disposing);
        }
    }
}

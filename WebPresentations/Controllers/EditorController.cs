﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Services;
using WebPresentations.Models;
using WebPresentations.ViewModels;


namespace WebPresentations.Controllers
{
    [Authorize]
    public class EditorController : Controller
    {
        PresentationsEntities presentationsDB = new PresentationsEntities();

        //
<<<<<<< HEAD
        // GET: /Editor/Index

        public ActionResult Index()
        {
            return View(presentationsDB.Presentations.ToList());
        }
        
        //
        // GET: /Editor/Create
        
=======
        // GET: /Editor/Create/

>>>>>>> cd4c1e730c57201d81a7eb0ddc0c7abd27b1c95a
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Editor/Create/

        [HttpPost]
        public JsonResult Create(EditorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tags = new List<Tag>();
                foreach (var input in Regex.Split(model.TagString, @"\s|,"))
                {
                    var tagText = input.ToLower();
                    var tagExists = presentationsDB.Tags.Any(g => g.Text == tagText);
                    if (tagExists)
                    {
                        var tag = presentationsDB.Tags.First(g => g.Text == tagText);
                        tag.Count++;
                        tags.Add(tag);
                    }
                    else
                    {
                        tags.Add(new Tag { Text = tagText });
                    }
                }
                var presentation = new Presentation
                {
                    Title = model.Title,
                    Description = model.Description,
                    Json = model.Json,
                    Tags = tags,
                    UserName = User.Identity.Name
                };
                try
                {
                    presentationsDB.Presentations.Add(presentation);
                    presentationsDB.SaveChanges();
                }
                catch
                {
                    return Json("Fail");
                }
                return Json("Success");
            }
            return Json("Fail");
        }

        //
        // POST: /Editor/Preview/

        public ActionResult Preview()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            presentationsDB.Dispose();
            base.Dispose(disposing);
        }
    }
}

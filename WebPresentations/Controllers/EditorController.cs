using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        // GET: /Editor/View

        public ActionResult MyView()
        {
            return View();
        }

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

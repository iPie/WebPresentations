using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using WebPresentations.Caching;
using WebPresentations.Models;
using WebPresentations.ViewModels;


namespace WebPresentations.Controllers
{
    [Authorize]
    public class EditorController : EntityController
    {

        //
        // GET: /Editor/Create

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
                    var tagExists = Entities.Tags.Any(g => g.Text == tagText);
                    if (tagExists)
                    {
                        var tag = Entities.Tags.First(g => g.Text == tagText);
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
                    Entities.Presentations.Add(presentation);
                    Entities.SaveChanges();
                    var cm = new WebPresentationsCacheManager();
                    cm.Flush();
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
        // GET: /Editor/Preview/

        public ActionResult Preview()
        {
            return View();
        }
    }
}

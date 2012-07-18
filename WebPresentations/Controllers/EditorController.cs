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
                foreach (var input in Regex.Split(model.TagString, @"[,\s+]+"))
                {
                    var tagText = input.ToLower();
                    var tagExists = TagExists(tagText);
                    if (tagExists)
                    {
                        var tag = GetTag(tagText);
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
                    HtmlContents = model.HtmlContents,
                    TextData = model.TextData,
                    Tags = tags,
                    UserName = User.Identity.Name
                };
                try
                {
                    AddToPresentations(presentation);
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

        //
        // GET: /Editor/Edit?id=1

        public ActionResult Edit(int id)
        {
            var valid = UserOwnsPresentation(id);
            return valid ? View(GetPresentation(id)) : View("Error");
        }

        //
        // GET: /Editor/Delete?id=1

        public ActionResult Delete(int id)
        {
            if (UserOwnsPresentation(id))
            {
                try
                {
                    RemovePresentation(id);
                }
                catch
                {
                    return View("Error");
                }
            }
            return View("Error");
        }
    }
}

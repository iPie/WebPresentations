using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using WebPresentations.Caching;
using WebPresentations.DatabaseEntities;
using WebPresentations.Models;
using WebPresentations.ViewModels;


namespace WebPresentations.Controllers
{
    [Authorize]
    [HandleErrorWithELMAH]
    public class EditorController : EntityController
    {

        //
        // GET: /Editor/Create/

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
                var tags = Entities.ParseTags(model.TagString);
                var presentation = new Presentation
                {
                    Title = model.Title,
                    Description = model.Description,
                    Json = model.Json,
                    HtmlContents = model.HtmlContents,
                    Tags = tags,
                    UserName = User.Identity.Name
                };
                try
                {
                    Entities.AddToPresentations(presentation);
                    EntitiesIndexer.AddPresentationToIndex(presentation);
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
            ViewBag.Id = id;
            var valid = Entities.UserOwnsPresentation(id, User.Identity.Name);
            return valid ? View(Entities.GetPresentation(id)) : View("Error");
        }

        //
        // GET: /Editor/Delete?id=1

        public JsonResult Delete(int id)
        {
            if (Entities.UserOwnsPresentation(id, User.Identity.Name))
            {
                try
                {
                    Entities.RemovePresentation(id);
                    EntitiesIndexer.RemovePresentationFromIndex(id);
                }
                catch
                {
                    return Json(new { message = "Fail" });
                }
                return Json(new { message = "Success" });
            }
            return Json(new { message = "Fail" });
        }

        //
        // GET: /Editor/Update

        public JsonResult Update(int id, string jsonString, string htmlContents)
        {
            var presentation = Entities.GetPresentation(id);
            if (presentation != null)
            {
                if (Entities.UserOwnsPresentation(id, User.Identity.Name))
                {
                    try
                    {
                        presentation.Json = jsonString;
                        presentation.HtmlContents = htmlContents;
                        Entities.Update();
                        EntitiesIndexer.UpdatePresentationIndex(presentation);
                        var cm = new WebPresentationsCacheManager();
                        cm.Flush();
                    }
                    catch
                    {
                        return Json(new {message = "Fail"});
                    }
                    return Json(new {message = "Success"});
                }
            }
            return Json(new { message = "Fail" });
        }
    }
}

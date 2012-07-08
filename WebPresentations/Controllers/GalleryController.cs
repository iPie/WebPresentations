using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WebPresentations.Models;

namespace WebPresentations.Controllers
{
    public class GalleryController : Controller
    {
        PresentationsEntities presentationsDB = new PresentationsEntities();

        //
        // GET: /Gallery/

        public ViewResult Index(/*string sortOrder, string currentFilter,*/ string search, int? page)
        {
            // TODO: future search support
            //if (Request.HttpMethod == "GET")
            //    search = currentFilter;
            //else
            page = 1;
            ViewBag.CurrentFilter = search;
            var presentations = presentationsDB.Presentations
                .Include("Tags").OrderBy(g => g.Title);
            if (!String.IsNullOrEmpty(search))
            {
                presentations = presentationsDB.Presentations
                    .Where(p => p.Title.Contains(search)).OrderBy(p => p.Title);
            }

            // TODO: number of pages in the _PageNavigatorPartial must be trunctated
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(presentations.ToPagedList(pageNumber, pageSize));           
        }

        public ViewResult Preview (int id)
        {
            bool exists = presentationsDB.Presentations.Any(g => g.PresentationId == id);
            if (exists)
            {
                var presentation = presentationsDB.Presentations.Include("Tags").First(g => g.PresentationId == id);
                ViewBag.PresentationTitle = presentation.Title;
                ViewBag.Description = presentation.Description;
                ViewBag.Tags = presentation.Tags;
                return View();
            }
            else
            {
                return View("Error");
            }

        }        
    }
}

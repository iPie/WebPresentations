using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using PagedList;
using WebPresentations.Models;
using WebPresentations.Caching;

namespace WebPresentations.Controllers
{
    public class GalleryController : EntityController
    {

        //
        // GET: /Gallery/
        
        public ViewResult Index(/*string sortOrder, string currentFilter,*/ string search, int? page)
        {
            // TODO: future search support
            //if (Request.HttpMethod == "GET")
            //    search = currentFilter;
            //else
            var presentations = PresentationsWithTags().OrderBy(g => g.Title);

            var cm = new WebPresentationsCacheManager();
            var result = new List<Presentation>();
            if (!String.IsNullOrEmpty(search))
            {
                if (cm.Contains(search))
                {
                    result = (List<Presentation>)cm.GetData(search);
                }
                else
                {
                    presentations = FindInPresentationData(search);
                    presentations = FindInTags(search, presentations);
                    result = presentations.ToList();
                    cm.Add(search, result);
                }
            }
            else
            {
                result = presentations.ToList();
            }
            page = 1;
            ViewBag.CurrentFilter = search;
            
            // TODO: number of pages in the _PageNavigatorPartial must be trunctated
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(result.ToPagedList(pageNumber, pageSize));           
        }


        //
        // GET: /Gallery/Preview?id=1

        public ViewResult Preview (int id)
        {
            if (PresentationExists(id))
            {
                var presentation = GetPresentation(id);
                //ViewBag.PresentationTitle = presentation.Title;
                //ViewBag.Description = presentation.Description;
                //ViewBag.Tags = presentation.Tags;
                return View(presentation);
            }
            return View("Error");
        }

        public IOrderedQueryable<Presentation> FindInPresentationData(string search)
        {
            return Entities.Presentations
                     .Where(p => p.Title.Contains(search) || p.Description.Contains(search) || p.Json.Contains(search)).OrderBy(p => p.Title);
        }

        public IOrderedQueryable<Presentation> FindInTags(string search, IOrderedQueryable<Presentation> presentations)
        {
            var ids = Entities.Tags.Where(tag => tag.Text == search).OrderBy(tag => (tag.Text)).Select(
                        tag => tag.Presentations);

            foreach (var collection in ids)
            {
                foreach (var currentPresentation in collection)
                {
                    if (!presentations.Any(p => p.PresentationId == currentPresentation.PresentationId))
                    {
                        var tmp = from p in Entities.Presentations
                                  where p.PresentationId == currentPresentation.PresentationId
                                  orderby p.Title
                                  select p;

                        presentations = presentations.Concat(tmp).OrderBy(t => t.Title);
                    }
                }
            }
            return presentations;
        }
    }
}

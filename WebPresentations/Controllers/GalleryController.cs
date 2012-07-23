using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using PagedList;
using WebPresentations.DatabaseEntities;
using WebPresentations.Models;
using WebPresentations.Caching;
using WebPresentations.ViewModels;

namespace WebPresentations.Controllers
{
    [HandleErrorWithELMAH]
    public class GalleryController : EntityController
    {

        //
        // GET: /Gallery/
        
        public ViewResult Index(string search, int? page)
        {
            var presentations = Entities.PresentationsWithTags().OrderBy(g => g.Title);
            var cm = new WebPresentationsCacheManager();
            List<Presentation> result;
            try
            {
                if (!String.IsNullOrEmpty(search))
                {
                    if (cm.Contains(search))
                    {
                        result = (List<Presentation>) cm.GetData(search);
                    }
                    else
                    {
                        result = EntitiesIndexer.QueryPresentations(search);
                        cm.Add(search, result);
                    }
                }
                else
                {
                    result = presentations.ToList();
                }
            }
            catch
            {
                result = new List<Presentation>();
            }
            var gallery = GenerateGallery(result);
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(gallery.ToPagedList(pageNumber, pageSize));           
        }

        private IEnumerable<GalleryViewModel> GenerateGallery(IEnumerable<Presentation> result)
        {
            var gallery = new List<GalleryViewModel>();
            foreach (var presentation in result)
            {
                var model = new GalleryViewModel
                                {
                                    Presentation = presentation,
                                    Tags = presentation.Tags.Take(5).ToList(),
                                    IsUserDependant = true
                                };
                if (Request.IsAuthenticated)
                {
                    if
                        (Entities.UserOwnsPresentation(presentation.PresentationId, User.Identity.Name) ||
                         Entities.IsLikedByUser(presentation, User.Identity.Name))
                    {
                        model.IsUserDependant = true;
                    }
                    else
                    {
                        model.IsUserDependant = false;
                    }
                }
                gallery.Add(model);
            }
            return gallery;
        }

        //
        // GET: /Gallery/Preview/1

        public ViewResult Preview (int id)
        {
            if (Entities.PresentationExists(id))
            {
                var presentation = Entities.GetPresentation(id);
                return View(presentation);
            }
            return View("Error");
        }
    }
}

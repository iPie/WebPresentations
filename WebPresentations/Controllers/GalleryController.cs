﻿using System;
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

namespace WebPresentations.Controllers
{
    public class GalleryController : EntityController
    {

        //
        // GET: /Gallery/
        
        public ViewResult Index(/*string sortOrder, string currentFilter,*/ string search, int? page)
        {
            var presentations = Entities.PresentationsWithTags().OrderBy(g => g.Title);
            var cm = new WebPresentationsCacheManager();
            List<Presentation> result;
            if (!String.IsNullOrEmpty(search))
            {
                if (cm.Contains(search))
                {
                    result = (List<Presentation>)cm.GetData(search);
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
            ViewBag.CurrentFilter = search;
            
            // TODO: number of pages in the _PageNavigatorPartial must be trunctated
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(result.ToPagedList(pageNumber, pageSize));           
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

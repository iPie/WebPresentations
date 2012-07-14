using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPresentations.Controllers
{
    [Authorize]
    public class ProfileController : EntityController
    {
        //
        // GET: /Profile/

        public ActionResult Index()
        {
            var presentations = Entities.Presentations
                .Where(p => p.UserName == User.Identity.Name).ToList();
            return View(presentations);
        }

    }
}

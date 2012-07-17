using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebPresentations.MembershipLayer;

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

        public ActionResult PasswordReset()
        {
            var userName = User.Identity.Name;
            var result = AccountService.PasswordReset(userName);
            return Json(new { message = result });
        }

    }
}

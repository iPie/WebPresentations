using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebPresentations.MembershipLayer;
using WebPresentations.Models;

namespace WebPresentations.Controllers
{
    [Authorize]
    public class ProfileController : EntityController
    {
        //
        // GET: /Profile/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Profile/Settings

        public ActionResult Settings()
        {
            var presentations = GetCurrentUserPresentations();
            return View(presentations);
        }

        //
        // GET: /Profile/Presentations

        public ActionResult Presentations()
        {
            var presentations = GetCurrentUserPresentations();
            return View(presentations);
        }

        //
        // POST: /Profile/PasswordReset

        [HttpPost]
        public JsonResult PasswordReset()
        {
            var userName = User.Identity.Name;
            var result = AccountService.PasswordReset(userName);
            return Json(new { message = result });
        }


    }
}

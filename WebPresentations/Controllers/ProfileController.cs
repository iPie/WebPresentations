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
            var user = Membership.GetUser(User.Identity.Name);
            ViewBag.Email = user.Email;
            ViewBag.MemberSince = user.CreationDate;
            ViewBag.PresentationsCount = Entities.GetUserPresentations(User.Identity.Name).Count();
            return View();
        }

        //
        // GET: /Profile/Settings

        public ActionResult Settings()
        {
            var presentations = Entities.GetUserPresentations(User.Identity.Name);
            return View(presentations);
        }

        //
        // GET: /Profile/Presentations

        public ActionResult Presentations()
        {
            var presentations = Entities.GetUserPresentations(User.Identity.Name);
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

        //
        // POST: /Profile/PasswordReset

        [HttpPost]
        public JsonResult AddLike(int id)
        {
            var presentation = Entities.GetPresentation(id);
            var userName = User.Identity.Name;
            try
            {
                var result = Entities.AddLike(presentation, userName);
                switch (result)
                {
                    case 0:
                        return Json("Success");
                    case 1:
                        return Json("IsOwned");
                    case 2:
                        return Json("IsLiked");
                }
            }
            catch { }
            return Json("Fail");
        }

    }
}

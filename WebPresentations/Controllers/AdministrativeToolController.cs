using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebPresentations.MembershipLayer;
using WebPresentations.ViewModels;

namespace WebPresentations.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministrativeToolController : Controller
    {

        //
        // GET: /AdministrativeTool/

        public ActionResult Index()
        {
            var users = Membership.GetAllUsers();
            return View(users);
        }

        //
        // GET: /AdministrativeTool/Edit

        public ActionResult Edit(string userName)
        {
            try
            {
                var user = Membership.GetUser(userName);
                var model = new AdministrativeToolViewModel
                                {
                                    UserName = userName,
                                    EmailAddress = user.Email,
                                    IsApproved = user.IsApproved,
                                    Role = Roles.GetRolesForUser(userName).First(),
                                    LastActivityDate = user.LastActivityDate,
                                    IsOnline = user.IsOnline,
                                    RolesList = Roles.GetAllRoles().ToList(),
                                };
                return View(model);
            }
            catch
            {
                return View("Error");
            }
        }

        //
        // POST: /AdministrativeTool/Edit

        [HttpPost]
        public ActionResult Edit(AdministrativeToolViewModel model)
        {
            try
            {
                if (!Roles.IsUserInRole(model.UserName, model.Role))
                {
                    var roles = Roles.GetRolesForUser(model.UserName);
                    Roles.RemoveUserFromRoles(model.UserName, roles);
                    Roles.AddUserToRole(model.UserName, model.Role);
                }
                var user = Membership.GetUser(model.UserName);
                if (!model.IsApproved && user.IsApproved)
                {
                    user.IsApproved = false;
                    Membership.UpdateUser(user);
                }
                else if (model.IsApproved && !user.IsApproved)
                {
                    user.IsApproved = true;
                    Membership.UpdateUser(user);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        //
        // POST: /AdministrativeTool/PasswordReset

        [HttpPost]
        public ActionResult PasswordReset(string userName)
        {
            var result = AccountService.PasswordReset(userName);
            return Json(new { message = result });
        }
    }
}

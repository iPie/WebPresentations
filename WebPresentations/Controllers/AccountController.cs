using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Handlers;
using System.Web.Routing;
using System.Web.Security;
using WebPresentations.Models;

namespace WebPresentations.Controllers
{
    public class AccountController : Controller
    {

        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus;
                Membership.CreateUser(model.UserName, model.Password, model.Email, null, null, false, null, out createStatus);
                if (createStatus == MembershipCreateStatus.Success)
                {
                    // TODO: SendConfrimationEmail() might fail, try-catch here!
                    SendConfrimationEmail(model.UserName);
                    return RedirectToAction("Confirmation", "Account");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Confirmation

        public ActionResult Confirmation()
        {
            return View();
        }

        //
        // GET: /Account/Confirm?ID=

        public ActionResult Confirm(string id)
        {
            if (string.IsNullOrEmpty(id) || (!Regex.IsMatch(id,
                        @"[0-9a-f]{8}\-([0-9a-f]{4}\-){3}[0-9a-f]{12}")))
            {
                return View("Error");
            }
            else
            {
                MembershipUser user = Membership.GetUser(new Guid(id));

                if (!user.IsApproved)
                {
                    user.IsApproved = true;
                    Membership.UpdateUser(user);
                    FormsAuthentication.SetAuthCookie(user.UserName, false /* createPersistentCookie */);
                    //FormsService.SignIn(user.UserName, false);
                    return RedirectToAction("RegistrationSuccess");
                }
                else
                {
                    FormsAuthentication.SignOut();
                    //FormsService.SignOut();
                    TempData["errorMessage"] = "You have already confirmed your email address.";
                    return RedirectToAction("LogOn");
                }
            }
        }

        //
        // GET: /Account/RegistrationSuccess

        public ActionResult RegistrationSuccess()
        {
            return View();
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        //Send confrimation Email
        private void SendConfrimationEmail(string userName)
        {
            MembershipUser user = Membership.GetUser(userName);
            string confirmationGuid = user.ProviderUserKey.ToString();
            string confirmUrl = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) +
                             "/account/confirm?id=" + confirmationGuid;
            // TODO: change confirmation email body
            var message = new MailMessage("iliketits.spambot@yahoo.com", user.Email)
            {
                Subject = "Registration confirmation from iLikeTits.com",
                Body = "Please follow the link below in order to activate your account:\n" + confirmUrl
            };
            var client = new SmtpClient();
            client.Send(message);
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion

    }
}

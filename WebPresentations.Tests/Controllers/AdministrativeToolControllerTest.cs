using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security.Moles;
using Microsoft.Moles.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebPresentations.Controllers;
using WebPresentations.MembershipLayer.Moles;

namespace WebPresentations.Tests.Controllers
{
    [TestClass]
    public class AdministrativeToolControllerTest
    {
        private string testUserName = "TestUser";
        private string testEmail = "test@test.test";

        [TestMethod, HostType("Moles")]
        public void EditReturnsModelIfUserExists()
        {
            var controller = new AdministrativeToolController();
            var roles = new List<string> { "Admin" }.ToArray();
            using (MolesContext.Create())
            {
                var user = new MMembershipUser
                {
                    UserNameGet = () => testUserName,
                    EmailGet = () => testEmail,
                    IsApprovedGet = () => true,
                    LastActivityDateGet = () => DateTime.Now,
                    IsOnlineGet = () => true,
                };
                MRoles.GetAllRoles = () => roles;
                MRoles.GetRolesForUserString = (userName) => roles;
                MMembership.GetUserString = (userName) =>
                {
                    Assert.AreEqual(testUserName, userName);
                    return user;
                };
                var result = (ViewResult)controller.Edit(testUserName);
                Assert.AreNotEqual("Error", result.ViewName);
            }
        }

        [TestMethod, HostType("Moles")]
        public void EditReturnsErrorIfUserDoesNotExist()
        {
            var controller = new AdministrativeToolController();
            using (MolesContext.Create())
            {
                MMembership.GetUserString = (userName) => null;
                var result = (ViewResult)controller.Edit(testUserName);
                Assert.AreEqual("Error", result.ViewName);
            }
        }

        [TestMethod, HostType("Moles")]
        public void PasswordResetReturnsSuccessIfUserExists()
        {
            var controller = new AdministrativeToolController();
            using (MolesContext.Create())
            {
                MAccountService.PasswordResetString = (userName) => "Success";
                var jsonResult = (JsonResult)controller.PasswordReset(testUserName);
                Assert.AreEqual("{ message = Success }", jsonResult.Data.ToString());
            }
        }

        [TestMethod, HostType("Moles")]
        public void PasswordResetReturnsErrorIfUserDoesNotExist()
        {
            var controller = new AdministrativeToolController();
            using (MolesContext.Create())
            {
                MAccountService.PasswordResetString = (userName) => "Error";
                var jsonResult = (JsonResult)controller.PasswordReset(testUserName);
                Assert.AreEqual("{ message = Error }", jsonResult.Data.ToString());
            }
        }
    }
}

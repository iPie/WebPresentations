using System;
using System.Web.Security.Moles;
using Microsoft.Moles.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebPresentations.MembershipLayer;
using WebPresentations.MembershipLayer.Moles;

namespace WebPresentations.Tests.MembershipLayer
{
    [TestClass]
    public class AccountServiceTest
    {
        private string testUserName = "TestUser";
        private string testPassword = "12345678";
        private string testEmail = "test@test.test";

        [TestMethod, HostType("Moles")]
        public void PasswordResetReturnsSuccessIfUserExists()
        {
            using (MolesContext.Create())
            {
                var user = new MMembershipUser
                               {
                                   UserNameGet = () => testUserName,
                                   ResetPassword = () => testPassword,
                                   EmailGet = () => testEmail
                               };
                MMembership.GetUserString = (userName) => user;
                MMailService.SendConfirmationEmailMailServiceMessageModel = (message) => new Object();
                var result = AccountService.PasswordReset(testUserName);
                Assert.AreEqual("Success", result);
            }
        }

        [TestMethod, HostType("Moles")]
        public void PasswordResetReturnsErrorIfUserDoesNotExist()
        {
            using (MolesContext.Create())
            {
                MMembership.GetUserString = (userName) => null;
                var result = AccountService.PasswordReset(testUserName);
                Assert.AreEqual("Error", result);
            }
        }
    }
}

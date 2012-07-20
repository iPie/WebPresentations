using System;
using System.Security.Principal;
using System.Security.Principal.Behaviors;
using System.Security.Principal.Moles;
using System.Web;
using System.Web.Behaviors;
using System.Web.Mvc;
using System.Web.Security.Moles;
using Microsoft.Moles.Framework;
using WebPresentations.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebPresentations.Controllers.Moles;
using WebPresentations.DatabaseEntities.Moles;
using WebPresentations.Models;
[assembly: MoledType(typeof(System.Security.Principal.GenericPrincipal))]  

namespace WebPresentations.Tests.Controllers
{
    [TestClass]
    
    public class EditorControllerTest
    {
        private EditorController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _controller = new EditorController();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _controller.Dispose();
        }


        //[TestMethod, HostType("Moles")]              
        //public void DeleteReturnsSuccessIfUserOwnsPresentations()
        //{
        //    HttpContext.Current.User = new GenericPrincipal(
        //        new GenericIdentity("username"),
        //        new string[0]
        //        );
        //    var user = new SIPrincipal();
        //    user.IdentityGet = () => null;
        //    MEntityController.AllInstances.EntitiesGet = (a) => null;
        //    MDatabaseContext.AllInstances.UserOwnsPresentationInt32String = (a, b, c) => true;
            
        //    MDatabaseContext.AllInstances.RemovePresentationInt32 = (a, b) => new Object();
            
        //    _controller.Delete(1);
        //}
    }
}

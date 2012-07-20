using System;
using System.Web.Mvc;
using WebPresentations.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebPresentations.Controllers.Moles;
using WebPresentations.DatabaseEntities.Moles;
using WebPresentations.Models;

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


        [TestMethod, HostType("Moles")]
        public void DeleteReturnsSuccessIfUserOwnsPresentations()
        {
            MDatabaseContext.AllInstances.UserOwnsPresentationInt32String = (a, b, c) => true;
            MDatabaseContext.AllInstances.RemovePresentationInt32 = (a, b) => new Object();
            _controller.Delete(1);
        }
    }
}

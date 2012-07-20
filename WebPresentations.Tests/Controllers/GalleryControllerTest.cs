using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using System.Xml;
using WebPresentations.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using WebPresentations.DatabaseEntities.Moles;
using WebPresentations.Models;
using WebPresentations.Models.Moles;
using WebPresentations.ViewModels;

namespace WebPresentations.Tests.Controllers
{
    [TestClass]
    public class GalleryControllerTest
    {
        [TestMethod, HostType("Moles")]
        public void PreviewReturnsPresentationIfPresentationExists()
        {
            var presentation = new SPresentation(){PresentationId = 1};
            MDatabaseContext.AllInstances.PresentationExistsInt32 = (i, g) => true;
            MDatabaseContext.AllInstances.GetPresentationInt32 = (i, g) => presentation;
            var controller = new GalleryController();
            var result = controller.Preview(1);
            Assert.AreNotEqual("Error", result.ViewName);
        }

        [TestMethod, HostType("Moles")]
        public void PreviewReturnsErrorIfPresentationDoesNotExist()
        {
            MDatabaseContext.AllInstances.PresentationExistsInt32 = (i, g) => false;
            MDatabaseContext.AllInstances.GetPresentationInt32 = (i, g) => null;
            var controller = new GalleryController();
            var result = controller.Preview(1);
            Assert.AreEqual("Error", result.ViewName);
        }
    }
}

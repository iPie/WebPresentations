using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Security.Principal.Behaviors;
using System.Security.Principal.Moles;
using System.Web;
using System.Web.Behaviors;
using System.Web.Moles;
using System.Web.Mvc;
using System.Web.Security.Moles;
using Microsoft.Moles.Framework;
using WebPresentations.Caching.Moles;
using WebPresentations.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebPresentations.Controllers.Moles;
using WebPresentations.DatabaseEntities;
using WebPresentations.DatabaseEntities.Moles;
using WebPresentations.Models;
using WebPresentations.Models.Moles;
using WebPresentations.ViewModels.Moles;

[assembly: MoledType(typeof(System.Security.Principal.GenericPrincipal))]

namespace WebPresentations.Tests.Controllers
{
    [TestClass]

    public class EditorControllerTest
    {
        private EditorController controller;

        [TestInitialize]
        public void Initialize()
        {
            controller = new EditorController();
        }

        [TestCleanup]
        public void CleanUp()
        {
            controller.Dispose();
        }

        [TestMethod, HostType("Moles")]
        public void DeleteReturnsSuccessIfUserOwnsPresentations()
        {
            var stubHttpContext = new SHttpContextBase();
            var principal = new SIPrincipal();
            principal.IdentityGet = () =>
                                        {
                                            var identity = new SIIdentity {NameGet = () => "testUserName"};
                                            return identity;
                                        };
            stubHttpContext.UserGet = () => principal;
            MDatabaseContext.AllInstances.GetPresentationInt32 = (a, b) => new Presentation {UserName = "testUserName"};
            MEntityController.AllInstances.EntitiesGet = (a) => new SDatabaseContext();
            MDatabaseContext.AllInstances.EntitiesGet = (a) => new SPresentationsEntities();
            MDatabaseContext.AllInstances.UserOwnsPresentationInt32String = (a, b, c) => true;

            MDatabaseContext.AllInstances.RemovePresentationInt32 = (a, b) => new Object();

            var result = controller.Delete(1);
            Assert.AreEqual(result, "Success");
        }


        [TestMethod, HostType("Moles")]
        public void CreateReturnsSuccessIfModelIsValid()
        {
            var t = "testData";
            var model = new SEditorViewModel {HtmlContents = t, Title = t, Json = t, Description = t, TagString = t};
            var p = new SPresentation {Title = t};
            
            MDatabaseContext.AllInstances.ParseTagsString = (a,b) => new List<Tag>();
            MDatabaseContext.AllInstances.AddToPresentationsPresentation = (a, b) => new Object();
            MEntitiesIndexer.AddPresentationToIndexPresentation = (a) => new Object();
            MWebPresentationsCacheManager.AllInstances.Flush = (a) => new Object(); ;
            controller.Create(model);
        }
    }
}
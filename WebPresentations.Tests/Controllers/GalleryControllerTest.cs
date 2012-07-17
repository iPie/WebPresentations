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
using WebPresentations.Models;
using WebPresentations.ViewModels;

namespace WebPresentations.Tests.Controllers
{
    [TestClass]
    public class GalleryControllerTest
    {
        public void InitializeConnection(string connectionPath)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            foreach (XmlNode node in from XmlElement element in xmlDoc.DocumentElement
                                     where element.Name.Equals("connectionStrings")
                                     from node in element.ChildNodes.Cast<XmlNode>()
                                     .Where(node => node.Attributes[0].Value.Equals("PresentationsEntities"))
                                     select node)
            {
                node.Attributes[1].Value = connectionPath;
            }
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            ConfigurationManager.RefreshSection("appSettings");
        }

        [TestInitialize]
        public void Init()
        {
            //Database.SetInitializer<PresentationsEntities>(null);            
            var str = AppDomain.CurrentDomain.BaseDirectory;
            var path = "data source=" + str + "\\WebPresentations.sdf";
            InitializeConnection(path);
        }

        [TestMethod]
        [DeploymentItem("WebPresentations.sdf")]
        public void PreviewTest()
        {
            var controller = new GalleryController();
            using (var ts = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var t = "Test";
                var testPresentation = new Presentation
                                           {
                                               UserName = t,
                                               Title = t,
                                               Json = t,
                                               Description = t,
                                               Tags = new List<Tag> { new Tag(t) },
                                           };
                var db = new PresentationsEntities();
                db.Presentations.Add(testPresentation);
                db.SaveChanges();
                var result = (ViewResult)controller.Preview(testPresentation.PresentationId);
                Assert.AreNotEqual("Error", result.ViewName);
                ts.Complete();
            }

        }
    }
}

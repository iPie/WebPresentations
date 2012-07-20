using System;
using System.Configuration;
using System.Transactions;
using System.Xml;
using WebPresentations.DatabaseEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebPresentations.Models;
using System.Linq;
using System.Collections.Generic;

namespace WebPresentations.Tests.DatabaseEntities
{
    [TestClass]
    public class DatabaseContextTest
    {
        private TransactionScope _transactionScope;

        private void InitializeConnection(string connectionPath)
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

        private Presentation TestPresentation(string t = "Test")
        {
            var testPresentation = new Presentation
            {
                UserName = t,
                Title = t,
                Json = t,
                Description = t,
                Tags = new List<Tag> { new Tag(t) },
            };
            return testPresentation;
        }

        private Tag TestTag(string t = "Test")
        {
            var tag = new Tag
                          {
                              Count = 1,
                              TagId = 1,
                              Text = t,
                              Presentations = new List<Presentation> { TestPresentation() },
                          };
            return tag;
        }

        [TestInitialize]
        public void Initialize()
        {
            var str = AppDomain.CurrentDomain.BaseDirectory;
            var path = "data source=" + str + "\\WebPresentations.sdf";
            InitializeConnection(path);
            _transactionScope = new TransactionScope(TransactionScopeOption.Suppress);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (_transactionScope != null)
            {
                _transactionScope.Dispose();
                _transactionScope = null;
            }
        }


        [TestMethod]
        [DeploymentItem("WebPresentations.sdf")]
        public void AddToPresentationsTest()
        {
            var presentation = TestPresentation();
            var db = new PresentationsEntities();
            var target = new DatabaseContext();
            target.AddToPresentations(presentation);
            var result = db.Presentations.Any(p => p.Title.Equals(presentation.Title));
            Assert.IsTrue(result);
        }


        [TestMethod]
        [DeploymentItem("WebPresentations.sdf")]
        public void GetPresentationReturnsPresentationIfIdExists()
        {
            var target = new DatabaseContext();
            var presentation = TestPresentation();
            var db = new PresentationsEntities();
            db.Presentations.Add(presentation);
            db.SaveChanges();
            var outputPresentation = target.GetPresentation(presentation.PresentationId);
            Assert.AreEqual(outputPresentation.PresentationId, presentation.PresentationId);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Sequence contains no elements.")]
        [DeploymentItem("WebPresentations.sdf")]
        public void GetPresentationThrowsExceptionIfIdDoesNotExist()
        {
            var target = new DatabaseContext();
            target.GetPresentation(99);
        }

        [TestMethod]
        [DeploymentItem("WebPresentations.sdf")]
        public void GetTagReturnsTagIfTagExists()
        {
            var target = new DatabaseContext();
            var tag = TestTag();
            var db = new PresentationsEntities();
            db.Tags.Add(tag);
            db.SaveChanges();
            var result = target.GetTag(tag.Text);

            Assert.IsTrue(tag.Text.Equals(result.Text));

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Sequence contains no elements.")]
        [DeploymentItem("WebPresentations.sdf")]
        public void GetTagThrowsExceptionIfTagDoesNotExist()
        {
            var target = new DatabaseContext();
            var result = target.GetTag("SomeNewTag");
            Assert.IsNull(result);

        }

        [TestMethod]
        [DeploymentItem("WebPresentations.sdf")]
        public void GetUserPresentationsReturnsQueryIfUsernameExists()
        {
            var target = new DatabaseContext();
            var testUserName = "TestUser";
            var presentation1 = TestPresentation();
            var presentation2 = TestPresentation();
            var presentation3 = TestPresentation();
            presentation1.UserName = testUserName;
            presentation2.UserName = testUserName;
            presentation3.UserName = "DifferentUsername";
            var db = new PresentationsEntities();
            db.Presentations.Add(presentation1);
            db.Presentations.Add(presentation2);
            db.Presentations.Add(presentation3);
            db.SaveChanges();
            var outputPresentations = target.GetUserPresentations(testUserName).ToList();

            foreach (var p in outputPresentations)
            {
                Assert.AreEqual(p.UserName, testUserName);
            }

        }

        [TestMethod]
        [DeploymentItem("WebPresentations.sdf")]
        public void GetUserPresentationsReturnsEmptyQueryIfUsernameDoesNotExist()
        {
            var target = new DatabaseContext();
            var testUserName = "TestUser";
            var presentation1 = TestPresentation();
            var presentation2 = TestPresentation();
            presentation1.UserName = testUserName;
            presentation2.UserName = testUserName;
            var db = new PresentationsEntities();
            db.Presentations.Add(presentation1);
            db.Presentations.Add(presentation2);
            db.SaveChanges();
            var outputPresentations = target.GetUserPresentations("DifferentUser");
            Assert.AreEqual(outputPresentations.Count(), 0);

        }

        [TestMethod]
        [DeploymentItem("WebPresentations.sdf")]
        public void PresentationExistsReturnsTrueIfPresentationExists()
        {
            var target = new DatabaseContext();
            var presentation = TestPresentation();
            var db = new PresentationsEntities();
            db.Presentations.Add(presentation);
            db.SaveChanges();
            var result = target.PresentationExists(presentation.PresentationId);
            Assert.IsTrue(result);

        }

        [TestMethod]
        [DeploymentItem("WebPresentations.sdf")]
        public void PresentationExistsReturnsFalseIfPresentationDoesNotExist()
        {
            var target = new DatabaseContext();
            var success = target.PresentationExists(99);
            Assert.IsFalse(success);

        }

        public void PresentationsWithTagsTest()
        {
            DatabaseContext target = new DatabaseContext(); // TODO: Initialize to an appropriate value
            IQueryable<Presentation> expected = null; // TODO: Initialize to an appropriate value
            IQueryable<Presentation> actual;
            actual = target.PresentationsWithTags();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem("WebPresentations.sdf")]
        public void RemovePresentationTest()
        {
            var target = new DatabaseContext();
            var presentation = TestPresentation();
            var db = new PresentationsEntities();
            db.Presentations.Add(presentation);
            db.SaveChanges();
            Assert.IsTrue(db.Presentations.Any(p => p.PresentationId == presentation.PresentationId));
            target.RemovePresentation(presentation.PresentationId);
            var result = db.Presentations.Any(p => p.PresentationId == presentation.PresentationId);
            Assert.IsFalse(result);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Sequence contains no elements.")]
        [DeploymentItem("WebPresentations.sdf")]
        public void RemovePresentationThrowsExceptionIfPresentationDoesNotExist()
        {
            var target = new DatabaseContext();
            target.RemovePresentation(99);

        }

        [TestMethod]
        [DeploymentItem("WebPresentations.sdf")]
        public void TagExistsReturnsTrueIfTagExists()
        {
            var target = new DatabaseContext();
            var tag = TestTag();
            var db = new PresentationsEntities();
            db.Tags.Add(tag);
            db.SaveChanges();
            var result = target.TagExists(tag.Text);
            Assert.IsTrue(result);

        }

        [TestMethod]
        [DeploymentItem("WebPresentations.sdf")]
        public void TagExistsReturnsFalseIfTagDoesNotExist()
        {
            var target = new DatabaseContext();
            var result = target.TagExists("blabla");
            Assert.IsFalse(result);

        }

        [TestMethod]
        [DeploymentItem("WebPresentations.sdf")]
        public void UserOwnsPresentationReturnsTrueIfUserOwnsPresentation()
        {
            var target = new DatabaseContext();
            var testUserName = "TestUser";
            var presentation = TestPresentation();
            presentation.UserName = testUserName;
            var db = new PresentationsEntities();
            db.Presentations.Add(presentation);
            db.SaveChanges();
            var result = target.UserOwnsPresentation(presentation.PresentationId, testUserName);
            Assert.IsTrue(result);

        }

        [TestMethod]
        [DeploymentItem("WebPresentations.sdf")]
        public void UserOwnsPresentationReturnsFalseIfUserDoesNotOwnPresentation()
        {
            var target = new DatabaseContext();
            var testUserName = "TestUser";
            var presentation = TestPresentation();
            presentation.UserName = testUserName;
            var db = new PresentationsEntities();
            db.Presentations.Add(presentation);
            db.SaveChanges();
            var result = target.UserOwnsPresentation(presentation.PresentationId, "blabla");
            Assert.IsFalse(result);

        }

        [TestMethod]
        [DeploymentItem("WebPresentations.sdf")]
        public void UserOwnsPresentationReturnsFalseIfPresentationDoesNotExist()
        {
            var target = new DatabaseContext();
            var testUserName = "TestUser";
            var presentation = TestPresentation();
            presentation.UserName = testUserName;
            var db = new PresentationsEntities();
            db.Presentations.Add(presentation);
            db.SaveChanges();
            var result = target.UserOwnsPresentation(13, "blabla");
            Assert.IsFalse(result);

        }
    }
}

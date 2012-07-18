//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Security;
//using WebPresentations.Models;

//namespace WebPresentations.DatabaseEntities
//{
//    public class DatabaseContext : DbContext
//    {
//        private PresentationsEntities _entities;

//        public DatabaseContext() { }

//        public DatabaseContext(PresentationsEntities entities)
//        {
//            _entities = entities;
//        }

//        private PresentationsEntities Entities
//        {
//            get { return _entities ?? (_entities = new PresentationsEntities()); }
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && _entities != null)
//            {
//                _entities.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        public bool PresentationExists(int id)
//        {
//            return Entities.Presentations.Any(g => g.PresentationId == id);
//        }

//        public Presentation GetPresentation(int id)
//        {
//            return Entities.Presentations.Include("Tags").Single(g => g.PresentationId == id);
//        }

//        public IQueryable<Presentation> GetUserPresentations(MembershipUser userName)
//        {
//            return Entities.Presentations.Include("Tags")
//                .Where(p => p.UserName.Equals(userName.ToString()));
//        }

//        public void AddToPresentations(Presentation presentation)
//        {
//            Entities.Presentations.Add(presentation);
//            Entities.SaveChanges();
//        }

//        public void RemovePresentation(int id)
//        {
//            var presentation = Entities.Presentations.Single(p => p.PresentationId == id);
//            Entities.Presentations.Remove(presentation);
//            Entities.SaveChanges();
//        }

//        public IQueryable<Presentation> PresentationsWithTags()
//        {
//            return Entities.Presentations.Include("Tags");
//        }

//        public bool UserOwnsPresentation(int id, MembershipUser userName)
//        {
//            return Entities.Presentations
//                .Any(p => p.PresentationId == id && p.UserName.Equals(userName.ToString()));
//        }

//        public Tag GetTag(string tagText)
//        {
//            return Entities.Tags.Single(g => g.Text == tagText);
//        }

//        public bool TagExists(string tagText)
//        {
//            return Entities.Tags.Any(g => g.Text == tagText);
//        }
//    }
//}
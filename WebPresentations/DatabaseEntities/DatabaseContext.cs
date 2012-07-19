
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using WebPresentations.Models;

namespace WebPresentations.DatabaseEntities
{
    public class DatabaseContext : DbContext
    {
        private PresentationsEntities _entities;

        public DatabaseContext() { }

        public DatabaseContext(PresentationsEntities entities)
        {
            _entities = entities;
        }

        public PresentationsEntities Entities
        {
            get { return _entities ?? (_entities = new PresentationsEntities());}
            set { _entities = value; }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _entities != null)
            {
                _entities.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool PresentationExists(int id)
        {
            return Entities.Presentations.Any(g => g.PresentationId == id);
        }

        public Presentation GetPresentation(int id)
        {
            return Entities.Presentations.Include("Tags").Single(g => g.PresentationId == id);
        }

        public IQueryable<Presentation> GetUserPresentations(string userName)
        {
            return Entities.Presentations.Include("Tags")
                .Where(p => p.UserName.Equals(userName));
        }

        public void AddToPresentations(Presentation presentation)
        {
             Entities.Presentations.Add(presentation);
             Entities.SaveChanges();
            
        }

        public void RemovePresentation(int id)
        {
            var presentation = Entities.Presentations.Single(p => p.PresentationId == id);
            Entities.Presentations.Remove(presentation);
            Entities.SaveChanges();
        }

        public IQueryable<Presentation> PresentationsWithTags()
        {
            return Entities.Presentations.Include("Tags");
        }

        public bool UserOwnsPresentation(int id, string userName)
        {
            return Entities.Presentations
                .Any(p => p.PresentationId == id && p.UserName.Equals(userName));
        }

        public IOrderedQueryable<Presentation> FindInPresentationData(string search)
        {
            return Entities.Presentations
                     .Where(p => p.Title.Contains(search) || p.Description.Contains(search) || p.Json.Contains(search)).OrderBy(p => p.Title);
        }

        public Tag GetTag(string tagText)
        {
            return Entities.Tags.First(g => g.Text.Equals(tagText));
        }

        public bool TagExists(string tagText)
        {
            return Entities.Tags.Any(g => g.Text == tagText);
        }

        public ICollection<Presentation> GetPresentationsForTag(string search)
        {
            var tag = Entities.Tags.Include("Presentations").First(t => t.Text.Equals(search));
            return tag.Presentations;
            //return Entities.Tags.Where(tag => tag.Text == search).OrderBy(tag => (tag.Text))
            //    .Select(tag => tag.Presentations);
        }

        public IOrderedQueryable<Presentation> FindInTags(string search, IOrderedQueryable<Presentation> presentations)
        {
            var ids = GetPresentationsForTag(search).ToList();
            foreach (var currentPresentation in ids)
            {
                if (!presentations.Any(p => p.PresentationId == currentPresentation.PresentationId))
                {
                    var tmp = from p in Entities.Presentations
                              where p.PresentationId == currentPresentation.PresentationId
                              orderby p.Title
                              select p;

                    presentations = presentations.Concat(tmp).OrderBy(t => t.Title);
                }
            }
            return presentations;
        }
    }
}
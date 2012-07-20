
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
            get { return _entities ?? (_entities = new PresentationsEntities()); }
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
            foreach (var tag in presentation.Tags.ToList())
            {
                if (tag.Count > 1)
                {
                    tag.Count--;
                }
                else
                {
                    Entities.Tags.Remove(tag);
                }
            }
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

        public Tag GetTag(string tagText)
        {
            return Entities.Tags.First(g => g.Text.Equals(tagText));
        }

        public bool TagExists(string tagText)
        {
            return Entities.Tags.Any(g => g.Text == tagText);
        }

        public int AddLike (Presentation presentation, string userName)
        {
            if (!IsLikedByUser(presentation,userName))
            {
                if (!UserOwnsPresentation(presentation.PresentationId, userName))
                {
                    presentation.LikedUsers.Add(new LikedUser(userName));
                    Entities.SaveChanges();
                    return 0;
                }
                return 1;
            }
            return 2;
        }

        public bool IsLikedByUser (Presentation presentation, string userName)
        {
            return presentation.LikedUsers.Any(l => l.UserName.Equals(userName));
        }
    }
}
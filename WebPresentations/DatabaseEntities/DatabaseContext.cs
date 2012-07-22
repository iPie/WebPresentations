
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using WebPresentations.Models;

namespace WebPresentations.DatabaseEntities
{
    public class DatabaseContext : DbContext
    {
        private PresentationsEntities entities;

        public DatabaseContext() { }

        public DatabaseContext(PresentationsEntities entities)
        {
            this.entities = entities;
        }

        public PresentationsEntities Entities
        {
            get { return entities ?? (entities = new PresentationsEntities()); }
            set { entities = value; }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && entities != null)
            {
                entities.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool PresentationExists(int id)
        {
            return Entities.Presentations.Any(g => g.PresentationId == id);
        }

        public Presentation GetPresentation(int id)
        {
            return Entities.Presentations.Include("Tags").SingleOrDefault(g => g.PresentationId == id);
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

        public void UpdatePresentationTags(Presentation presentation, string tagString)
        {
            presentation.Tags = ParseTags(tagString);
            Entities.SaveChanges();
        }

        public void Update()
        {
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

        public List<Tag> ParseTags(string tagString)
        {
            var tags = new List<Tag>();
            foreach (var input in Regex.Split(tagString, @"[,\s+]+"))
            {
                var tagText = input.ToLower();
                var tagExists = TagExists(tagText);
                if (tagExists)
                {
                    var tag = GetTag(tagText);
                    tag.Count++;
                    tags.Add(tag);
                }
                else
                {
                    var exists = tags.Any(t => t.Text.Equals(tagText));
                    if (!exists)
                    {
                        tags.Add(new Tag { Text = tagText });
                    }
                }
            }
            return tags;
        }

        public bool IsLikedByUser (Presentation presentation, string userName)
        {
            return presentation.LikedUsers.Any(l => l.UserName.Equals(userName));
        }
    }
}
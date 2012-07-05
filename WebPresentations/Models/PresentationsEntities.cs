using System.Data.Entity;

namespace WebPresentations.Models
{
    public class PresentationsEntities : DbContext
    {
        public DbSet<Presentation> Presentations { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
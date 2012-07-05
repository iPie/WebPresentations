using System;
using System.Collections.Generic;

namespace WebPresentations.Models
{
    public class Presentation
    {
        public int PresentationId { get; set; }
        public String UserName { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Json { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public Presentation()
        {
            Tags = new HashSet<Tag>();
        }
    }
}
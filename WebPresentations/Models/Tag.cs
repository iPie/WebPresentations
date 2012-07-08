using System;
using System.Collections.Generic;

namespace WebPresentations.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public String Text { get; set; }
        public int Count { get; set; }
        public virtual ICollection<Presentation> Presentations { get; set; }

        public Tag()
        {
            Count = 1;
            Presentations = new HashSet<Presentation>();
        }
    }
}
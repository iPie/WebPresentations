using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebPresentations.Models
{
    public class Presentation
    {
        public int PresentationId { get; set; }
        public String UserName { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        [MaxLength]
        public String HtmlContents { get; set; }
        [MaxLength]
        public String Json { get; set; }
        [MaxLength]
        public String TextData { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public Presentation()
        {
            Tags = new HashSet<Tag>();
        }
    }
}
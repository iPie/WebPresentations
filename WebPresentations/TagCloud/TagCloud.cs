using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Script.Serialization;
using WebPresentations.Models;
using System.Web.Mvc;

namespace WebPresentations.TagCloud
{
    public class TagItem
    {
        public string Tag;
        public int Count;
    }

    public class TagCloud
    {

        public List<TagItem> Cloud { get; set; } 

        public TagCloud()
        {
            Cloud = new List<TagItem>();

            using (var db = new PresentationsEntities())
            {
                var tags = from tag in db.Tags
                           where tag.Count > 0
                           select new TagItem { Tag = tag.Text, Count = tag.Count };

                foreach (var tag in tags)
                {
                    Cloud.Add(tag);
                }
            }
        }

    }
}
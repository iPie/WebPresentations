using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPresentations.Models
{
    public class LikedUser
    {
        public int LikedUserId { get; set; }
        public String UserName { get; set; }
        public virtual ICollection<Presentation> Presentations { get; set; }

        public LikedUser()
        {
            Presentations = new HashSet<Presentation>();
        }

        public LikedUser(string userName)
        {
            UserName = userName;
            Presentations = new HashSet<Presentation>();
        }
    }
}
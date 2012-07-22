using System.Collections.Generic;
using WebPresentations.Models;

namespace WebPresentations.ViewModels
{
    
    public class GalleryViewModel
    {
        public Presentation Presentation { get; set; }
        public List<Tag> Tags { get; set; }
        public bool IsUserDependant { get; set; }
    }
}
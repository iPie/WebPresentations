using System;
using System.ComponentModel.DataAnnotations;

namespace WebPresentations.ViewModels
{
    public class EditorViewModel
    {
        [Required(ErrorMessage = "Title is required.")]
        //[RegularExpression(@"\w+")]
        [MaxLength(100)]
        public String Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        //[RegularExpression(@"\w+")]
        [MaxLength(100)]
        public String Description { get; set; }

        [Required(ErrorMessage = "Json string was not submitted.")]
        public String Json { get; set; }

        [Required(ErrorMessage = "Contents were not submitted.")]
        public String HtmlContents { get; set; }

        [Required(ErrorMessage = "At least one tag is required.")]
        //[RegularExpression(@"\w+")]
        [MaxLength(100)]
        public String TagString { get; set; }
    }
}
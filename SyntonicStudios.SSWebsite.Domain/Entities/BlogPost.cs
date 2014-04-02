using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SyntonicStudios.SSWebsite.Domain.Entities
{
    public class BlogPost : SyntonicStudios.SSWebsite.Domain.Entities.IBlogPost
    {
        public int BlogPostID { get; set; }

        public int? CategoryID { get; set; }

        [Required(ErrorMessage = "Please enter a subject")]
        public string Subject { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Body { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")] // This works for EditorFor but not TextBoxFor
        [Required(ErrorMessage = "Please enter teaster text")]
        [AllowHtml]
        public string Teaser { get; set; } // This is the text that will show up on the front page

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter a posted date")]
        public DateTime DatePosted { get; set; }

        public int? PostedBy { get; set; }

        [Required(ErrorMessage = "Please enter a Url display")]
        public string UrlDisplay { get; set; }
    }
}

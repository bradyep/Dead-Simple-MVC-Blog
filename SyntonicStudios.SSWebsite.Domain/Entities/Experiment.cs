using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SyntonicStudios.SSWebsite.Domain.Entities
{
    public class Experiment
    {
        public int ExperimentId { get; set; }

        [Required(ErrorMessage = "Please enter a display name")]
        public string DisplayName { get; set; }

        public bool UseTemplate { get; set; }

        [Required(ErrorMessage = "Experiments must have a body")]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter a creation date")]
        public DateTime CreatedOn { get; set; }

        public DateTime? LastModified { get; set; }

        [Required(ErrorMessage = "Please enter a Url display")]
        public string UrlDisplay { get; set; }
    }
}

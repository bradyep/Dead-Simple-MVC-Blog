using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SyntonicStudios.SSWebsite.Domain.Entities;

namespace SyntonicStudios.SSWebsite.WebUI.Models
{
    public class ExperimentNavItemModel
    {
        public IEnumerable<Experiment> Experiments { get; set; }
    }
}
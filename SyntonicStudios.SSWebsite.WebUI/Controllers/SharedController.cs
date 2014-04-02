using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyntonicStudios.SSWebsite.Domain.Abstract;
using SyntonicStudios.SSWebsite.WebUI.Models;

namespace SyntonicStudios.SSWebsite.WebUI.Controllers
{
    public class SharedController : Controller
    {
        //
        // GET: /Shared/

        private IExperimentRepository repository;

        public SharedController(IExperimentRepository experimentRepository)
        {
            this.repository = experimentRepository;
        }

        public ActionResult NavigationBar(int id)
        {
            return PartialView(id);
        }

        public ActionResult ExperimentNavItems()
        {
            ExperimentNavItemModel model = new ExperimentNavItemModel
            {
                Experiments = repository.Experiments.OrderByDescending(e => e.CreatedOn).Take(2)
            };

            return PartialView(model);
        }

    }
}

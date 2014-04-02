using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyntonicStudios.SSWebsite.Domain.Abstract;
using SyntonicStudios.SSWebsite.Domain.Entities;

namespace SyntonicStudios.SSWebsite.WebUI.Controllers
{
    [Authorize]
    public class ExperimentAdminController : Controller
    {
        //
        // GET: /ExperimentAdmin/

        private IExperimentRepository repository;

        public ExperimentAdminController(IExperimentRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            return View(repository.Experiments);
        }

        public ViewResult Edit(int experimentID)
        {
            Experiment experiment = repository.Experiments.FirstOrDefault(x => x.ExperimentId == experimentID);
            return View(experiment);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Experiment experiment)
        {
            if (ModelState.IsValid)
            {
                repository.SaveExperiment(experiment);
                TempData["message"] = string.Format("{0} has been saved", experiment.DisplayName);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(experiment);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Experiment { CreatedOn = DateTime.Now });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int experimentId)
        {
            Experiment deletedExperiment = repository.DeleteExperiment(experimentId);
            if (deletedExperiment != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedExperiment.DisplayName);
            }
            return RedirectToAction("Index");
        }

    }
}

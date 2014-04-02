using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SyntonicStudios.SSWebsite.WebUI.Controllers
{
    public class GameController : Controller
    {
        //
        // GET: /Game/

        /*
        // This method may list out all my games in the future.
        public ActionResult Index()
        {
            return View();
        }
        */

        /*
        public ViewResult ViewGame(string id)
        {
            Experiment experiment = expRepository.Experiments.FirstOrDefault(x => x.UrlDisplay == id);
            if (experiment != null)
            {
                return View(experiment);
            }
            else
                throw new Exception("No experiment found with that UrlDisplay");
        }
        */

        public ActionResult Speedster()
        {
            return View();
        }

        public ActionResult Sleepwalker()
        {
            return View();
        }

        public ActionResult Jacks2000()
        {
            return View();
        }

    }
}

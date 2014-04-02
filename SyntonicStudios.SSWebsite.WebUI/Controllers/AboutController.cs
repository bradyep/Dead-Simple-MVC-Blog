using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SyntonicStudios.SSWebsite.WebUI.Controllers
{
    public class AboutController : Controller
    {
        //
        // GET: /About/

        public ActionResult Resume()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}

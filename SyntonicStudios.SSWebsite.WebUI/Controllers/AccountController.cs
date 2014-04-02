using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyntonicStudios.SSWebsite.WebUI.Infrastructure.Abstract;
using SyntonicStudios.SSWebsite.WebUI.Models;

namespace SyntonicStudios.SSWebsite.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;

        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        public ViewResult Login(string returnUrl = null)
        {
            if (returnUrl != null)
            {
                TempData["message"] = "Not authorized for this action";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                    // Always redirect to Admin / Index upon login
                    //return Redirect(Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }


    }
}

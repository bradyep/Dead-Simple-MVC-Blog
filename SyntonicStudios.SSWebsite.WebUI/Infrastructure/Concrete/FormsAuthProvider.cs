using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SyntonicStudios.SSWebsite.WebUI.Infrastructure.Abstract;

namespace SyntonicStudios.SSWebsite.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        private string roles;

        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                // FormsAuthentication.SetAuthCookie(username, false);
                if (username == "guest")
                {
                    roles = "Guest";
                }
                else
                {
                    roles = "Admin";
                }
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                  1,
                  username,  //user id
                  DateTime.Now,
                  DateTime.Now.AddMinutes(20),  // expiry
                  false,  // is persistent
                  roles,
                  "/");
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
            }
            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using SyntonicStudios.SSWebsite.WebUI.Infrastructure;
using System.Web.Security;
using System.Security.Principal;

namespace SyntonicStudios.SSWebsite.WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e) 
        {
          HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null) 
            {
              FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
              string[] roles = authTicket.UserData.Split(new Char[] { ',' });
              GenericPrincipal userPrincipal = new GenericPrincipal(new GenericIdentity(authTicket.Name), roles);
              Context.User = userPrincipal;
            }
        }

    }
}
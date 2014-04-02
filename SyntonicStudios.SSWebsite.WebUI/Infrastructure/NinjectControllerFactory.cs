using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using SyntonicStudios.SSWebsite.Domain.Entities;
using SyntonicStudios.SSWebsite.Domain.Abstract;
using SyntonicStudios.SSWebsite.Domain.Concrete;
using SyntonicStudios.SSWebsite.WebUI.Infrastructure.Abstract;
using SyntonicStudios.SSWebsite.WebUI.Infrastructure.Concrete;

namespace SyntonicStudios.SSWebsite.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            // return base.GetControllerInstance(requestContext, controllerType);
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            // put bindings here
            ninjectKernel.Bind<IBlogPostRepository>().To<EFBlogPostRepository>();
            ninjectKernel.Bind<IExperimentRepository>().To<EFExperimentRepository>();

            // EmailSettings emailSettings = new EmailSettings { WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false") };
            // ninjectKernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);
            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }

    }
}

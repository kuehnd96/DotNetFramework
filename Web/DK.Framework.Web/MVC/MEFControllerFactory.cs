using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace DK.Framework.Web.MVC
{
    /// <summary>
    /// Satisfies MEF imports on controllers as they are created.
    /// </summary>
    public class MEFControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// Satisfies MEF imports on newly-created controllers.
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            IController controller = base.GetControllerInstance(requestContext, controllerType);

            Initializer.SatisfyImports(controller);

            return controller;
        }
    }
}

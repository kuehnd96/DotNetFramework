using System.Web.Http;

namespace DK.Framework.Web.WebAPI
{
    /// <summary>
    /// Satisfies MEF imports on this controller.
    /// </summary>
    public class WebAPIBaseController : ApiController
    {
        /// <summary>
        /// Satisfies MEF imports after calling the base version.
        /// </summary>
        /// <param name="controllerContext"></param>
        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            Initializer.SatisfyImports(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Reflection;

namespace DK.Framework.Store
{
    /// <summary>
    /// Contains functionality for composition using MEF.
    /// </summary>
    public class CompositionStarter
    {
        object _application;
        object _rootVisual;

        /// <summary>
        /// Creats a new composition starter.
        /// </summary>
        /// <param name="application">The application to start composition in.</param>
        /// <param name="rootVisual">The UI root of the application.</param>
        public CompositionStarter(object application, object rootVisual)
        {
            this._application = application;
            this._rootVisual = rootVisual;
        }

        /// <summary>
        /// Configures composition.
        /// </summary>
        /// <param name="assemblies">The assimblies to include in composition.</param>
        /// <param name="assemblyTypes">The types of assemblies to include in composition.</param>
        public void Configure(IEnumerable<Assembly> assemblies, IEnumerable<Type> types)
        {
            Initializer.ResetWith(assemblies, types);

            if (null != _application)
            {
                Initializer.SatisfyImports(_application);
            }

            if (null != _rootVisual)
            {
                Initializer.SatisfyImports(_rootVisual);
            }
        }

        /// <summary>
        /// Configures composition for assemblies.
        /// </summary>
        /// <param name="assemblies">The assemblies to include in composition.</param>
        public void Configure(params Assembly[] assemblies)
        {
            Configure(assemblies, null);
        }
    }
}

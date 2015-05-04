using DK.Framework.Core;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.Reflection;

namespace DK.Framework.Web
{
    /// <summary>
    /// MEF composition initializer.
    /// </summary>
    public static class Initializer
    {
        static CompositionHost _container;

        static Initializer()
        {
            Reset();
        }

        /// <summary>
        /// Reset composition.
        /// </summary>
        public static void Reset()
        {
            _container = new ContainerConfiguration().CreateContainer();
        }

        /// <summary>
        /// Reset composition with certain assemblies.
        /// </summary>
        /// <param name="partAssemblies">Collection of part assemblies to reset composition with.</param>
        public static void ResetWith(IEnumerable<Assembly> partAssemblies, IEnumerable<Type> partTypes)
        {
            Requires.IsNotNull(partAssemblies, "Assemblies parameter is null.");
            
            var configuration = new ContainerConfiguration();

            configuration.WithAssemblies(partAssemblies);

            if (null != partTypes)
            {
                configuration.WithParts(partTypes);
            }

            _container = configuration.CreateContainer();
        }

        /// <summary>
        /// Satisfies imports for a composable part.
        /// </summary>
        /// <param name="composablePart">The part to satisfy imports for.</param>
        public static void SatisfyImports(object composablePart)
        {
            _container.SatisfyImports(composablePart);
        }

        /// <summary>
        /// Satisfies a single import.
        /// </summary>
        /// <typeparam name="TExport">The type of import to satisfy.</typeparam>
        /// <returns>The composable imported part.</returns>
        public static TExport GetSingleExport<TExport>()
        {
            return _container.GetExport<TExport>();
        }

        /// <summary>
        /// Satisfies a single import of a specific export contract.
        /// </summary>
        /// <typeparam name="TExport">The type of import to satisfy.</typeparam>
        /// <param name="contractName">The name of the export contract. Cannot be null or empty.</param>
        /// <returns>The composable imported part.</returns>
        public static TExport GetSingleExport<TExport>(string contractName)
        {
            Requires.IsNotTrue(string.IsNullOrEmpty(contractName), "Parameter 'contractName' is null or empty.");

            return _container.GetExport<TExport>(contractName);
        }

        /// <summary>
        /// Satisfies all exports for a type.
        /// </summary>
        /// <typeparam name="TExport">The type of import to satisfy.</typeparam>
        /// <returns>A collection of imported types.</returns>
        public static IEnumerable<TExport> GetAllExports<TExport>()
        {
            return _container.GetExports<TExport>();
        }

        /// <summary>
        /// Satisfies all exports for a type and contract name.
        /// </summary>
        /// <typeparam name="TExport">The type of import to satisfy.</typeparam>
        /// <param name="contractName">The name of the export contract. Cannot be null or empty.</param>
        /// <returns>A collection of imported types.</returns>
        public static IEnumerable<TExport> GetAllExports<TExport>(string contractName)
        {
            Requires.IsNotTrue(string.IsNullOrEmpty(contractName), "Parameter 'contractName' is null or empty.");

            return _container.GetExports<TExport>(contractName);
        }

        public static void Dispose()
        {
            _container.Dispose();
        }
    }
}

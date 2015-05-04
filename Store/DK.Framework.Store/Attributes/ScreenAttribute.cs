using DK.Framework.Core.Interfaces;
using DK.Framework.Store.Interfaces;
using System;
using System.Composition;

namespace DK.Framework.Store.Attributes
{
    /// <summary>
    /// Represents an exported screen.
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    public class ScreenAttribute : ExportAttribute
    {
        /// <summary>
        /// Gets the type of screen to navigate to.
        /// </summary>
        public Type NavigationScreenType { get; private set; }

        /// <summary>
        /// Creates an export of a screen.
        /// </summary>
        /// <param name="navigationScreenType">The type of screen to navigate to.</param>
        public ScreenAttribute(Type navigationScreenType) : base(typeof(IScreen))
        {
            NavigationScreenType = navigationScreenType;
        }
    }
}

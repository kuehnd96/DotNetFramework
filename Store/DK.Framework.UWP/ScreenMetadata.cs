using System;

namespace DK.Framework.UWP.Interfaces
{
    /// <summary>
    /// Metadata for a Windows 8 screen.
    /// </summary>
    public class ScreenMetadata
    {
        /// <summary>
        /// The type of screen to navigate to.
        /// </summary>
        public Type NavigationScreenType { get; set; }
    }
}

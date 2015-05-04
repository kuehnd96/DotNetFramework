using System;
using System.ComponentModel;

namespace DK.Framework.Core.Interfaces
{
    /// <summary>
    /// Represents a UI element that can be navigated to.
    /// </summary>
    public interface IScreen : INotifyPropertyChanged
    {
        /// <summary>
        /// The action to run when the screen is navigated to.
        /// </summary>
        /// <param name="completed"></param>
        void Start(Action completed);

        /// <summary>
        /// The action to run when the screen is navigated from.
        /// </summary>
        /// <param name="completed"></param>
        void End(Action completed);

        /// <summary>
        /// The concrete type of the page class.
        /// </summary>
        /// <remarks>Used by the application to change the frame content.</remarks>
        Type ScreenType { get; }

        /// <summary>
        /// The relative location of the screen.
        /// </summary>
        string Location { get; }
    }
}

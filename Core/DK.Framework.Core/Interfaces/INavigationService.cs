using System;

namespace DK.Framework.Core.Interfaces
{
    /// <summary>
    /// Contract for a windows phone navigation service.
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Navigate to a screen.
        /// </summary>
        /// <typeparam name="TScreen">The <see cref="IScreen"/> to navigate to.</typeparam>
        void Navigate<TScreen>() where TScreen : IScreen;

        /// <summary>
        /// Navigate to and then initialize a screen.
        /// </summary>
        /// <typeparam name="TScreen">The <see cref="IScreen"/> to navigate to.</typeparam>
        /// <param name="initializer">The action to run right after navigating.</param>
        void Navigate<TScreen>(Action<TScreen> initializer) where TScreen : IScreen;

        /// <summary>
        /// Navigate to the first step in this application's navigation stack.
        /// </summary>
        void GoHome();

        /// <summary>
        /// Navigate to the previous step in this application's navigation stack.
        /// </summary>
        void GoBack();

        /// <summary>
        /// Navigate to the next step in this application's navigation stack (if any).
        /// </summary>
        void GoForward();

        /// <summary>
        /// Indicates whether or not backward navigation is possible.
        /// </summary>
        /// <returns>True if it is possible; Otherwise false.</returns>
        bool CanGoBack();

        /// <summary>
        /// Indicates whether or not forward navigation is possible.
        /// </summary>
        /// <returns>True if it is possible; Otherwise false.</returns>
        bool CanGoForward();
    }
}

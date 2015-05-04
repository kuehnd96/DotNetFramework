using System;

namespace DK.Framework.Core.Interfaces
{
    /// <summary>
    /// A UI element that displays screens.
    /// </summary>
    public interface INavigationTarget
    {
        /// <summary>
        /// Displays a screen in this UI element.
        /// </summary>
        /// <param name="screen">The <see cref="IScreen"/> instance to display.</param>
        void Show(IScreen screen);

        /// <summary>
        /// Displays a screen in this UI element and runs initialization action.
        /// </summary>
        /// /// <param name="screen">The <see cref="IScreen"/> instance to display.</param>
        /// <param name="initAction">The <see cref="Action"/> to perform once the screen is navigated to.</param>
        void Show(IScreen screen, Action<IScreen> initAction);

        /// <summary>
        /// The <see cref="IScreen">screen</see> currently shown in this UI element.
        /// </summary>
        IScreen Current { get; }

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

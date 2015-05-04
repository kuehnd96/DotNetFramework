using DK.Framework.Core;
using DK.Framework.Core.Interfaces;
using DK.Framework.Store.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;

namespace DK.Framework.Store
{
    /// <summary>
    /// Provides navigation functionality for Windows 8 metro applications.
    /// </summary>
    [Export(typeof(INavigationService))]
    [Shared]
    public class NavigationService : INavigationService
    {
        Action NullAction = () => { };

        /// <summary>
        /// Gets or sets the imported <see cref="IScreen"/> parts.
        /// </summary>
        [ImportMany]
        public IEnumerable<Lazy<IScreen, ScreenMetadata>> Screens { get; set; }

        /// <summary>
        /// Gets or sets the imported navigation target.
        /// </summary>
        [Import]
        public Lazy<INavigationTarget> NavigationTarget { get; set; }

        /// <summary>
        /// Navigate to a screen.
        /// </summary>
        /// <typeparam name="TScreen">The <see cref="IScreen"/> to navigate to.</typeparam>
        public void Navigate<TScreen>() where TScreen : IScreen
        {
            IScreen screen = GetScreen(typeof(TScreen));

            NavigateTo(screen);
        }

        /// <summary>
        /// Navigate to and then initialize a screen.
        /// </summary>
        /// <typeparam name="TScreen">The <see cref="IScreen"/> to navigate to.</typeparam>
        /// <param name="initializer">The action to run right after navigating.</param>
        public void Navigate<TScreen>(Action<TScreen> initializer) where TScreen : IScreen
        {
            Requires.IsNotNull(initializer, "Initializer parameter is null.");

            IScreen screen = GetScreen(typeof(TScreen));

            Action<IScreen> initAction = (loadedScreen) => { initializer((TScreen)loadedScreen); };

            NavigateTo(screen, initAction);
        }

        IScreen GetScreen(Type screenType)
        {
            // Select screen part that matches requested type
            var screenPart = (from screen in Screens where screen.Metadata.NavigationScreenType == screenType select screen).FirstOrDefault();

            if (null == screenPart)
            {
                return null;
            }

            return screenPart.Value;
        }

        void NavigateTo(IScreen view)
        {
            NavigateTo(view, null);
        }

        void NavigateTo(IScreen view, Action<IScreen> initAction)
        {
            Action navigate;

            if (null == initAction)
            {
                navigate = () =>
                {
                    NavigationTarget.Value.Show(view);
                    view.Start(NullAction);
                };
            }
            else
            {
                navigate = () =>
                {
                    NavigationTarget.Value.Show(view, initAction);
                    view.Start(NullAction);
                };
            }

            if (null != NavigationTarget.Value.Current)
            {
                NavigationTarget.Value.Current.End(navigate);
            }
            else
            {
                navigate();
            }
        }

        /// <summary>
        /// Navigates back to the home screen.
        /// </summary>
        public void GoHome()
        {
            NavigationTarget.Value.GoHome();
        }

        /// <summary>
        /// Navigates back one screen (if applicable).
        /// </summary>
        public void GoBack()
        {
            NavigationTarget.Value.GoBack();
        }

        /// <summary>
        /// Navigates forward one screen (if applicable).
        /// </summary>
        public void GoForward()
        {
            NavigationTarget.Value.GoForward();
        }

        /// <summary>
        /// Indicates whether or not backward navigation is possible.
        /// </summary>
        /// <returns>True if it is possible; Otherwise false.</returns>
        public bool CanGoBack()
        {
            return NavigationTarget.Value.CanGoBack();
        }

        /// <summary>
        /// Indicates whether or not forward navigation is possible.
        /// </summary>
        /// <returns>True if it is possible; Otherwise false.</returns>
        public bool CanGoForward()
        {
            return NavigationTarget.Value.CanGoForward();
        }
    }
}

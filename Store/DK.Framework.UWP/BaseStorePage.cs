using DK.Framework.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace DK.Framework.UWP
{
    /// <summary>
    /// Base page for UWP Applications.
    /// </summary>
    /// <remarks>Houses functionality for maintaining page state.</remarks>
    public abstract class BaseStorePage : Page
    {
        //TODO: Add support for back button on mobile

        const string PageKeyPrefix = "Page-";
        
        private string _pageKey;
        
        [Import]
        public INavigationService NavigationService { get; set; }

        /// <summary>
        /// Default ctor.
        /// </summary>
        public BaseStorePage()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled) return;

            Initializer.SatisfyImports(this);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.  
        /// This method calls <see cref="LoadState"/>, where all page specific
        /// navigation and process lifetime management logic should be placed.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property provides the group to be displayed.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var frameState = SuspensionManager.SessionStateForFrame(this.Frame);
            this._pageKey = PageKeyPrefix + this.Frame.BackStackDepth;

            if (e.NavigationMode == NavigationMode.New)
            {
                // Clear existing state for forward navigation when adding a new page to the
                // navigation stack
                var nextPageKey = this._pageKey;
                int nextPageIndex = this.Frame.BackStackDepth;
                
                while (frameState.Remove(nextPageKey))
                {
                    nextPageIndex++;
                    nextPageKey = PageKeyPrefix + nextPageIndex;
                }

                // Pass the navigation parameter to the new page
                LoadState(e.Parameter, null);
            }
            else
            {
                // Pass the navigation parameter and preserved page state to the page, using
                // the same strategy for loading suspended state and recreating pages discarded
                // from cache
                LoadState(e.Parameter, (Dictionary<String, Object>)frameState[this._pageKey]);
            }
        }

        /// <summary>
        /// Invoked when this page will no longer be displayed in a Frame.
        /// This method calls <see cref="SaveState"/>, where all page specific
        /// navigation and process lifetime management logic should be placed.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property provides the group to be displayed.</param>
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);

            var frameState = SuspensionManager.SessionStateForFrame(this.Frame);
            var pageState = new Dictionary<String, Object>();
            
            SaveState(pageState);

            frameState[_pageKey] = pageState;
        }

        /// <summary>
        /// Applies saved state to a view.
        /// </summary>
        /// <param name="navigationParameter">Navigation parameter for a view.</param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected abstract void LoadState(Object navigationParameter, Dictionary<string, Object> pageState);

        /// <summary>
        /// Collects state to be saved between visits to a view.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected abstract void SaveState(Dictionary<string, Object> pageState);
    }
}

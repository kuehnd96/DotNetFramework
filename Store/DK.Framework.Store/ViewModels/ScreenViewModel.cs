using DK.Framework.Core.Interfaces;
using DK.Framework.Store.Commands;
using DK.Framework.Store.Interfaces;
using System.Composition;
using Windows.ApplicationModel.DataTransfer;

namespace DK.Framework.Store.ViewModels
{
    /// <summary>
    /// Base view model for Windows Store screens.
    /// </summary>
    public abstract class ScreenViewModel : Bindable
    {
        [Import]
        public INavigationService Navigation { get; set; }

        DelegateCommand _goBackCommand;
        DelegateCommand _goForwardCommand;
        DelegateCommand _goHomeCommand;

        /// <summary>
        /// Gets a command that navigates backward.
        /// </summary>
        public DelegateCommand GoBackCommand
        {
            get
            {
                if (null == _goBackCommand)
                {
                    _goBackCommand = new DelegateCommand(GoBack);
                }
                
                return _goBackCommand;
            }
        }

        /// <summary>
        /// Gets a command that navigates forward.
        /// </summary>
        public DelegateCommand GoForwardCommand
        {
            get
            {
                if (null == _goForwardCommand)
                {
                    _goForwardCommand = new DelegateCommand(GoForward);
                }

                return _goForwardCommand;
            }
        }

        /// <summary>
        /// Gets a command that navigates back home.
        /// </summary>
        public DelegateCommand GoHomeCommand
        {
            get
            {
                if (null == _goHomeCommand)
                {
                    _goHomeCommand = new DelegateCommand(GoHome);
                }

                return _goHomeCommand;
            }
        }
        
        void GoBack(object parameter)
        {
            Navigation.GoBack();
        }

        void GoForward(object parameter)
        {
            Navigation.GoForward();
        }

        void GoHome(object parameter)
        {
            Navigation.GoHome();
        }

        /// <summary>
        /// Returns no content.
        /// </summary>
        /// <param name="request">Not used.</param>
        /// <returns>True.</returns>
        public virtual bool GetShareContent(DataRequest request)
        {
            return true;
        }
    }
}

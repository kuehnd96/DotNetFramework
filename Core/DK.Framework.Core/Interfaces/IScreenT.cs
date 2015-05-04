using System.ComponentModel;

namespace DK.Framework.Core.Interfaces
{
    /// <summary>
    /// A UI elements that can be navigated to.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the screen's view model.</typeparam>
    public interface IScreen<TViewModel> : IScreen where TViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the view model of the screen.
        /// </summary>
        TViewModel ViewModel { get; set; }
    }
}

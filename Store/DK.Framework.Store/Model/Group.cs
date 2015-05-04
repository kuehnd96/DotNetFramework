using System.Collections.ObjectModel;

namespace DK.Framework.Store.Model
{
    /// <summary>
    /// A bindable group of items.
    /// </summary>
    /// <typeparam name="TGroupedItem">The type of item to be grouped.</typeparam>
    public class Group<TGroupedItem> : Bindable
    {
        string _name;
        ObservableCollection<TGroupedItem> _items;

        /// <summary>
        /// Gets or sets the text label of the group.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        /// <summary>
        /// Gets or sets the collection of items in this group.
        /// </summary>
        public ObservableCollection<TGroupedItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }
    }
}

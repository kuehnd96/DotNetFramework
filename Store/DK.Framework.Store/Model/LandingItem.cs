using DK.Framework.Core;

namespace DK.Framework.Store.Model
{
    /// <summary>
    /// A bindable item that represent a navigation option in a list of items.
    /// </summary>
    /// <typeparam name="TItem">The type of entity being navigated to.</typeparam>
    public sealed class LandingItem<TItem> : Bindable where TItem : class
    {
        TItem _thing;
        bool _hasItem;
        string _label;
        object _tag;

        /// <summary>
        /// Gets or sets the entity item to be displayed.
        /// </summary>
        public TItem Thing
        {
            get { return _thing; }
            private set { SetProperty(ref _thing, value); }
        }

        /// <summary>
        /// Gets or sets whether this item has an item.
        /// </summary>
        public bool HasItem
        {
            get { return _hasItem; }
            private set { SetProperty(ref _hasItem, value); }
        }

        /// <summary>
        /// Gets or sets the label for an empty instance.
        /// </summary>
        public string Label
        {
            get { return _label; }
            private set { SetProperty(ref _label, value); }
        }

        /// <summary>
        /// Gets or sets a general object for this item.
        /// </summary>
        public object Tag
        {
            get { return _tag; }
            set { SetProperty(ref _tag, value); }
        }

        /// <summary>
        /// Creates an instance with an item.
        /// </summary>
        /// <param name="item"></param>
        public LandingItem(TItem item)
        {
            Requires.IsNotNull(item, "Item parameter is null.");
            
            Thing = item;
            HasItem = true;
        }

        /// <summary>
        /// Creates an instance without an item.
        /// </summary>
        /// <param name="label"></param>
        public LandingItem(string label)
        {
            Requires.IsNotNull(label, "Label parameter is null.");
            
            Label = label;
            HasItem = false;
        }
    }
}

using Windows.Foundation.Collections;

namespace DK.Framework.UWP.Validation
{
    /// <summary>
    /// Event arguments for a change in validation status.
    /// </summary>
    public class ValidationDictionaryChangedEventArgs : IMapChangedEventArgs<string>
    {
        /// <summary>
        /// Gets the collection change associated with the validation status change.
        /// </summary>
        public CollectionChange CollectionChange { get; private set; }

        /// <summary>
        /// Gets the key of the changed item in the validation message collection.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Creates a populated instance.
        /// </summary>
        /// <param name="change">The collection change associated with the validation status change.</param>
        /// <param name="key">The key of the changed item in the validation message collection.</param>
        public ValidationDictionaryChangedEventArgs(CollectionChange change, string key)
        {
            CollectionChange = change;
            Key = key;
        }
    }
}

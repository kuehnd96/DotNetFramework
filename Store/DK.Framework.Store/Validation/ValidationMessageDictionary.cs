using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation.Collections;

namespace DK.Framework.Store.Validation
{
    /// <summary>
    /// Observable collection of validation error messages.
    /// </summary>
    public class ValidationMessageDictionary : IObservableMap<string, object>
    {
        #region FIELDS

        readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        /// <summary>
        /// Fires when this collection of error messages changes.
        /// </summary>
        public event MapChangedEventHandler<string, object> MapChanged; 

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets whether this collection is read only.
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Indexer to retrieve an item by key.
        /// </summary>
        /// <param name="key">The key of the item to retrieve.</param>
        /// <returns>The item matching the supplied key (if contained).</returns>
        public object this[string key]
        {
            get
            {
                if (_dictionary.ContainsKey(key))
                {
                    return this._dictionary[key];
                }

                return null;
            }
            set
            {
                this._dictionary[key] = value;
                this.InvokeMapChanged(CollectionChange.ItemChanged, key);
            }
        }

        /// <summary>
        /// Collection of keys of items in this collection.
        /// </summary>
        public ICollection<string> Keys
        {
            get { return this._dictionary.Keys; }
        }

        /// <summary>
        /// Collecton of all values of items in this collection.
        /// </summary>
        public ICollection<object> Values
        {
            get { return this._dictionary.Values; }
        }

        /// <summary>
        /// Gets the number of items in this collection.
        /// </summary>
        public int Count
        {
            get { return this._dictionary.Count; }
        }
 
        #endregion

        #region METHODS

        /// <summary>
        /// Adds a key value combination to this collection.
        /// </summary>
        /// <param name="key">The key to add.</param>
        /// <param name="value">The value to add.</param>
        public void Add(string key, object value)
        {
            this._dictionary.Add(key, value);
            this.InvokeMapChanged(CollectionChange.ItemInserted, key);
        }

        /// <summary>
        /// Adds an item to this collection.
        /// </summary>
        /// <param name="item">The KeyValuePair to add.</param>
        public void Add(KeyValuePair<string, object> item)
        {
            this.Add(item.Key, item.Value);
        }

        /// <summary>
        /// Removes an item by key (if contained).
        /// </summary>
        /// <param name="key">The key of the item to be removed.</param>
        /// <returns>True if the item was removed; Otherwise false.</returns>
        public bool Remove(string key)
        {
            if (this._dictionary.Remove(key))
            {
                this.InvokeMapChanged(CollectionChange.ItemRemoved, key);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes an item from this collection.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns>True if the item was removed; Otherwise false.</returns>
        public bool Remove(KeyValuePair<string, object> item)
        {
            object currentValue;

            if (this._dictionary.TryGetValue(item.Key, out currentValue) &&
                Object.Equals(item.Value, currentValue) && this._dictionary.Remove(item.Key))
            {
                this.InvokeMapChanged(CollectionChange.ItemRemoved, item.Key);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes all items from this collection.
        /// </summary>
        public void Clear()
        {
            var priorKeys = this._dictionary.Keys.ToArray();
            this._dictionary.Clear();

            foreach (var key in priorKeys)
            {
                this.InvokeMapChanged(CollectionChange.ItemRemoved, key);
            }
        }

        /// <summary>
        /// Whether or not an item with a key is present in this collection.
        /// </summary>
        /// <param name="key">The key to check for in this collection.</param>
        /// <returns>True if an item with the specified key is contained in this collection; Otherwise false.</returns>
        public bool ContainsKey(string key)
        {
            return this._dictionary.ContainsKey(key);
        }

        /// <summary>
        /// Tries to retrieve an item by key.
        /// </summary>
        /// <param name="key">The key of the item to attempt to retrieve.</param>
        /// <param name="value">The value (if any) of the item retrieved.</param>
        /// <returns>True if an item was retrieved from this collection; Otherwise false.</returns>
        public bool TryGetValue(string key, out object value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        /// <summary>
        /// Checks whether an item exists in this collection.
        /// </summary>
        /// <param name="item">The <see cref="KeyValuePair"/> to check for in this collection.</param>
        /// <returns>True if the item exists in this collection; Otherwise false.</returns>
        public bool Contains(KeyValuePair<string, object> item)
        {
            return this._dictionary.Contains(item);
        }

        private void InvokeMapChanged(CollectionChange change, string key)
        {
            var eventHandler = MapChanged;

            if (eventHandler != null)
            {
                eventHandler(this, new ValidationDictionaryChangedEventArgs(CollectionChange.ItemInserted, key));
            }
        }

        /// <summary>
        /// Gets an enumerator for key value pairs in this collection.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return this._dictionary.GetEnumerator();
        }

        /// <summary>
        /// Gets an enumerator for key value pairs in this collection.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._dictionary.GetEnumerator();
        }

        /// <summary>
        /// Copies the item in this collection to an arrary.
        /// </summary>
        /// <param name="array">The array to copy items to.</param>
        /// <param name="arrayIndex">The index to start copying at.</param>
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            int arraySize = array.Length;

            foreach (var pair in this._dictionary)
            {
                if (arrayIndex >= arraySize)
                {
                    break;
                }

                array[arrayIndex++] = pair;
            }
        }
 
        #endregion
    }
}

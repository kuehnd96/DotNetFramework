using DK.Framework.Core;
using DK.Framework.Core.Interfaces;
using DK.Framework.UWP.Interfaces;
using System.Collections.Generic;
using System.Composition;

namespace DK.Framework.UWP
{
    /// <summary>
    /// Repository for data that specific to the current Windows 8 application session.
    /// </summary>
    [Export(typeof(ISessionState))]
    [Shared]
    public class SessionState : ISessionState
    {
        Dictionary<string, object> _state = new Dictionary<string, object>();

        /// <summary>
        /// Sets a value.
        /// </summary>
        /// <typeparam name="TValue">The type of data to be set.</typeparam>
        /// <param name="key">The key of the data.</param>
        /// <param name="value">The value to be set.</param>
        public void Set<TValue>(string key, TValue value)
        {
            Requires.IsNotTrue(string.IsNullOrEmpty(key), "Key parameter is null or empty.");

            if (Contains(key))
            {
                _state[key] = value;
            }
            else
            {
                _state.Add(key, value);
            }
        }

        /// <summary>
        /// Gets a value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value to get.</typeparam>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The desired value if present; Otherwise the default of the specified type.</returns>
        public TValue Get<TValue>(string key)
        {
            Requires.IsNotTrue(string.IsNullOrEmpty(key), "Key parameter is null or empty.");

            if (Contains(key))
            {
                return (TValue)_state[key];
            }

            return default(TValue);
        }

        /// <summary>
        /// Determines if a value is stored within.
        /// </summary>
        /// <param name="key">The key of the value to check for.</param>
        /// <returns>True if the value is stored within; Otherwise false.</returns>
        public bool Contains(string key)
        {
            Requires.IsNotTrue(string.IsNullOrEmpty(key), "Key parameter is null or empty.");

            return _state.ContainsKey(key);
        }

        /// <summary>
        /// Removes a value.
        /// </summary>
        /// <param name="key">The key of the value to remove.</param>
        public void Remove(string key)
        {
            Requires.IsNotTrue(string.IsNullOrEmpty(key), "Key parameter is null or empty.");

            if (Contains(key))
            {
                _state.Remove(key);
            }
        }
    }
}

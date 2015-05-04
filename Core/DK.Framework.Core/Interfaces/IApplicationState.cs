using System;
using System.Threading.Tasks;

namespace DK.Framework.Core.Interfaces
{
    /// <summary>
    /// Respository for data that is persisted between application sessions.
    /// </summary>
    public interface IApplicationState
    {
        /// <summary>
        /// Sets a value.
        /// </summary>
        /// <typeparam name="TValue">The type of data to be set.</typeparam>
        /// <param name="key">The key of the data.</param>
        /// <param name="value">The value to be set.</param>
        void Set<TValue>(string key, TValue value);

        /// <summary>
        /// Gets a value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value to get.</typeparam>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The desired value if present; Otherwise the default of the specified type.</returns>
        TValue Get<TValue>(string key);

        /// <summary>
        /// Determines if a value is stored within.
        /// </summary>
        /// <param name="key">The key of the value to check for.</param>
        /// <returns>True if the value is stored within; Otherwise false.</returns>
        bool Contains(string key);

        /// <summary>
        /// Removes a value.
        /// </summary>
        /// <param name="key">The key of the value to remove.</param>
        void Remove(string key);
    }
}

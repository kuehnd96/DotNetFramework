using DK.Framework.Core.Interfaces;
using LocalInterfaces = DK.Framework.Store.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using DK.Framework.Core;

namespace DK.Framework.Store
{
    /// <summary>
    /// Respository for data that is persisted between application sessions.
    /// </summary>
    /// <remarks>Uses application isolated storage.</remarks>
    [Export(typeof(IApplicationState))]
    [Shared]
    public class ApplicationState : IApplicationState
    {
        private static List<Type> _knownTypes = new List<Type>();
        
        IPropertySet ApplicationSettings
        {
            get { return ApplicationData.Current.LocalSettings.Values; }
        }

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
                ApplicationSettings[key] = value;
            }
            else
            {
                ApplicationSettings.Add(key, value);
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
                return (TValue)ApplicationSettings[key];
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
            return ApplicationSettings.Keys.Contains(key);
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
                ApplicationSettings.Remove(key);
            }
        }

        /// <summary>
        /// Serializes and saves data to a file in the applicaton's local folder.
        /// </summary>
        /// <param name="data">The data to save.</param>
        /// <param name="dataType">The type of data to save.</param>
        /// <param name="fileName">The name of the file to save.</param>
        /// <returns></returns>
        public static async Task SaveSerializedDataToFile(object data, Type dataType, string fileName)
        {
            Requires.IsNotNull(data, "Data to store is null.");
            Requires.IsNotNull(dataType, "Type of data to store in null.");
            Requires.IsNotNull(fileName, "File name parameter is null.");
            
            // Serialize the session state synchronously to avoid asynchronous access to shared state
            MemoryStream sessionData = new MemoryStream();
            DataContractSerializer serializer = new DataContractSerializer(dataType, _knownTypes);
            serializer.WriteObject(sessionData, data);

            // Get an output stream for the SessionState file and write the state asynchronously
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            
            using (Stream fileStream = await file.OpenStreamForWriteAsync())
            {
                sessionData.Seek(0, SeekOrigin.Begin);
                await sessionData.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }
        }

        /// <summary>
        /// Loads and deserializes data from a file in the application's local folder.
        /// </summary>
        /// <param name="fileName">The name of the file to read from.</param>
        /// <returns>The deserialized data from the file.</returns>
        public static async Task<object> RestoreSerializedDataFromFile(string fileName)
        {
            Requires.IsNotNull(fileName, "File name parameter is null.");
            
            // Get the input stream for the SessionState file
            StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            
            using (IInputStream inStream = await file.OpenSequentialReadAsync())
            {
                // Deserialize the Session State
                DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<string, object>), _knownTypes);
                return serializer.ReadObject(inStream.AsStreamForRead());
            }
        }
    }
}

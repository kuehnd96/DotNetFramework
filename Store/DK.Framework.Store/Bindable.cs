using DK.Framework.Store.Attributes;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DK.Framework.Store
{
    /// <summary>
    /// Base class for anything that implements <see cref="INotifyPropertyChanged"/>.
    /// </summary>
    public abstract class Bindable : INotifyPropertyChanged
    {
        bool _hasChanged = false;
        bool _isTrackingChanges = false;

        /// <summary>
        /// Fired when a bindable property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets whether a trackable property has changed on this instance.
        /// </summary>
        public bool HasChanged
        {
            get { return _hasChanged; }
            set { SetProperty(ref _hasChanged, value); }
        }

        /// <summary>
        /// Gets or sets whether changes are being tracked.
        /// </summary>
        public bool IsTrackingChanges { get; set; }
        
        /// <summary>
        /// Checks if a property already matches a desired value.  Sets the property and
        /// notifies listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="propertyName">Name of the property used to notify listeners.  This
        /// value is optional and can be provided automatically when invoked from compilers that
        /// support CallerMemberName.</param>
        /// <returns>True if the value was changed, false if the existing value matched the
        /// desired value.</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);

            if ((IsTrackingChanges) &&
                (!HasChanged) && 
                (IsChangeTrackable(propertyName)))
            {
                HasChanged = true;
            }

            return true;
        }

        /// <summary>
        /// Notifies listeners that a property value has changed.
        /// </summary>
        /// <param name="propertyName">Name of the property used to notify listeners.  This
        /// value is optional and can be provided automatically when invoked from compilers
        /// that support <see cref="CallerMemberNameAttribute"/>.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Determines if a declared property on this type is set for change tracking.
        /// </summary>
        /// <param name="propertyName">The name of the declared property to check for change tracking.</param>
        /// <returns>True if the declared property exists and is set for change tracking; Otherwise false.</returns>
        bool IsChangeTrackable(string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                Type bindableType = this.GetType();

                PropertyInfo changedProperty = bindableType.GetRuntimeProperty(propertyName);

                if (changedProperty != null)
                {
                    var changeTrackAttribute = changedProperty.GetCustomAttribute<TrackChangeAttribute>();

                    return (changeTrackAttribute != null);
                } 
            }

            return false;
        }
    }
}

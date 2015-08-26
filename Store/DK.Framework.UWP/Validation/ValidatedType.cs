using System.Linq;
using Windows.Foundation.Collections;

namespace DK.Framework.UWP.Validation
{
    /// <summary>
    /// Bindable type that publishes validation status.
    /// </summary>
    public abstract class ValidatedType : Bindable
    {
        IObservableMap<string, object> _messageDictionary;

        /// <summary>
        /// Gets or sets the observable map of error messages.
        /// </summary>
        public IObservableMap<string, object> MessageDictionary
        {
            get { return _messageDictionary; }
            set { SetProperty(ref _messageDictionary, value); }
        }

        /// <summary>
        /// Gets whether this object is valid.
        /// </summary>
        public bool IsValid
        {
            get
            {
                return !MessageDictionary.Any();
            }
        }

        /// <summary>
        /// Collection of properties that are validated.
        /// </summary>
        protected string[] ValidatedProperties { get; private set; }

        /// <summary>
        /// Creates a new instance with validated properties.
        /// </summary>
        /// <param name="validationPropertyNames">Collection of names of validated properties.</param>
        protected ValidatedType(string[] validationPropertyNames)
        {
            ValidatedProperties = validationPropertyNames;

            MessageDictionary = new ValidationMessageDictionary();
        }

        /// <summary>
        /// Extends base property changed functionality with a validated check for the changed property.
        /// </summary>
        /// <param name="propertyName">the name of the property that changed.</param>
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if ((null != propertyName) && 
                (ValidatedProperties.Contains(propertyName)))
            {
                string errorMessage = GetValidationError(propertyName);

                if (null == errorMessage)
                {
                    MessageDictionary.Remove(propertyName);
                }
                else
                {
                    if (MessageDictionary.ContainsKey(propertyName))
                    {
                        MessageDictionary[propertyName] = errorMessage;
                    }
                    else
                    {
                        MessageDictionary.Add(propertyName, errorMessage);
                    }
                }
            }
        }

        /// <summary>
        /// Validates a property.
        /// </summary>
        /// <param name="propertyName">The name of the property to validate.</param>
        /// <returns>An error message if the property is not valid; Otherwise null.</returns>
        protected abstract string GetValidationError(string propertyName);
    }
}

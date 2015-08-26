using System;
using Windows.UI.Xaml.Data;

namespace DK.Framework.UWP.Converters
{
    /// <summary>
    /// Simply converts a boolean value to its opposite boolean value and back.
    /// </summary>
    public class BooleanNegationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (null == value)
            {
                return false;
            }

            bool sourceValue = (bool)value;

            return !sourceValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (null == value)
            {
                return false;
            }

            bool sourceValue = (bool)value;

            return !sourceValue;
        }
    }
}

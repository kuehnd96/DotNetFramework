using System;
using Windows.UI.Xaml.Data;

namespace DK.Framework.UWP.Converters
{
    /// <summary>
    /// Allows the use of string.format in binding. Useful for one-way binding only.
    /// </summary>
    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string format = parameter as String;

            if (format != null)
            {
                return string.Format(format, value);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}

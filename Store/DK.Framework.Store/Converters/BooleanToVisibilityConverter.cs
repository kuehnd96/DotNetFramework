using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace DK.Framework.Store.Converters
{
    /// <summary>
    /// Converts a boolean to a visibility value.
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (null == value)
            {
                return Visibility.Collapsed;
            }

            bool isVisible = (bool)value;

            if (null == parameter)
            {
                return isVisible ? Visibility.Visible : Visibility.Collapsed;
            }
            else // flips due to the mere presence of parameter
            {
                return isVisible ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var visibility = (Visibility)value;

            if (null == parameter)
            {
                return visibility == Visibility.Visible;
            }
            else // flips due to the mere presence of parameter
            {
                return visibility == Visibility.Collapsed;
            }
        }
    }
}

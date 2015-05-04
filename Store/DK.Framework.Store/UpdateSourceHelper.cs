using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DK.Framework.Store
{
    /// <summary>
    /// Attached properties for updating a binding source when a key is pressed in a TextBox.
    /// </summary>
    public class UpdateSourceHelper
    {
        public static string GetUpdateSourceText(DependencyObject obj)
        {
            return (string)obj.GetValue(UpdateSourceTextProperty);
        }

        public static void SetUpdateSourceText(DependencyObject obj, string value)
        {
            obj.SetValue(UpdateSourceTextProperty, value);
        }

        // Using a DependencyProperty as the backing store for UpdateSourceText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UpdateSourceTextProperty =
            DependencyProperty.RegisterAttached("UpdateSourceText", typeof(string), typeof(UpdateSourceHelper), new PropertyMetadata(""));

        public static bool GetIsEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnabledProperty);
        }

        public static void SetIsEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnabledProperty, value);
        }

        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(UpdateSourceHelper), new PropertyMetadata(false, OnIsEnabledChanged));

        static void OnIsEnabledChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var textBox = obj as TextBox;
            
            if (null != textBox)
            {
                if ((bool)args.NewValue)
                {
                    textBox.TextChanged += AttachedTextBoxTextChanged;
                }
                else
                {
                    textBox.TextChanged -= AttachedTextBoxTextChanged;
                }
            }
        }

        static void AttachedTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            if (null != textBox)
            {
                textBox.SetValue(UpdateSourceHelper.UpdateSourceTextProperty, textBox.Text);
            }
        }   
    }
}

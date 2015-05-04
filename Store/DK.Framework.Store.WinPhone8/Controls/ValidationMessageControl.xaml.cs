using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DK.Framework.Store.WinPhone8.Controls
{
    public sealed partial class ValidationMessageControl : UserControl
    {
        public ValidationMessageControl()
        {
            InitializeComponent();
        }

        public IEnumerable ErrorListSource
        {
            get { return (IEnumerable)GetValue(ErrorListSourceProperty); }
            set { SetValue(ErrorListSourceProperty, value); }
        }

        public static readonly DependencyProperty ErrorListSourceProperty =
            DependencyProperty.Register("ErrorListSource", typeof(IEnumerable), typeof(ValidationMessageControl), new PropertyMetadata(null, OnErrorListChanged));

        static void OnErrorListChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            ValidationMessageControl control = dependencyObject as ValidationMessageControl;

            control.errorList.ItemsSource = args.NewValue as IEnumerable;
        }
    }
}

using System;
using System.Net;
using System.Windows;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Controls;

namespace DK.Framework.Store.Behaviors
{
    public class UpdateSourceOnTextChangedBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.TextChanged += this.OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            BindingExpression bindingExpression = this.AssociatedObject.GetBindingExpression(TextBox.TextProperty);

            bindingExpression.UpdateSource();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            this.AssociatedObject.TextChanged -= this.OnTextChanged;
        }
    }
}

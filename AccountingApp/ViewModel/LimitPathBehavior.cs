using Microsoft.Xaml.Behaviors;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace AccountingApp.ViewModel
{
    class LimitPathBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.PreviewTextInput += AssociatedObject_PreviewTextInput;
        }

        private void AssociatedObject_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(new[] { '*', '"', '?', ':', '/', '\\', '<', '>', '|'}.Any(c => e.Text.Contains(c)))
            {
                e.Handled = true;
                return;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewTextInput -= AssociatedObject_PreviewTextInput;
        }
    }
}

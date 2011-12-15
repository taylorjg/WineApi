// http://www.codeproject.com/KB/WPF/AttachedBehaviors.aspx

using System;
using System.Windows;
using System.Windows.Controls;

namespace WineDemo.Behaviours
{
    public static class ListBoxItemBehaviour
    {
        public static bool GetIsBroughtIntoViewWhenSelected(ListBoxItem listBoxItem)
        {
            return (bool)listBoxItem.GetValue(IsBroughtIntoViewWhenSelectedProperty);
        }

        public static void SetIsBroughtIntoViewWhenSelected(ListBoxItem listBoxItem, bool value)
        {
            listBoxItem.SetValue(IsBroughtIntoViewWhenSelectedProperty, value);
        }

        public static readonly DependencyProperty IsBroughtIntoViewWhenSelectedProperty =
            DependencyProperty.RegisterAttached(
                "IsBroughtIntoViewWhenSelected",
                typeof(bool),
                typeof(ListBoxItemBehaviour),
                new UIPropertyMetadata(false, OnIsBroughtIntoViewWhenSelectedChanged));

        private static void OnIsBroughtIntoViewWhenSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ListBoxItem item = d as ListBoxItem;

            if (item == null) {
                return;
            }

            if (!(e.NewValue is bool)) {
                return;
            }

            if ((bool)e.NewValue)
                item.Selected += OnListBoxItemSelected;
            else
                item.Selected -= OnListBoxItemSelected;
        }

        private static void OnListBoxItemSelected(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = e.OriginalSource as ListBoxItem;

            if (item != null) {
                item.BringIntoView();
            }
        }
    }
}

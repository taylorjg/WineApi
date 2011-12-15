// http://www.codeproject.com/KB/WPF/AttachedBehaviors.aspx

using System;
using System.Windows;
using System.Windows.Controls;

namespace WineDemo.Behaviours
{
    public static class ListViewItemBehaviour
    {
        public static bool GetIsBroughtIntoViewWhenSelected(ListViewItem listViewItem)
        {
            return (bool)listViewItem.GetValue(IsBroughtIntoViewWhenSelectedProperty);
        }

        public static void SetIsBroughtIntoViewWhenSelected(ListViewItem listViewItem, bool value)
        {
            listViewItem.SetValue(IsBroughtIntoViewWhenSelectedProperty, value);
        }

        public static readonly DependencyProperty IsBroughtIntoViewWhenSelectedProperty =
            DependencyProperty.RegisterAttached(
                "IsBroughtIntoViewWhenSelected",
                typeof(bool),
                typeof(ListViewItemBehaviour),
                new UIPropertyMetadata(false, OnIsBroughtIntoViewWhenSelectedChanged));

        private static void OnIsBroughtIntoViewWhenSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ListViewItem item = d as ListViewItem;

            if (item == null) {
                return;
            }

            if (!(e.NewValue is bool)) {
                return;
            }

            if ((bool)e.NewValue)
                item.Selected += OnListViewItemSelected;
            else
                item.Selected -= OnListViewItemSelected;
        }

        private static void OnListViewItemSelected(object sender, RoutedEventArgs e)
        {
            ListViewItem item = e.OriginalSource as ListViewItem;

            if (item != null) {
                item.BringIntoView();
            }
        }
    }
}

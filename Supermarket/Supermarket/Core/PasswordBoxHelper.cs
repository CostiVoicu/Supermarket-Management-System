namespace Supermarket.Core
{
    using System.Windows;
    using System.Windows.Controls;

    public static class PasswordBoxHelper
    {
        public static readonly DependencyProperty BoundPassword =
            DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(PasswordBoxHelper), new PropertyMetadata(string.Empty, OnBoundPasswordChanged));

        public static string GetBoundPassword(DependencyObject d)
        {
            var box = d as PasswordBox;
            return (box != null) ? (string)box.GetValue(BoundPassword) : string.Empty;
        }

        public static void SetBoundPassword(DependencyObject d, string value)
        {
            var box = d as PasswordBox;
            if (box == null)
                return;

            box.PasswordChanged -= PasswordChanged;

            if (!(bool)box.GetValue(UpdatingPassword))
            {
                box.SetValue(BoundPassword, value);
                box.Password = value;
            }

            box.PasswordChanged += PasswordChanged;
        }

        private static readonly DependencyProperty UpdatingPassword =
            DependencyProperty.RegisterAttached("UpdatingPassword", typeof(bool), typeof(PasswordBoxHelper), new PropertyMetadata(false));

        private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var box = d as PasswordBox;
            if (box == null)
                return;

            box.PasswordChanged -= PasswordChanged;

            if (!(bool)box.GetValue(UpdatingPassword))
            {
                box.Password = (string)e.NewValue;
            }

            box.PasswordChanged += PasswordChanged;
        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            var box = sender as PasswordBox;
            if (box == null)
                return;

            box.SetValue(UpdatingPassword, true);
            SetBoundPassword(box, box.Password);
            box.SetValue(UpdatingPassword, false);
        }
    }


}

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Theme04_Task01
{
    public class ToggleButton : Button
    {
        public static readonly DependencyProperty IsToggledProperty =
            DependencyProperty.Register
            (
                "IsToggled",
                typeof(bool),
                typeof(ToggleButton),
                new PropertyMetadata(false, OnIsToggledChanged)
            );
        public bool IsToggled
        {
            get => (bool)GetValue(IsToggledProperty);
            set => SetValue(IsToggledProperty, value);
        }
        private static void OnIsToggledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = d as ToggleButton;

            if (button != null)
                button.UpdateAppearance();
        }
        public ToggleButton()
        {
            UpdateAppearance();
            Click += OnClick;
        }
        private void OnClick(object sender, RoutedEventArgs e)
        {
            IsToggled = !IsToggled;
        }
        private void UpdateAppearance()
        {
            Content = IsToggled ? "ON" : "OFF";
            Background = IsToggled ? Brushes.Green : Brushes.Red;
        }
    }
}
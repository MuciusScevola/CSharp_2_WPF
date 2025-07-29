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
            DependencyProperty.Register(
                "IsToggled", // Имя свойства
                typeof(bool), // Тип свойства
                typeof(ToggleButton), // Тип класса, где определено свойство
                new PropertyMetadata(false, OnIsToggledChanged)); // Значение по умолчанию и обработчик изменения

        // Обертка над DependencyProperty для удобного использования
        public bool IsToggled
        {
            get { return (bool)GetValue(IsToggledProperty); }
            set { SetValue(IsToggledProperty, value); }
        }

        // Обработчик изменения значения IsToggled
        private static void OnIsToggledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = d as ToggleButton;
            if (button != null)
            {
                // Изменяем фон и текст в зависимости от состояния
                button.UpdateAppearance();
            }
        }

        // Конструктор
        public ToggleButton()
        {
            // Устанавливаем начальное значение текста и фона
            UpdateAppearance();
            // Добавляем обработчик щелчка мыши
            Click += OnClick;
        }

        // Обработчик щелчка мыши
        private void OnClick(object sender, RoutedEventArgs e)
        {
            // Переключаем состояние IsToggled
            IsToggled = !IsToggled;
        }

        // Метод для обновления внешнего вида кнопки
        private void UpdateAppearance()
        {
            // Изменяем текст
            Content = IsToggled ? "ON" : "OFF";

            // Изменяем цвет фона
            Background = IsToggled ? Brushes.Green : Brushes.Red;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Theme09_Task01
{
    public partial class MainWindow : Window
    {
        // Коллекция для хранения последовательности цветов
        private Stack<Brush> _colorHistory = new Stack<Brush>();

        private Brush _currentColor;

        // Текущий цвет
        public Brush CurrentColor
        {
            get => _currentColor;
            set
            {
                _currentColor = value;

                // Добавляем новый цвет в стек, если предыдущий цвет не такой же
                // (либо стек пустой) 
                if (_colorHistory.Count == 0 || _colorHistory.Peek() != value)
                {
                    _colorHistory.Push(value);
                }
                // Dock - это имя (x:Name) контейнера компоновки, для которого меняем цвет
                Dock.Background = _currentColor;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            // Устанавливаем начальный цвет
            CurrentColor = new SolidColorBrush(Colors.White);
        }

        private void ChangeColorExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var random = new Random();
            // CurrentColor - это свойство для хранения текущего цвета
            CurrentColor = new SolidColorBrush(Color.FromRgb(
                (byte)random.Next(256),
                (byte)random.Next(256),
                (byte)random.Next(256)));
        }

        private void UndoExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (_colorHistory.Count > 1)
            {
                _colorHistory.Pop(); // Удаляем текущий цвет
                CurrentColor = _colorHistory.Peek(); // Берём предыдущий (не Pop, чтобы не удалять)
            }
        }

        private void UndoCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Доступна, когда есть что отменять, т.е. _colorHistory не пуст и больше 1 элемента
            e.CanExecute = _colorHistory.Count > 1;
        }
    }
}
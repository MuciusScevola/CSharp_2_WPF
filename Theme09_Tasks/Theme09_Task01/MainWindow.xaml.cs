using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Theme09_Task01
{
    public partial class MainWindow : Window
    {
        // Коллекция для хранения последовательности цветов.
        private Stack<Brush> _colorHistory = new Stack<Brush>();

        private Brush _currentColor = new SolidColorBrush(Colors.White);

        // Текущий цвет.
        public Brush CurrentColor
        {
            get => _currentColor;
            set
            {
                _currentColor = value;

                if (_colorHistory.Count == 0 || _colorHistory.Peek() != value)
                {
                    _colorHistory.Push(value);
                }
                Dock.Background = _currentColor;

                // Для отладки - просмотр истории.
                Debug.WriteLine("История цветов:");
                var historyList = new List<Brush>(_colorHistory);
                historyList.Reverse();

                Debug.WriteLine($"  Начальный цвет: {historyList[0]}");
                for (int i = 1; i < historyList.Count; i++)
                {
                    Debug.WriteLine($"  Нажатие {i}: {historyList[i]}");
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            // Установка начального цвета.
            CurrentColor = new SolidColorBrush(Colors.White);
        }

        private void ChangeColorExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var random = new Random();
            CurrentColor = new SolidColorBrush(Color.FromRgb(
                (byte)random.Next(256),
                (byte)random.Next(256),
                (byte)random.Next(256)));
        }

        private void UndoExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (_colorHistory.Count > 1)
            {
                _colorHistory.Pop();
                CurrentColor = _colorHistory.Peek(); // Берётся предыдущий (не Pop, чтобы не удалять).
            }
        }

        private void UndoCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _colorHistory.Count > 1;
        }
    }
}
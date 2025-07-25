﻿using Microsoft.Win32;
using System.Data;
using System.IO;
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

namespace Theme02_Task01
{
    public partial class MainWindow : Window
    {
        private string? currentFilePath = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        // Обработчик кнопки "Открыть".
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    TextEditorBox.Text = File.ReadAllText(openFileDialog.FileName);
                    currentFilePath = openFileDialog.FileName;
                    StatusText.Text = $"Открыт файл: {currentFilePath}";
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Ошибка при открытии файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    StatusText.Text = "Ошибка";
                }
            }
        }

        // Обработчик кнопки "Сохранить как".
        private void SaveAsButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            saveFileDialog.DefaultExt = ".txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, TextEditorBox.Text);
                    currentFilePath = saveFileDialog.FileName;
                    StatusText.Text = $"Файл сохранён: {currentFilePath}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Непредвиденная ошибка: {ex.Message}", "Критическая ошибка",
                          MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Обработчик кнопки "О программе".
        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            var aboutWindow = new AboutWindow();

            aboutWindow.Resources.MergedDictionaries.Add(this.Resources);

            aboutWindow.Owner = this;
            aboutWindow.ShowDialog();
        }

        // Обработчик события закрытия окна - запрос подтверждения.
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
            "Вы уверены, что хотите выйти? Все несохранённые изменения будут потеряны.",
            "Подтверждение выхода.",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }
    }
}
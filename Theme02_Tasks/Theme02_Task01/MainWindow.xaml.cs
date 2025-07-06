using Microsoft.Win32;
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
        private string currentFilePath = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }
        // Обработчик кнопки "Открыть"
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
                Title = "Открыть файл"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Чтение содержимого файла
                    TextEditor.Text = File.ReadAllText(openFileDialog.FileName);
                    currentFilePath = openFileDialog.FileName;
                    StatusText.Text = $"Открыт файл: {currentFilePath}";
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Ошибка при открытии файла: {ex.Message}", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Обработчик кнопки "Сохранить как"
        private void SaveAsButton_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
                Title = "Сохранить файл",
                DefaultExt = ".txt"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Сохранение текста в файл
                    File.WriteAllText(saveFileDialog.FileName, TextEditor.Text);
                    currentFilePath = saveFileDialog.FileName;
                    StatusText.Text = $"Файл сохранён: {currentFilePath}";
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Обработчик кнопки "О программе"
        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            var aboutWindow = new AboutWindow();
            aboutWindow.Owner = this;
            aboutWindow.ShowDialog();
        }

        // Обработчик события закрытия окна (подтверждение выхода)
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextEditor.Text))
            {
                var result = MessageBox.Show("Вы хотите сохранить изменения перед выходом?", "Подтверждение",
                    MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    SaveAsButton_Click(sender, null);
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    e.Cancel = true; // Отмена закрытия окна
                }
            }
        }
    }
}
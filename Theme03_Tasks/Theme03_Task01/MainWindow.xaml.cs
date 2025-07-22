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

namespace Theme03_Task01
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Явное указание, что факультет не выбран при запуске.
            Faculty_ComboBox.SelectedIndex = -1;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка обязательных полей.
            if (!ValidateInputs())
                return;

            var studentName = $"{FirstName_TextBox.Text.Trim()} {StudentName_TextBox.Text.Trim()}";
            var faculty = ((ComboBoxItem)Faculty_ComboBox.SelectedItem).Content.ToString();
            var selectedCourses = GetSelectedCourses();
            var hoursWeek = Hours_Slider.Value;
            var studyForm = FullTime_RadioButton.IsChecked == true ? "Очно" : "Заочно";

            // Вывод результата.
            MessageBox.Show(
                $"Студент: {studentName}\n" +
                $"Факультет: {faculty}\n" +
                $"Курсы: {selectedCourses}\n" + 
                $"Количество часов: {hoursWeek}\n" +
                $"Форма обучения: {studyForm}",
                "Регистрация завершена",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private bool ValidateInputs()
        {
            // Проверка имени и фамилии.
            if (string.IsNullOrWhiteSpace(FirstName_TextBox.Text))
            {
                ShowError("Введите имя.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(StudentName_TextBox.Text))
            {
                ShowError("Введите фамилию.");
                return false;
            }

            // Проверка выбора факультета.
            if (Faculty_ComboBox.SelectedIndex == -1)
            {
                ShowError("Выберите факультет.");
                return false;
            }

            // Проверка согласия.
            if (AgreementCheck.IsChecked != true)
            {
                ShowError("Необходимо дать согласие на обработку персональных данных.");
                return false;
            }

            return true;
        }
        private string GetSelectedCourses()
        {
            return string.Join(", ",
                Courses_ListBox.SelectedItems
                    .Cast<ListBoxItem>()
                    .Select(item => item.Content.ToString()));
        }
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }
    }
}
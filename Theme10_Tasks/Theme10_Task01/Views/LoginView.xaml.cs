using System.Windows;
using Theme10_Task01.ViewModels;

namespace Theme10_Task01.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
    }
}

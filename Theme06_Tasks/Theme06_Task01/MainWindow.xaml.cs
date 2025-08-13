using System.Windows;
using TextAnalyzer;

namespace Theme06_Task01
{
   public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
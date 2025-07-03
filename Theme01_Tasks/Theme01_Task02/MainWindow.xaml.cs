using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Theme01_Task02
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // Начало работы светофора - все света выключены (Gray).
        private void NextLight_Click(object sender, RoutedEventArgs e)
        {
            if (LightRed.Fill == Brushes.Red)
            {
                LightRed.Fill = Brushes.Gray;
                LightYellow.Fill = Brushes.Yellow;
            }
            else if (LightYellow.Fill == Brushes.Yellow)
            {
                LightYellow.Fill = Brushes.Gray;
                LightGreen.Fill = Brushes.Green;
            }
            else
            {
                LightGreen.Fill = Brushes.Gray;
                LightRed.Fill = Brushes.Red;
            }
        }
    }
}

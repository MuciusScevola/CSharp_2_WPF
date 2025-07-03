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

namespace Theme01_Task03
{
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RunningButton_MouseEnter(object sender, MouseEventArgs e)
        {
            double gridHeight = CatchMeGrid.ActualHeight;
            double gridWidth = CatchMeGrid.ActualWidth;
            double buttonHeight = RunningButton.Height;
            double buttonWidth = RunningButton.Width;

            if (gridHeight > buttonHeight && gridWidth > buttonWidth)
            {
                double newLeft = random.NextDouble() * (gridWidth - buttonWidth) + 5;
                double newTop = random.NextDouble() * (gridHeight - buttonHeight) + 5;

                RunningButton.Margin = new Thickness(newLeft, newTop, 0, 0);
            }
        }
    }
}
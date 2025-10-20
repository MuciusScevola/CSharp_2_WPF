using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Theme11_Task01
{
    public partial class CircularProgressBar : UserControl
    {
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(double),
                typeof(CircularProgressBar),
                new PropertyMetadata(0.0, OnValueChanged));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register(
                nameof(Maximum),
                typeof(double),
                typeof(CircularProgressBar),
                new PropertyMetadata(100.0, OnValueChanged));

        public static readonly DependencyProperty ProgressAngleProperty =
            DependencyProperty.Register(
                nameof(ProgressAngle),
                typeof(double),
                typeof(CircularProgressBar),
                new PropertyMetadata(0.0));

        public static readonly DependencyProperty PercentageTextProperty =
            DependencyProperty.Register(
                nameof(PercentageText),
                typeof(string),
                typeof(CircularProgressBar),
                new PropertyMetadata("0%"));
        public double ProgressAngle
        {
            get => (double)GetValue(ProgressAngleProperty);
            set => SetValue(ProgressAngleProperty, value);
        }

        public string PercentageText
        {
            get => (string)GetValue(PercentageTextProperty);
            set => SetValue(PercentageTextProperty, value);
        }

        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public double Maximum
        {
            get => (double)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }
        public CircularProgressBar()
        {
            InitializeComponent();
            UpdateProgress();
        }
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var progressBar = (CircularProgressBar)d;
            progressBar.UpdateProgress();
        }
        private void UpdateProgress()
        {
            // Граничные значения.
            if (Value < 0) Value = 0;
            if (Value > Maximum) Value = Maximum;
            if (Maximum <= 0) Maximum = 100;

            // Вычисление прогресса.
            double percentage = Maximum == 0 ? 0 : (Value / Maximum);
            double angle = 360 * percentage;
            ProgressAngle = angle;
            PercentageText = $"{(percentage * 100):F0}%";

            // Обновление пути дуги.
            UpdateArcPath(angle);
        }
        private void UpdateArcPath(double angle)
        {
            if (angle <= 0)
            {
                ProgressPath.Data = null;
                return;
            }

            var pathGeometry = new PathGeometry();
            var pathFigure = new PathFigure();

            double centerX = 50;
            double centerY = 50;
            double radius = 45;

            // Начальная точка (верхняя точка окружности).
            Point startPoint = new Point(centerX, centerY - radius);
            pathFigure.StartPoint = startPoint;

            if (angle == 360)
            {
                // Если угол в 360° — полная окружность.
                var circle = new EllipseGeometry(new Point(centerX, centerY), radius, radius);
                pathFigure.IsClosed = true;
                pathGeometry.AddGeometry(circle);
            }
            else
            {
                // Если угол менее 360° — дуга.
                double endAngleRad = (angle - 90) * Math.PI / 180.0;
                Point endPoint = new Point(
                    centerX + radius * Math.Cos(endAngleRad),
                    centerY + radius * Math.Sin(endAngleRad)
                );

                var arcSegment = new ArcSegment(
                    endPoint,
                    new Size(radius, radius),
                    0,
                    angle > 180,
                    SweepDirection.Clockwise,
                    true
                );

                pathFigure.Segments.Add(arcSegment);
            }

            pathGeometry.Figures.Add(pathFigure);
            ProgressPath.Data = pathGeometry;
        }

    }
}

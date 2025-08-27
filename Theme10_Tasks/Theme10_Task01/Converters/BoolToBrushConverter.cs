using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Theme10_Task01.Converters
{
    public class BoolToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isSuccess = (bool)value;
            return isSuccess ? Brushes.Green : Brushes.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
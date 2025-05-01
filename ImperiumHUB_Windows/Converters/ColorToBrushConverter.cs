using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ImperiumGearHUB.Converters
{
    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if (value is Color color)
                return new SolidColorBrush(color);

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if (value is SolidColorBrush brush)
                return brush.Color;

            return null;
        }
    }
}
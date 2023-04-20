using System;
using System.Windows.Data;
using System.Windows.Media;

namespace TestApp_VSM
{
    public class SolidColorBrushToColorConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            if (value is SolidColorBrush b)
            {
                return Color.FromArgb(b.Color.A, b.Color.R, b.Color.G, b.Color.B);
            }

            Type type = value.GetType();
            throw new InvalidOperationException("Unsupported type [" + type.Name + "]");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

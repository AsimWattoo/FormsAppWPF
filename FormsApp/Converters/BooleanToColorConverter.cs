using System;
using System.Globalization;
using System.Windows.Media;

namespace FormsApp.Converters
{
    public class BooleanToColorConverter : BaseConverter<BooleanToColorConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is bool b)
            {
                return b ? (SolidColorBrush)new BrushConverter().ConvertFromString($"#{parameter}") : new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            return new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

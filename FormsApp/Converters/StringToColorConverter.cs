using System;
using System.Globalization;
using System.Windows.Media;

namespace FormsApp.Converters
{
    public class StringToColorConverter : BaseConverter<StringToColorConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string str)
            {
                return (SolidColorBrush)new BrushConverter().ConvertFrom(str);
            }
            return Brushes.Black;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Globalization;
using System.Windows;

namespace FormsApp.Converters
{
    public class BooleanInvertBorderThickness : BaseConverter<BooleanInvertBorderThickness>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is bool b)
            {
                return b ? new Thickness(0) : new Thickness(1);
            }
            return new Thickness(1);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

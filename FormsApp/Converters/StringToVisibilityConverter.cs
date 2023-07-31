using System;
using System.Globalization;
using System.Windows;

namespace FormsApp.Converters
{
    public class StringToVisibilityConverter : BaseConverter<StringToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string str)
            {
                if (parameter == null)
                    return string.IsNullOrEmpty(str) ? Visibility.Visible : Visibility.Collapsed;
                else
                    return string.IsNullOrEmpty(str) ? Visibility.Collapsed : Visibility.Visible;
            }
            return Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

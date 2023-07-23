using System;
using System.Globalization;
using System.Windows;

namespace FormsApp.Converters
{
    public class BooleanToBorderValueConverter : BaseConverter<BooleanToBorderValueConverter>
    {
        /// <summary>
        /// Converts the boolean value to thickness
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is bool b)
            {
                return b ? new Thickness(3, 0, 0, 0) : new Thickness(0);
            }
            return new Thickness(0);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

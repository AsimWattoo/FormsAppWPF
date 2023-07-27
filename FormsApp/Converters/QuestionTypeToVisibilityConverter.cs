using FormsApp.Core.Enums;

using System;
using System.Globalization;
using System.Windows;

namespace FormsApp.Converters
{
    public class QuestionTypeToVisibilityConverter : BaseConverter<QuestionTypeToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Checking if both of the parameters are string
            if(value is QuestionType type && parameter is string val)
            {
                //Parsing both of the item
                QuestionType valueType;
                if(Enum.TryParse(val, out valueType))
                {
                    return type == valueType ? Visibility.Visible : Visibility.Collapsed;
                }
            }
            return Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

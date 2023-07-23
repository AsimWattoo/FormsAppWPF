using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace FormsApp.Converters
{
    public abstract class BaseConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Private Members

        /// <summary>
        /// The actual provider to be returned
        /// </summary>
        private static T Provider = new T();

        #endregion

        #region Public Methods

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Provider == null)
                Provider = new T();

            return Provider;
        }

        #endregion
    }
}

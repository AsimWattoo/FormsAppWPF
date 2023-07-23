using System;
using System.Windows;

namespace FormsApp.AttachedProperties.Base
{
    public class BaseAttachedProperty<Parent, Property>
        where Parent : class, new()
    {

        #region Public Members

        public static Parent Instance { get; set; } = new Parent();

        #endregion

        #region Dependency Property

        /// <summary>
        /// Sets the value of the dependency property
        /// </summary>
        /// <param name="d"></param>
        /// <param name="value"></param>
        public static void SetValue(DependencyObject d, Property value)
        {
            d.SetValue(ValueProperty, value);
        }

        /// <summary>
        /// Gets the value of dependency property from the 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d)
        {
            return (Property)d.GetValue(ValueProperty);
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttachedProperty<Parent, Property>), new PropertyMetadata(default(Property), propertyValueChanged, new CoerceValueCallback(propertyValueUpdated)));

        /// <summary>
        /// Fires when the property value updated
        /// </summary>
        /// <param name="d"></param>
        /// <param name="baseValue"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static object propertyValueUpdated(DependencyObject d, object baseValue)
        {
            (Instance as BaseAttachedProperty<Parent, Property>).OnPropertyValueUpdated(d, baseValue);
            return baseValue;
        }

        /// <summary>
        /// Fires when property value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void propertyValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (Instance as BaseAttachedProperty<Parent, Property>).OnPropertyValueChanged(d, e);
        }

        #endregion

        #region Overrideable Methods

        public virtual void OnPropertyValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public virtual void OnPropertyValueUpdated(DependencyObject d, object value) { }

        #endregion

    }
}

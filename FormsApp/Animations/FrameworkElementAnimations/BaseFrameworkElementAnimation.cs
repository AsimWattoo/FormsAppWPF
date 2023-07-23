using FormsApp.AttachedProperties.Base;

using System.Collections.Generic;
using System.Windows;

namespace FormsApp.Animations.FrameworkElementAnimations
{
    public class BaseFrameworkElementAnimation<Parent> : BaseAttachedProperty<Parent, bool>
        where Parent : class, new()
    {
        #region Private Members

        /// <summary>
        /// The values of first load for each elemenet
        /// </summary>
        private Dictionary<FrameworkElement, bool> FirstLoadValues { get; set; } = new Dictionary<FrameworkElement, bool>();

        /// <summary>
        /// Thr previous value of the control
        /// </summary>
        private Dictionary<FrameworkElement, bool> PreviousValues { get; set; } = new Dictionary<FrameworkElement, bool>();

        #endregion


        /// <summary>
        /// Fires when property value changes
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        public override void OnPropertyValueUpdated(DependencyObject d, object value)
        {
            FrameworkElement element = d as FrameworkElement;

            if (element == null)
                return;

            if (!FirstLoadValues.ContainsKey(element))
                FirstLoadValues.Add(element, true);

            //If this is the first time then add key and continue
            if (!PreviousValues.ContainsKey(element))
                PreviousValues.Add(element, (bool)value);
            //For next time check value and then continue
            else if (PreviousValues.ContainsKey(element))
            {
                if (PreviousValues[element] == (bool)value)
                    return;
            }

            PreviousValues[element] = (bool)value;
            bool firstLoad = FirstLoadValues[element];

            if (firstLoad)
            {
                //If it is the first load then make element invisible
                element.Visibility = Visibility.Collapsed;
                //Animating the element
                DoAnimationOnUpdate(element, (bool)value, firstLoad);

                FirstLoadValues[element] = false;
            }
            else
            {
                DoAnimationOnUpdate(element, (bool)value, firstLoad);
            }
        }

        /// <summary>
        /// Performs animation
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        protected virtual async void DoAnimationOnUpdate(FrameworkElement element, bool value, bool FirstLoad)
        {
            //Do animation
        }
    }
}

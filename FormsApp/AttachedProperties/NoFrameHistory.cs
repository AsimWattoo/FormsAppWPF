using FormsApp.AttachedProperties.Base;

using System.Windows;
using System.Windows.Controls;

namespace FormsApp.Attached_Properties
{
    public class NoFrameHistory : BaseAttachedProperty<NoFrameHistory, bool>
    {

        public override void OnPropertyValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool val = GetValue(d);
            if (val)
            {
                Frame frame = d as Frame;

                if (frame == null)
                    return;
                frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
                frame.Navigated += (sender, er) => { frame.NavigationService.RemoveBackEntry(); };

            }
        }
    }
}

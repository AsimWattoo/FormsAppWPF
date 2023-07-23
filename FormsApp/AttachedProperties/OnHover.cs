using FormsApp.AttachedProperties.Base;

using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace FormsApp.Attached_Properties
{
    public class HoverAnimationDuration : BaseAttachedProperty<HoverAnimationDuration, double> { }

    public class OnMouseEnter : BaseAttachedProperty<OnMouseEnter, Color>
    {
        public override void OnPropertyValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement FrameworkElement = d as FrameworkElement;

            if (FrameworkElement != null)
            {
                FrameworkElement.MouseEnter -= FrameworkElement_MouseEnter;
                FrameworkElement.MouseEnter += FrameworkElement_MouseEnter;
            }

        }

        private void FrameworkElement_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            FrameworkElement FrameworkElement = null;
            Shape s = null;
            bool isShape = false;
            DependencyObject dependencyObject = sender as DependencyObject;
            DependencyObject dp = dependencyObject.GetValue(OnHoverAnimationElement.ValueProperty) as DependencyObject;


            //Checking if the framework element property has been attached or not
            if (dp != null)
            {
                if (dp is Shape)
                {
                    isShape = true;
                    s = dp as Shape;
                }
                else
                    FrameworkElement = dp as FrameworkElement;
            }
            else
                FrameworkElement = sender as FrameworkElement;

            if ((FrameworkElement != null && FrameworkElement.IsEnabled) || (isShape && s != null && s.IsEnabled))
            {
                Storyboard storyboard = new Storyboard();
                //Getting the duration for animation
                double seconds = (double)(sender as DependencyObject).GetValue(HoverAnimationDuration.ValueProperty);

                //Checking if seconds == 0
                seconds = seconds == 0 ? 0.1 : seconds;

                //Creating Animation
                ColorAnimation animation = new ColorAnimation()
                {
                    To = GetValue(sender as DependencyObject),
                    Duration = new Duration(TimeSpan.FromSeconds(seconds))
                };
                if (isShape)
                    Storyboard.SetTargetProperty(animation, new PropertyPath("Fill.Color"));
                else
                    Storyboard.SetTargetProperty(animation, new PropertyPath("Background.Color"));
                //Adding animation as child to storyboard
                storyboard.Children.Add(animation);
                //Starting the animation
                if (isShape)
                    storyboard.Begin(s);
                else
                    storyboard.Begin(FrameworkElement);
            }
        }
    }

    public class OnMouseLeave : BaseAttachedProperty<OnMouseLeave, Color>
    {
        public override void OnPropertyValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement FrameworkElement = d as FrameworkElement;

            if (FrameworkElement != null)
            {
                FrameworkElement.MouseLeave -= FrameworkElement_MouseLeave;

                FrameworkElement.MouseLeave += FrameworkElement_MouseLeave;
            }

        }

        private void FrameworkElement_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            FrameworkElement FrameworkElement = null;
            Shape s = null;
            bool isShape = false;
            DependencyObject dependencyObject = sender as DependencyObject;
            DependencyObject dp = dependencyObject.GetValue(OnHoverAnimationElement.ValueProperty) as DependencyObject;


            //Checking if the framework element property has been attached or not
            if (dp != null)
            {
                if (dp is Shape)
                {
                    isShape = true;
                    s = dp as Shape;
                }
                else
                    FrameworkElement = dp as FrameworkElement;
            }
            else
                FrameworkElement = sender as FrameworkElement;


            if ((FrameworkElement != null && FrameworkElement.IsEnabled) || (isShape && s != null && s.IsEnabled))
            {
                Storyboard storyboard = new Storyboard();

                //Getting the duration for animation
                double seconds = (double)(sender as DependencyObject).GetValue(HoverAnimationDuration.ValueProperty);

                //Checking if seconds == 0
                seconds = seconds == 0 ? 0.1 : seconds;

                //Creating Animation
                ColorAnimation animation = new ColorAnimation()
                {
                    To = GetValue(sender as DependencyObject),
                    Duration = new Duration(TimeSpan.FromSeconds(seconds))
                };

                if (isShape)
                    Storyboard.SetTargetProperty(animation, new PropertyPath("Fill.Color"));
                else
                    Storyboard.SetTargetProperty(animation, new PropertyPath("Background.Color"));
                //Adding animation as child to storyboard
                storyboard.Children.Add(animation);
                //Starting the animation
                if (isShape)
                    storyboard.Begin(s);
                else
                    storyboard.Begin(FrameworkElement);
            }
        }
    }

    public class OnMouseEnterForeground : BaseAttachedProperty<OnMouseEnterForeground, Color>
    {
        public override void OnPropertyValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement FrameworkElement = d as FrameworkElement;

            if (FrameworkElement != null)
            {
                FrameworkElement.MouseEnter -= FrameworkElement_MouseEnter;
                FrameworkElement.MouseEnter += FrameworkElement_MouseEnter;
            }

        }

        private void FrameworkElement_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            FrameworkElement FrameworkElement = sender as FrameworkElement;
            Storyboard storyboard = new Storyboard();
            //Getting the duration for animation
            double seconds = (double)(sender as DependencyObject).GetValue(HoverAnimationDuration.ValueProperty);

            //Checking if seconds == 0
            seconds = seconds == 0 ? 0.1 : seconds;

            //Creating Animation
            ColorAnimation animation = new ColorAnimation()
            {
                To = GetValue(sender as DependencyObject),
                Duration = new Duration(TimeSpan.FromSeconds(seconds))
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Foreground.Color"));
            //Adding animation as child to storyboard
            storyboard.Children.Add(animation);
            //Starting the animation
            storyboard.Begin(FrameworkElement);
        }
    }

    public class OnMouseLeaveForeground : BaseAttachedProperty<OnMouseLeaveForeground, Color>
    {
        public override void OnPropertyValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement FrameworkElement = d as FrameworkElement;

            if (FrameworkElement != null)
            {
                FrameworkElement.MouseLeave -= FrameworkElement_MouseLeave;

                FrameworkElement.MouseLeave += FrameworkElement_MouseLeave;
            }

        }

        private void FrameworkElement_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            FrameworkElement FrameworkElement = sender as FrameworkElement;
            Storyboard storyboard = new Storyboard();

            //Getting the duration for animation
            double seconds = (double)(sender as DependencyObject).GetValue(HoverAnimationDuration.ValueProperty);

            //Checking if seconds == 0
            seconds = seconds == 0 ? 0.1 : seconds;

            //Creating Animation
            ColorAnimation animation = new ColorAnimation()
            {
                To = GetValue(sender as DependencyObject),
                Duration = new Duration(TimeSpan.FromSeconds(seconds))
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Foreground.Color"));
            //Adding animation as child to storyboard
            storyboard.Children.Add(animation);
            //Starting the animation
            storyboard.Begin(FrameworkElement);
        }
    }

    public class OnMouseEnterBorder : BaseAttachedProperty<OnMouseEnterBorder, Color>
    {
        public override void OnPropertyValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement FrameworkElement = d as FrameworkElement;

            if (FrameworkElement != null)
            {
                FrameworkElement.MouseEnter -= FrameworkElement_MouseEnter;
                FrameworkElement.MouseEnter += FrameworkElement_MouseEnter;
            }

        }

        private void FrameworkElement_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            FrameworkElement FrameworkElement = sender as FrameworkElement;
            Storyboard storyboard = new Storyboard();
            //Getting the duration for animation
            double seconds = (double)(sender as DependencyObject).GetValue(HoverAnimationDuration.ValueProperty);

            //Checking if seconds == 0
            seconds = seconds == 0 ? 0.1 : seconds;

            //Creating Animation
            ColorAnimation animation = new ColorAnimation()
            {
                To = GetValue(sender as DependencyObject),
                Duration = new Duration(TimeSpan.FromSeconds(seconds))
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("BorderBrush"));
            //Adding animation as child to storyboard
            storyboard.Children.Add(animation);
            //Starting the animation
            storyboard.Begin(FrameworkElement);
        }
    }

    public class OnMouseLeaveBorder : BaseAttachedProperty<OnMouseLeaveForeground, Color>
    {
        public override void OnPropertyValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement FrameworkElement = d as FrameworkElement;

            if (FrameworkElement != null)
            {
                FrameworkElement.MouseLeave -= FrameworkElement_MouseLeave;

                FrameworkElement.MouseLeave += FrameworkElement_MouseLeave;
            }

        }

        private void FrameworkElement_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            FrameworkElement FrameworkElement = sender as FrameworkElement;
            Storyboard storyboard = new Storyboard();

            //Getting the duration for animation
            double seconds = (double)(sender as DependencyObject).GetValue(HoverAnimationDuration.ValueProperty);

            //Checking if seconds == 0
            seconds = seconds == 0 ? 0.1 : seconds;

            //Creating Animation
            ColorAnimation animation = new ColorAnimation()
            {
                To = GetValue(sender as DependencyObject),
                Duration = new Duration(TimeSpan.FromSeconds(seconds))
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("BorderBrush"));
            //Adding animation as child to storyboard
            storyboard.Children.Add(animation);
            //Starting the animation
            storyboard.Begin(FrameworkElement);
        }
    }

    /// <summary>
    /// Contains element for applying hover animation
    /// </summary>
    public class OnHoverAnimationElement : BaseAttachedProperty<OnHoverAnimationElement, DependencyObject>
    {

    }

    public class OnMouseEnterShape : BaseAttachedProperty<OnMouseEnterShape, Color>
    {
        public override void OnPropertyValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Shape shape = d as Shape;

            if (shape != null)
            {
                shape.MouseEnter -= FrameworkElement_MouseEnter;
                shape.MouseEnter += FrameworkElement_MouseEnter;
            }

        }

        private void FrameworkElement_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Shape shape;
            DependencyObject dependencyObject = sender as DependencyObject;
            DependencyObject dp = dependencyObject.GetValue(OnHoverAnimationElement.ValueProperty) as DependencyObject;


            //Checking if the framework element property has been attached or not
            if (dp != null)
                shape = dp as Shape;
            else
                shape = sender as Shape;

            if (shape.IsEnabled)
            {
                Storyboard storyboard = new Storyboard();
                //Getting the duration for animation
                double seconds = (double)(sender as DependencyObject).GetValue(HoverAnimationDuration.ValueProperty);

                //Checking if seconds == 0
                seconds = seconds == 0 ? 0.1 : seconds;

                //Creating Animation
                ColorAnimation animation = new ColorAnimation()
                {
                    To = GetValue(sender as DependencyObject),
                    Duration = new Duration(TimeSpan.FromSeconds(seconds))
                };
                Storyboard.SetTargetProperty(animation, new PropertyPath("Fill.Color"));
                //Adding animation as child to storyboard
                storyboard.Children.Add(animation);
                //Starting the animation
                storyboard.Begin(shape);
            }
        }
    }

    public class OnMouseLeaveShape : BaseAttachedProperty<OnMouseLeaveShape, Color>
    {
        public override void OnPropertyValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Shape shape = d as Shape;

            if (shape != null)
            {
                shape.MouseLeave -= FrameworkElement_MouseLeave;

                shape.MouseLeave += FrameworkElement_MouseLeave;
            }

        }

        private void FrameworkElement_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Shape shape;
            DependencyObject dependencyObject = sender as DependencyObject;
            DependencyObject dp = dependencyObject.GetValue(OnHoverAnimationElement.ValueProperty) as DependencyObject;


            //Checking if the framework element property has been attached or not
            if (dp != null)
                shape = dp as Shape;
            else
                shape = sender as Shape;


            if (shape.IsEnabled)
            {
                Storyboard storyboard = new Storyboard();

                //Getting the duration for animation
                double seconds = (double)(sender as DependencyObject).GetValue(HoverAnimationDuration.ValueProperty);

                //Checking if seconds == 0
                seconds = seconds == 0 ? 0.1 : seconds;

                //Creating Animation
                ColorAnimation animation = new ColorAnimation()
                {
                    To = GetValue(sender as DependencyObject),
                    Duration = new Duration(TimeSpan.FromSeconds(seconds))
                };
                Storyboard.SetTargetProperty(animation, new PropertyPath("Fill.Color"));
                //Adding animation as child to storyboard
                storyboard.Children.Add(animation);
                //Starting the animation
                storyboard.Begin(shape);
            }
        }
    }

}

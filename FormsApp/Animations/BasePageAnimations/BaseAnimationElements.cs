using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace FormsApp.Animations.BasePageAnimations
{
    public static class BaseAnimationElements
    {

        #region Public Methods

        /// <summary>
        /// Adds a slide in from left animation to storyboard
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="seconds"> The duration for animation </param>
        public static void SlideInFromLeft(this Storyboard sb, double seconds, double offset)
        {
            ThicknessAnimation animation = new ThicknessAnimation()
            {
                From = new Thickness(-offset, 0, offset, 0),
                To = new Thickness(0),
                Duration = new Duration(TimeSpan.FromSeconds(seconds))
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            sb.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide in from top animation to storyboard
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="seconds"> The duration for animation </param>
        public static void SlideInFromTop(this Storyboard sb, double seconds, double offset)
        {
            ThicknessAnimation animation = new ThicknessAnimation()
            {
                From = new Thickness(0, -offset, 0, offset),
                To = new Thickness(0),
                Duration = new Duration(TimeSpan.FromSeconds(seconds))
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            sb.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide out to top animation storyboard
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="seconds"> The duration for animation </param>
        public static void SlideOutToTop(this Storyboard sb, double seconds, double offset)
        {
            ThicknessAnimation animation = new ThicknessAnimation()
            {
                From = new Thickness(0),
                To = new Thickness(0, -offset, 0, offset),
                Duration = new Duration(TimeSpan.FromSeconds(seconds))
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            sb.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide in from right animation to storyboard
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="seconds"> The duration for animation </param>
        public static void SlideInFromRight(this Storyboard sb, double seconds, double offset)
        {
            ThicknessAnimation animation = new ThicknessAnimation()
            {
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                Duration = new Duration(TimeSpan.FromSeconds(seconds))
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            sb.Children.Add(animation);
        }

        /// <summary>
        /// Adds fade in animation
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="seconds"> The duration for animation </param>
        public static void FadeIn(this Storyboard sb, double seconds, double from = 0, double to = 1)
        {
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = from,
                To = to,
                Duration = new Duration(TimeSpan.FromSeconds(seconds))
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            sb.Children.Add(animation);
        }

        /// <summary>
        /// Adds fade out animation
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="seconds"> The duration for animation </param>
        public static void FadeOut(this Storyboard sb, double seconds, double from = 1, double to = 0)
        {
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = from,
                To = to,
                Duration = new Duration(TimeSpan.FromSeconds(seconds))
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            sb.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide out to right animation to storyboard
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="seconds"> The duration for animation </param>
        public static void SlideOutToRight(this Storyboard sb, double seconds, double offset)
        {
            ThicknessAnimation animation = new ThicknessAnimation()
            {
                From = new Thickness(0),
                To = new Thickness(offset, 0, -offset, 0),
                Duration = new Duration(TimeSpan.FromSeconds(seconds))
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            sb.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide out to left animation to storyboard
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="seconds"> The duration for animation </param>
        public static void SlideOutToLeft(this Storyboard sb, double seconds, double offset)
        {
            ThicknessAnimation animation = new ThicknessAnimation()
            {
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                Duration = new Duration(TimeSpan.FromSeconds(seconds))
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            sb.Children.Add(animation);
        }

        /// <summary>
        /// Collapses an element
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="seconds"> The duration for animation </param>
        public static void Collapse(this Storyboard sb, double seconds, double startPoint, double offset)
        {
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = startPoint,
                To = offset,
                Duration = new Duration(TimeSpan.FromSeconds(seconds))
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Height"));
            sb.Children.Add(animation);
        }

        /// <summary>
        /// Expands an element
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="seconds"> The duration for animation </param>
        public static void Expand(this Storyboard sb, double seconds, double startPoint, double offset)
        {
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = startPoint,
                To = offset,
                Duration = new Duration(TimeSpan.FromSeconds(seconds))
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Height"));
            sb.Children.Add(animation);
        }

        #endregion

    }
}

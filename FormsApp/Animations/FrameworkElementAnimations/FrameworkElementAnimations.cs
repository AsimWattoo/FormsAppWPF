using FormsApp.Animations.BasePageAnimations;

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace FormsApp.Animations.FrameworkElementAnimations
{
    public static class FrameworkElementAnimations
    {
        /// <summary>
        /// Slides a framework element in from top
        /// </summary>
        /// <param name="element"></param>
        /// <param name="offset"></param>
        /// <param name="seconds"></param>
        /// <param name="collapseAfter"></param>
        /// <returns></returns>
        public static async Task SlideInFromTop(this FrameworkElement element, double offset, double seconds, bool collapseAfter = true)
        {
            Storyboard sb = new Storyboard();

            //Adding animations
            sb.SlideInFromTop(seconds, offset);
            //Starting animation
            sb.Begin(element);
            //Making element visible
            element.Visibility = Visibility.Visible;
            //Waiting for the animation to complete
            await Task.Delay((int)(1000 * seconds));
        }

        /// <summary>
        /// Slides a framework element in from left
        /// </summary>
        /// <param name="element"></param>
        /// <param name="offset"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideInFromRight(this FrameworkElement element, double offset, double seconds)
        {
            Storyboard sb = new Storyboard();

            //Adding animations
            sb.SlideInFromRight(seconds, offset);
            //Starting animation
            sb.Begin(element);
            //Making element visible
            element.Visibility = Visibility.Visible;
            //Waiting for the animation to complete
            await Task.Delay((int)(1000 * seconds));
        }

        /// <summary>
        /// Slides a framework element out to top
        /// </summary>
        /// <param name="element"></param>
        /// <param name="offset"></param>
        /// <param name="seconds"></param>
        /// <param name="collapseAfter"></param>
        /// <returns></returns>
        public static async Task SlideOutToTop(this FrameworkElement element, double offset, double seconds, bool collapseAfter = true)
        {
            Storyboard sb = new Storyboard();

            //Adding animations
            sb.SlideOutToTop(seconds, offset);
            //Starting animation
            sb.Begin(element);
            //Waiting for the animation to complete
            await Task.Delay((int)(1000 * seconds));
            if (collapseAfter)
                element.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Slides a framework element out to top
        /// </summary>
        /// <param name="element"></param>
        /// <param name="offset"></param>
        /// <param name="seconds"></param>
        /// <param name="collapseAfter"></param>
        /// <returns></returns>
        public static async Task SlideOutToLeft(this FrameworkElement element, double offset, double seconds, bool collapseAfter = true)
        {
            Storyboard sb = new Storyboard();

            //Adding animations
            sb.SlideOutToLeft(seconds, offset);
            //Starting animation
            sb.Begin(element);
            //Waiting for the animation to complete
            await Task.Delay((int)(1000 * seconds));
            if (collapseAfter)
                element.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Animates a framework element to the left and fades it out
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this FrameworkElement element, double offset, double seconds, bool collapseAfter = true)
        {
            Storyboard sb = new Storyboard();

            //Adding animations
            sb.SlideOutToLeft(seconds, offset);
            sb.FadeOut(seconds);

            //Starting the animation
            sb.Begin(element);

            //Waiting for animation to complete
            await Task.Delay((int)(seconds * 1000));

            if (collapseAfter)
                //Making Element Collapsed
                element.Visibility = Visibility.Collapsed;

        }

        /// <summary>
        /// Animates a framework element in from left and fades it in
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeft(this FrameworkElement element, double offset, double seconds)
        {
            Storyboard sb = new Storyboard();

            //Adding animations
            sb.SlideInFromLeft(seconds, offset);
            sb.FadeIn(seconds);

            //Starting the animation
            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            //Waiting for animation to complete
            await Task.Delay((int)(seconds * 1000));

        }

        /// <summary>
        /// Animates a framework element in from right and fades it in
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this FrameworkElement element, double offset, double seconds)
        {
            Storyboard sb = new Storyboard();

            //Adding animations
            sb.SlideInFromRight(seconds, offset);
            sb.FadeIn(seconds);

            element.Visibility = Visibility.Visible;

            //Starting the animation
            sb.Begin(element);

            //Waiting for animation to complete
            await Task.Delay((int)(seconds * 1000));

        }

        /// <summary>
        /// Collapses an element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task Collapse(this FrameworkElement element, double startPoint, double offset, double seconds)
        {
            Storyboard sb = new Storyboard();

            //Adding animations
            sb.Collapse(seconds, startPoint, offset);

            //Starting the animation
            sb.Begin(element);

            //element.Visibility = Visibility.Visible;

            //Waiting for animation to complete
            await Task.Delay((int)(seconds * 1000));

            //element.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Expands an element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task Expand(this FrameworkElement element, double startPoint, double offset, double seconds)
        {
            Storyboard sb = new Storyboard();

            //Adding animations
            sb.Expand(seconds, startPoint, offset);

            //Starting the animation
            sb.Begin(element);

            //element.Visibility = Visibility.Visible;

            //Waiting for animation to complete
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Fades an element in
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task FadeIn(this FrameworkElement element, double seconds)
        {
            Storyboard sb = new Storyboard();

            //Adding animations
            sb.FadeIn(seconds);
            //starting the animations
            sb.Begin(element);
            //Making the element visible
            element.Visibility = Visibility.Visible;
            //Waiting for the animation to complete
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Fades an element in
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task FadeInValue(this FrameworkElement element, double seconds, double from, double to)
        {
            Storyboard sb = new Storyboard();

            //Adding animations
            sb.FadeIn(seconds, from, to);

            //starting the animations
            sb.Begin(element);
            //Making the element visible
            element.Visibility = Visibility.Visible;
            //Waiting for the animation to complete
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Fades an element out
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task FadeOut(this FrameworkElement element, double seconds)
        {
            Storyboard sb = new Storyboard();

            //Adding animations
            sb.FadeOut(seconds);
            //starting the animations
            sb.Begin(element);
            //Making the element visible
            element.Visibility = Visibility.Visible;
            //Waiting for the animation to complete
            await Task.Delay((int)(seconds * 1000));
            //Making the element invisible
            element.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Fades an element out
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task FadeOutValue(this FrameworkElement element, double seconds, double from, double to)
        {
            Storyboard sb = new Storyboard();

            //Adding animations
            sb.FadeOut(seconds, from, to);
            //starting the animations
            sb.Begin(element);
            //Making the element visible
            element.Visibility = Visibility.Visible;
            //Waiting for the animation to complete
            await Task.Delay((int)(seconds * 1000));
            //Making the element invisible
            element.Visibility = Visibility.Collapsed;
        }

    }
}

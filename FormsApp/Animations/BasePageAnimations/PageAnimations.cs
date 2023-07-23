using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace FormsApp.Animations.BasePageAnimations
{
    public static class PageAnimations
    {

        #region Public Methods

        /// <summary>
        /// Slides in a page from left
        /// </summary>
        /// <returns></returns>
        public static async Task SlideInFromLeft(this Page page, double seconds, double offset)
        {
            Storyboard sb = new Storyboard();

            //Adding Animations
            sb.SlideInFromLeft(seconds, offset);

            //Starting the animation
            sb.Begin(page);
            //Making the page visible
            page.Visibility = Visibility.Visible;
            //Waiting for this task to complete
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides in a page from right
        /// </summary>
        /// <returns></returns>
        public static async Task SlideInFromRight(this Page page, double seconds, double offset)
        {
            Storyboard sb = new Storyboard();

            //Adding Animations
            sb.SlideInFromRight(seconds, offset);

            //Starting the animation
            sb.Begin(page);
            //Making the page visible
            page.Visibility = Visibility.Visible;
            //Waiting for this task to complete
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides in a page out to right
        /// </summary>
        /// <returns></returns>
        public static async Task SlideOutToRight(this Page page, double seconds, double offset)
        {
            Storyboard sb = new Storyboard();

            //Adding Animations
            sb.SlideOutToRight(seconds, offset);

            //Starting the animation
            sb.Begin(page);
            //Making the page visible
            page.Visibility = Visibility.Visible;
            //Waiting for this task to complete
            await Task.Delay((int)(seconds * 1000));
            page.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Slides in a page out to left
        /// </summary>
        /// <returns></returns>
        public static async Task SlideOutToLeft(this Page page, double seconds, double offset)
        {
            Storyboard sb = new Storyboard();

            //Adding Animations
            sb.SlideOutToLeft(seconds, offset);

            //Starting the animation
            sb.Begin(page);
            //Making the page visible
            page.Visibility = Visibility.Visible;
            //Waiting for this task to complete
            await Task.Delay((int)(seconds * 1000));
            page.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Slides and fades in a page from left
        /// </summary>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeft(this Page page, double seconds, double offset)
        {
            Storyboard sb = new Storyboard();

            //Adding Animations
            sb.SlideInFromLeft(seconds, offset);
            sb.FadeIn(seconds);

            //Starting the animation
            sb.Begin(page);
            //Making the page visible
            page.Visibility = Visibility.Visible;
            //Waiting for this task to complete
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides and fades in a page from right
        /// </summary>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this Page page, double seconds, double offset)
        {
            Storyboard sb = new Storyboard();

            //Adding Animations
            sb.SlideInFromRight(seconds, offset);
            sb.FadeIn(seconds);

            //Starting the animation
            sb.Begin(page);
            //Making the page visible
            page.Visibility = Visibility.Visible;
            //Waiting for this task to complete
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides and fades out a page to right
        /// </summary>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToRight(this Page page, double seconds, double offset)
        {
            Storyboard sb = new Storyboard();

            //Adding Animations
            sb.SlideOutToRight(seconds, offset);
            sb.FadeOut(seconds);

            //Starting the animation
            sb.Begin(page);
            //Making the page visible
            page.Visibility = Visibility.Visible;
            //Waiting for this task to complete
            await Task.Delay((int)(seconds * 1000));
            page.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Slides and fades out a page to left
        /// </summary>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, double seconds, double offset)
        {
            Storyboard sb = new Storyboard();

            //Adding Animations
            sb.SlideOutToLeft(seconds, offset);
            sb.FadeOut(seconds);

            //Starting the animation
            sb.Begin(page);
            //Making the page visible
            page.Visibility = Visibility.Visible;
            //Waiting for this task to complete
            await Task.Delay((int)(seconds * 1000));
            page.Visibility = Visibility.Collapsed;
        }

        #endregion

    }
}

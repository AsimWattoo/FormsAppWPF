using FormsApp.Animations.BasePageAnimations;
using FormsApp.Core.View_Model.Base;

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FormsApp
{
    public class BasePage : Page
    {
        #region Public Properties

        /// <summary>
        /// The animation to use to load page
        /// </summary>
        public PageAnimation LoadInAnimation { get; set; } = PageAnimation.SlideInFromRight;

        /// <summary>
        /// The animation to use when animating the page out
        /// </summary>
        public PageAnimation LoadOutAnimation { get; set; } = PageAnimation.SlideOutToLeft;

        /// <summary>
        /// Tells whether the page should animate out or not
        /// </summary>
        public bool ShouldAnimateOut { get; set; } = false;

        /// <summary>
        /// The seconds to be used for animation
        /// </summary>
        public double Seconds { get; set; } = 0.7;

        /// <summary>
        /// The object which is used as view model
        /// </summary>
        public object ViewModelObject { get; set; }

        /// <summary>
        /// A delegate to get the window width
        /// </summary>
        public Func<double> GetWindowWidth { get; set; } = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor to intialize with view model
        /// </summary>
        public BasePage(bool defaultWindow = true)
        {
            if (LoadInAnimation != PageAnimation.None)
                this.Visibility = System.Windows.Visibility.Collapsed;
            this.Loaded += BasePage_Loaded;

            GetWindowWidth = () =>
            {
                if (Application.Current.MainWindow != null)
                    return Application.Current.MainWindow.Width;
                else
                    return 800;
            };

            Initialize();
        }

        #endregion

        #region Event Handlers

        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ShouldAnimateOut)
                await AnimatePage(LoadOutAnimation);
            else
                await AnimatePage(LoadInAnimation);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Animates the page
        /// </summary>
        /// <param name="animation"></param>
        private async Task AnimatePage(PageAnimation animation)
        {
            double windowWidth = 0;

            if (GetWindowWidth != null)
                windowWidth = GetWindowWidth();
            else
                windowWidth = this.WindowWidth;

            switch (animation)
            {
                case PageAnimation.SlideAndFadeInFromLeft:
                    await this.SlideAndFadeInFromLeft(Seconds, windowWidth);
                    break;
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(Seconds, windowWidth);
                    break;
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeft(Seconds, windowWidth);
                    break;
                case PageAnimation.SlideAndFadeOutToRight:
                    await this.SlideAndFadeOutToRight(Seconds, windowWidth);
                    break;
                case PageAnimation.FadeIn:
                    break;
                case PageAnimation.FadeOut:
                    break;
                case PageAnimation.SlideInFromLeft:
                    await this.SlideInFromLeft(Seconds, windowWidth);
                    break;
                case PageAnimation.SlideInFromRight:
                    await this.SlideInFromRight(Seconds, windowWidth);
                    break;
                case PageAnimation.SlideOutToRight:
                    await this.SlideOutToRight(Seconds, windowWidth);
                    break;
                case PageAnimation.SlideOutToLeft:
                    await this.SlideOutToLeft(Seconds, windowWidth);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Overridable Methods

        /// <summary>
        /// A method to initialize any important data if necessary
        /// </summary>
        protected virtual void Initialize() { }

        #endregion
    }

    public class BasePage<T> : BasePage
        where T : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The view model of the page
        /// </summary>
        public T ViewModel
        {
            get => (T)ViewModelObject;
            set
            {
                if (value != null && ViewModelObject != value)
                {
                    ViewModelObject = value;
                    this.DataContext = value;
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor to intialize with view model
        /// </summary>
        /// <param name="viewModel"></param>
        public BasePage(T viewModel)
        {
            ViewModel = viewModel;
        }

        #endregion
    }
}

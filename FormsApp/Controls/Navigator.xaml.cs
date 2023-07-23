using FormsApp.Converters;
using FormsApp.Core.Application;
using FormsApp.Core.IoCContainer;

using System.Windows;
using System.Windows.Controls;

namespace FormsApp.Controls
{
    /// <summary>
    /// Interaction logic for Navigator.xaml
    /// </summary>
    public partial class Navigator : Page
    {
        #region Constructor

        public Navigator()
        {
            InitializeComponent();
        }

        #endregion

        #region Dependency Property

        /// <summary>
        /// The current Page Property
        /// </summary>
        public ApplicationPages CurrentPage
        {
            get { return (ApplicationPages)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentPage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register("CurrentPage", typeof(ApplicationPages), typeof(Navigator), new PropertyMetadata(default(ApplicationPages), null, new CoerceValueCallback(propertyValueChanged)));

        /// <summary>
        /// Fires when property value is changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="baseValue"></param>
        /// <returns></returns>
        private static object propertyValueChanged(DependencyObject d, object baseValue)
        {
            //Getting the current page and current page viewmodel
            var currentPage = (ApplicationPages)baseValue;
            //Getting old and new frame
            var oldFrame = (d as Navigator).OldContentFrame;
            var newFrame = (d as Navigator).NewContentFrame;
            //getting the oldframe content
            var oldFrameContent = newFrame.Content;
            if (oldFrameContent is BasePage page &&
                 page.ToApplicationPage() == currentPage)
            {

                //If model for the page is not null then update it
                if (IoC.Get<ApplicationViewModel>().PageViewModel != null)
                {
                    page.ViewModelObject = IoC.Get<ApplicationViewModel>().PageViewModel;
                    page.DataContext = IoC.Get<ApplicationViewModel>().PageViewModel;
                }

                return baseValue;
            }
            //setting contents of the New frame to null
            newFrame.Content = null;
            //Setting up new frame content
            oldFrame.Content = oldFrameContent;
            //animate out the new frame
            if (oldFrameContent is BasePage basePage)
                basePage.ShouldAnimateOut = true;
            //setting up the content of the old frame
            newFrame.Content = currentPage.ToBasePage(IoC.Get<ApplicationViewModel>().PageViewModel);

            //returning the object
            return baseValue;
        }

        #endregion
    }
}

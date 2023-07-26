using FormsApp.Core.View_Model.Base;

namespace FormsApp.Core.Application
{
    public class ApplicationViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The current application page for the application
        /// </summary>
        public ApplicationPages CurrentPage { get; set; } = ApplicationPages.Questions;

        /// <summary>
        /// The view model for the page
        /// </summary>
        public BaseViewModel PageViewModel { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Changes the current page of the application
        /// </summary>
        /// <param name="newPage"></param>
        public void ChangePage(ApplicationPages newPage, BaseViewModel viewModel = null)
        {
            PageViewModel = viewModel;
            if(CurrentPage != newPage)
            {
                CurrentPage = newPage;
                PropertyValueChanged(nameof(CurrentPage));
            }
        }

        #endregion

    }
}

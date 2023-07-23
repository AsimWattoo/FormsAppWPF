using FormsApp.Core.Application;
using FormsApp.Core.IoCContainer;

namespace FormsApp
{
    public class ViewModelLocator
    {
        #region Public Properties

        /// <summary>
        /// The application model used for the application
        /// </summary>
        public static ApplicationViewModel Application => IoC.Get<ApplicationViewModel>();

        #endregion

    }
}

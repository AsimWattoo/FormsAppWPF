using FormsApp.Core.Application;
using FormsApp.Core.IoCContainer;

namespace FormsApp
{
    /// <summary>
    /// Interaction logic for QuestionAddEditForm.xaml
    /// </summary>
    public partial class QuestionAddEditForm : BasePage
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public QuestionAddEditForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Fires when the back button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            IoC.Get<ApplicationViewModel>().ChangePage(ApplicationPages.EditableQuestions);
        }

        #endregion
    }
}

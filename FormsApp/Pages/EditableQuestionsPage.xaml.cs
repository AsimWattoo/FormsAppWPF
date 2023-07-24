using FormsApp.Core.Application;
using FormsApp.Core.IoCContainer;
using FormsApp.Core.View_Model.PageViewModel;

namespace FormsApp
{
    /// <summary>
    /// Interaction logic for EditableQuestionsPage.xaml
    /// </summary>
    public partial class EditableQuestionsPage : BasePage<EditableQuestionsViewModel>
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public EditableQuestionsPage(EditableQuestionsViewModel vm) : base(vm)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public EditableQuestionsPage() : base(new EditableQuestionsViewModel())
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Fires when the add question button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            IoC.Get<ApplicationViewModel>().ChangePage(ApplicationPages.Add_Edit_Form);
        }

        #endregion

    }
}

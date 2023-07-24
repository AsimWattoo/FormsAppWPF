using FormsApp.Core.Application;
using FormsApp.Core.IoCContainer;
using FormsApp.Core.View_Model.PageViewModel;

using System.Windows.Controls;

namespace FormsApp
{
    /// <summary>
    /// Interaction logic for QuestionAddEditForm.xaml
    /// </summary>
    public partial class QuestionAddEditForm : BasePage<AddEditQuestionViewModel>
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public QuestionAddEditForm() : base(new AddEditQuestionViewModel())
        {
            InitializeComponent();
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        public QuestionAddEditForm(AddEditQuestionViewModel vm) : base(vm)
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

        /// <summary>
        /// Fires the option remove command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionRemoveBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(sender is Button btn)
            {
                this.ViewModel.RemoveOptionCommand.Execute(btn.CommandParameter);
            }
        }

        #endregion
    }
}

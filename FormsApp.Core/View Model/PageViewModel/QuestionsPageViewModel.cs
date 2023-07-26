using FormsApp.Core.Application;
using FormsApp.Core.IoCContainer;
using FormsApp.Core.Repos;
using FormsApp.Core.View_Model.Base;
using FormsApp.Core.View_Model.ControlViewModels;

using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace FormsApp.Core.View_Model.PageViewModel
{
    public class QuestionsPageViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The list of questions
        /// </summary>
        public List<QuestionViewModel> Questions { get; set; } = new List<QuestionViewModel>();

        /// <summary>
        /// The error to be shown
        /// </summary>
        public string Error { get; set; } = string.Empty;

        #endregion

        #region Commands

        /// <summary>
        /// The command to submit the results
        /// </summary>
        public ICommand SubmitCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public QuestionsPageViewModel()
        {
            Questions = IoC.Get<QuestionsRepo>().GetAll().Select(t => t.Transform()).ToList();
            SubmitCommand = new RelayCommand(() =>
            {
                Error = "";
                //Ensuring that all questions have been answered
                foreach(QuestionViewModel vm in Questions)
                {
                    if(vm.SelectedOption == -1)
                    {
                        Error = "Please ensure that all questions have been answered";
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(Error))
                    return;
                
                //Sending to the next page
                IoC.Get<ApplicationViewModel>().ChangePage(ApplicationPages.Result, new ResultPageViewModel(Questions));

            });
        }

        #endregion
    }
}

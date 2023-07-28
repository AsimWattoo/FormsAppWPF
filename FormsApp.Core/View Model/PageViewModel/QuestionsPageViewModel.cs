using FormsApp.Core.Application;
using FormsApp.Core.IoCContainer;
using FormsApp.Core.Models;
using FormsApp.Core.Repos;
using FormsApp.Core.View_Model.Base;
using FormsApp.Core.View_Model.ControlViewModels;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Input;

namespace FormsApp.Core.View_Model.PageViewModel
{
    public class QuestionsPageViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The list of questions
        /// </summary>
        public Dictionary<string, List<QuestionViewModel>> Questions { get; set; } = new Dictionary<string, List<QuestionViewModel>>();

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
        public QuestionsPageViewModel(List<QuestionViewModel> previousQuestions)
        {
            List<QuestionViewModel> questions = IoC.Get<QuestionsRepo>()
                .GetAll()
                .Where(t => t.CategoryId != 1)
                .Select(t => t.Transform())
                .ToList();

            List<string> categories = questions.Select(t => t.CategoryName)
                .Distinct()
                .ToList();

            foreach(string category in categories)
            {
                List<QuestionViewModel> questionsPerCategory = questions.Where(t => t.CategoryName == category).ToList();
                Questions.Add(category, questionsPerCategory);
            }

            SubmitCommand = new RelayCommand(() =>
            {
                Error = "";
                List<QuestionViewModel> allQuestions = new List<QuestionViewModel>();
                foreach(string key in Questions.Keys)
                {
                    allQuestions.AddRange(Questions[key]);
                }
                //Ensuring that all questions have been answered
                foreach(QuestionViewModel vm in allQuestions)
                {
                    if(vm.SelectedOption == -1 && vm.Type == Enums.QuestionType.MCQ)
                    {
                        Error = "Please ensure that all questions have been answered";
                        break;
                    }
                    else if(string.IsNullOrEmpty(vm.Value) && vm.Type != Enums.QuestionType.MCQ)
                    {
                        Error = "Please ensure that all the questions have been answered";
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(Error))
                    return;

                Questions.Add("General", previousQuestions);

                //Sending to the next page
                IoC.Get<ApplicationViewModel>().ChangePage(ApplicationPages.Result, new ResultPageViewModel(Questions));

            });
        }

        #endregion
    }
}

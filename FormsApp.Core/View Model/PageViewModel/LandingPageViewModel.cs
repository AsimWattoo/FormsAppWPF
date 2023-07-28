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
    public class LandingPageViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The general questions to be asked on this screen
        /// </summary>
        public List<QuestionViewModel> GeneralQuestions { get; set; } = new List<QuestionViewModel>();

        /// <summary>
        /// The error to be shown
        /// </summary>
        public string Error { get; set; } = string.Empty;

        #endregion

        #region Commands

        /// <summary>
        /// The command to go to questions page
        /// </summary>
        public ICommand NextCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public LandingPageViewModel()
        {
            GeneralQuestions = IoC.Get<QuestionsRepo>()
                .GetAll()
                .Where(t => t.CategoryId == 1)
                .Select(t => t.Transform())
                .ToList();
            NextCommand = new RelayCommand(() =>
            {
                Error = "";

                foreach(QuestionViewModel question in GeneralQuestions)
                {
                    if (string.IsNullOrEmpty(question.Value))
                    {
                        Error = "Please answer all the questions";
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(Error))
                    return;

                IoC.Get<ApplicationViewModel>()
                .ChangePage(ApplicationPages.Questions, new QuestionsPageViewModel(GeneralQuestions));
            });
        }

        #endregion

    }
}

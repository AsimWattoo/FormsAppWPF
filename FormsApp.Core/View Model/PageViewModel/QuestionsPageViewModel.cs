using FormsApp.Core.IoCContainer;
using FormsApp.Core.Repos;
using FormsApp.Core.View_Model.Base;
using FormsApp.Core.View_Model.ControlViewModels;

using System.Collections.Generic;
using System.Linq;

namespace FormsApp.Core.View_Model.PageViewModel
{
    public class QuestionsPageViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The list of questions
        /// </summary>
        public List<QuestionViewModel> Questions { get; set; } = new List<QuestionViewModel>();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public QuestionsPageViewModel()
        {
            Questions = IoC.Get<QuestionsRepo>().GetAll().Select(t => t.Transform()).ToList();
        }

        #endregion
    }
}

using FormsApp.Core.Application;
using FormsApp.Core.IoCContainer;
using FormsApp.Core.Models;
using FormsApp.Core.Repos;
using FormsApp.Core.View_Model.Base;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FormsApp.Core.View_Model.PageViewModel
{
    public class EditableQuestionsViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The questions to be shown on the Editable Questions Page
        /// </summary>
        public ObservableCollection<Question> Questions { get; set; } = new ObservableCollection<Question>();

        #endregion

        #region Command

        /// <summary>
        /// The command to edit the question
        /// </summary>
        public ICommand EditCommand { get; set; }

        /// <summary>
        /// The command to delete the question
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public EditableQuestionsViewModel()
        {
            Questions = new ObservableCollection<Question>(IoC.Get<QuestionsRepo>().GetAll());
            EditCommand = new RelayParameterizedCommand(obj =>
            {
                int num = 0;
                if(int.TryParse(obj.ToString(), out num))
                {
                    Question question = Questions.Where(t => t.Number == num).First();
                    IoC.Get<ApplicationViewModel>().ChangePage(ApplicationPages.Add_Edit_Form, new AddEditQuestionViewModel(question));
                }
            });
            DeleteCommand = new RelayParameterizedCommand(obj =>
            {
                int num = -1;
                if(int.TryParse(obj.ToString(), out num))
                {
                    Question question = Questions.Where(t => t.Number == num).First();
                    IoC.Get<QuestionsRepo>().Delete(question.Id);
                    Questions.Remove(question);
                    int index = 1;
                    foreach(Question q in Questions)
                    {
                        q.Number = index++;
                    }
                    List<int> ids = Questions.Select(t => t.Id).ToList();
                    IoC.Get<QuestionsRepo>().UpdateAll(ids, Questions.ToList());
                }
            });
        }

        #endregion
    }
}

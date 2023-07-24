using FormsApp.Core.Application;
using FormsApp.Core.Enums;
using FormsApp.Core.IoCContainer;
using FormsApp.Core.Models;
using FormsApp.Core.View_Model.Base;
using FormsApp.Core.View_Model.ControlViewModels;

using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FormsApp.Core.View_Model.PageViewModel
{
    public class AddEditQuestionViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The text of the question
        /// </summary>
        public string QuestionText { get; set; } = string.Empty;

        /// <summary>
        /// The options for the question
        /// </summary>
        public ObservableCollection<OptionViewModel> Options { get; set; } = new ObservableCollection<OptionViewModel>();

        /// <summary>
        /// The current mode of operation
        /// </summary>
        public OperationMode Mode { get; set; } = OperationMode.Add;

        #endregion

        #region Commands

        /// <summary>
        /// The command to save the question
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// The command to cancel the form
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// The command to add an option
        /// </summary>
        public ICommand AddOptionCommand { get; set; }

        /// <summary>
        /// The command to remove an option
        /// </summary>
        public ICommand RemoveOptionCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructors
        /// </summary>
        public AddEditQuestionViewModel()
        {
            _initializeCommands();
        }

        /// <summary>
        /// Creates the edit form based on a question
        /// </summary>
        /// <param name="question"></param>
        public AddEditQuestionViewModel(Question question)
        {
            QuestionText = question.Text;
            Mode = OperationMode.Edit;
            int index = 1;
            Options = new ObservableCollection<OptionViewModel>(question.Options.Select(t => t.Transform()));
            foreach (OptionViewModel opt in Options)
            {
                opt.Number = index;
                index++;
            }
            _initializeCommands();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes the commands
        /// </summary>
        private void _initializeCommands()
        {
            AddOptionCommand = new RelayCommand(() => 
            {
                Options.Add(new OptionViewModel() 
                { 
                    Number = Options.Count + 1 ,
                });
            });
            RemoveOptionCommand = new RelayParameterizedCommand((obj) =>
            {
                int i = -1;
                if (int.TryParse(obj.ToString(), out i))
                {
                    OptionViewModel opt = Options.Where(t => t.Number == i).First();
                    Options.Remove(opt);
                    int index = 1;
                    foreach(OptionViewModel mode in Options)
                    {
                        mode.Number = index;
                        index++;
                    }
                }
            });
            SaveCommand = new RelayCommand(() =>
            {
                IoC.Get<ApplicationViewModel>().ChangePage(ApplicationPages.EditableQuestions);
            });
            CancelCommand = new RelayCommand(() =>
            {
                IoC.Get<ApplicationViewModel>().ChangePage(ApplicationPages.EditableQuestions);
            });
        }

        #endregion
    }
}

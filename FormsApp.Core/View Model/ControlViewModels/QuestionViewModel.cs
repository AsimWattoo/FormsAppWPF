using FormsApp.Core.Enums;
using FormsApp.Core.Interfaces;
using FormsApp.Core.IoCContainer;
using FormsApp.Core.Models;
using FormsApp.Core.Repos;
using FormsApp.Core.View_Model.Base;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FormsApp.Core.View_Model.ControlViewModels
{
    public class QuestionViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The number of the question
        /// </summary>
        public int Number { get; set; } = 0;

        /// <summary>
        /// The category id
        /// </summary>
        public int CategoryId { get; set; } = 0;

        /// <summary>
        /// The name of the category
        /// </summary>
        public string CategoryName { get; set; } = string.Empty;

        /// <summary>
        /// The text of the question
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// The options for the questions
        /// </summary>
        public ObservableCollection<OptionSelectViewModel> Options { get; set; } = new ObservableCollection<OptionSelectViewModel>();

        /// <summary>
        /// The number of the selected option
        /// </summary>
        public int SelectedOption { get; set; } = -1;

        /// <summary>
        /// The weight of the question
        /// </summary>
        public double Weight { get; set; } = 0;

        /// <summary>
        /// The type of the question
        /// </summary>
        public QuestionType Type { get; set; } = QuestionType.MCQ;

        /// <summary>
        /// The height of the control based on question type
        /// </summary>
        public double Height
        {
            get
            {
                if (Type == QuestionType.MCQ)
                    return 370;
                else
                    return 150;
            }
        }

        /// <summary>
        /// The value of the question
        /// </summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// The list of dropdown values
        /// </summary>
        public List<string> DropDownValues { get; set; } = new List<string>();

        /// <summary>
        /// The topic of the question
        /// </summary>
        public QuestionTopic Topic { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Fires when the option is selected
        /// </summary>
        public ICommand OptionChecked { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public QuestionViewModel()
        {
            _initializeCommands();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public QuestionViewModel(QuestionType type, QuestionTopic topic)
        {
            Type = type;
            Topic = topic;

            if(type == QuestionType.Dropdown && topic == QuestionTopic.Industry)
            {
                DropDownValues = IoC.Get<IndustryRepo>()
                    .GetAll()
                    .Select(t => t.Name)
                    .ToList();
            }
            else if (type == QuestionType.Dropdown && topic == QuestionTopic.IndustrySize)
            {
                DropDownValues = IoC.Get<IndustrySizeRepo>()
                    .GetAll()
                    .Select(t => t.Size)
                    .ToList();
            }
            else if (type == QuestionType.Dropdown && topic == QuestionTopic.CompanyPosition)
            {
                DropDownValues = IoC.Get<CompanyPositionRepo>()
                    .GetAll()
                    .Select(t => t.Position)
                    .ToList();
            }

            _initializeCommands();
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Initializes the command
        /// </summary>
        private void _initializeCommands()
        {
            OptionChecked = new RelayParameterizedCommand(obj =>
            {
                int num;
                if (int.TryParse(obj.ToString(), out num))
                {
                    if (num == SelectedOption)
                        return;
                    //Unselecting the previously selected option
                    if (SelectedOption != -1)
                    {
                        Options.Where(t => t.Number == SelectedOption).First().Checked = false;
                    }
                    Options.Where(t => t.Number == num).First().Checked = true;
                    SelectedOption = num;
                }
            });
        }

        #endregion
    }
}

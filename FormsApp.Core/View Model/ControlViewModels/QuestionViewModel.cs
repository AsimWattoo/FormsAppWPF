using FormsApp.Core.Interfaces;
using FormsApp.Core.Models;
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
            OptionChecked = new RelayParameterizedCommand(obj =>
            {
                int num;
                if(int.TryParse(obj.ToString(), out num))
                {
                    if (num == SelectedOption)
                        return;
                    //Unselecting the previously selected option
                    if(SelectedOption != -1)
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

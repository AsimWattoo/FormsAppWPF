using FormsApp.Core.View_Model.Base;

namespace FormsApp.Core.View_Model.ControlViewModels
{
    public class OptionSelectViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Indicates whether the option is selected or not
        /// </summary>
        public bool Checked { get; set; } = false;

        /// <summary>
        /// The text of the option
        /// </summary>
        public string OptionText { get; set; } = string.Empty;

        /// <summary>
        /// The number of the option
        /// </summary>
        public int Number { get; set; } = 0;

        /// <summary>
        /// The weight of the option
        /// </summary>
        public double Weight { get; set; } = 0;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public OptionSelectViewModel()
        {
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="optionText"></param>
        /// <param name="number"></param>
        public OptionSelectViewModel(string optionText, int number, double weight)
        {
            OptionText = optionText;
            Number = number;
            Weight = weight;
        }

        #endregion
    }
}

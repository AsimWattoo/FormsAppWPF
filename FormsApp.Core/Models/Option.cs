using FormsApp.Core.Interfaces;
using FormsApp.Core.View_Model.ControlViewModels;

namespace FormsApp.Core.Models
{
    /// <summary>
    /// An option for a question
    /// </summary>
    public class Option : ITransformable<OptionViewModel>
    {
        #region Public Properties

        /// <summary>
        /// The text for an option
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// The weight assigned to the option
        /// </summary>
        public double Weight { get; set; } = 0;

        #endregion

        #region Interface Methods

        /// <summary>
        /// The method to convert model to view model
        /// </summary>
        /// <returns></returns>
        public OptionViewModel Transform()
        {
            return new OptionViewModel() { Text = Text, Weight = Weight };
        }

        #endregion
    }
}

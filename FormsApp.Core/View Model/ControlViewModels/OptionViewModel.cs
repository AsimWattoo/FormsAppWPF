using FormsApp.Core.Interfaces;
using FormsApp.Core.Models;
using FormsApp.Core.View_Model.Base;

using System.Diagnostics;

namespace FormsApp.Core.View_Model.ControlViewModels
{
    public class OptionViewModel : BaseViewModel, ITransformable<Option>
    {
        #region Public Properties

        /// <summary>
        /// The number of the option
        /// </summary>
        public int Number { get; set; } = 0;

        /// <summary>
        /// The text of the option
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The label of the option
        /// </summary>
        public string Label => $"Option {Number}";

        /// <summary>
        /// The tag of the option
        /// </summary>
        public string Tag => $"Enter Option {Number}";

        /// <summary>
        /// The weight of the option
        /// </summary>
        public double Weight { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Transforms the view model to the model
        /// </summary>
        /// <returns></returns>
        public Option Transform()
        {
            return new Option()
            {
                Text = Text,
                Weight = Weight
            };
        }

        #endregion
    }
}

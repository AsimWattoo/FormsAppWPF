using FormsApp.Core.View_Model.Base;

using System.Collections.Generic;

namespace FormsApp.Core.View_Model.ControlViewModels
{
    public class QuestionWiseRecommendations : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The id of the question to which the recommendations belong
        /// </summary>
        public int QuestionId { get; set; } = -1;

        /// <summary>
        /// The text of the question
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// The textual id of the question
        /// </summary>
        public string QuestionText => QuestionId == 0 ? "Overall" : $"Question{QuestionId}";

        /// <summary>
        /// The actual result of the question
        /// </summary>
        public double Result { get; set; } = 0;

        /// <summary>
        /// The list of generated recommendations
        /// </summary>
        public List<string> Recommendations { get; set; } = new List<string>();

        #endregion
    }
}

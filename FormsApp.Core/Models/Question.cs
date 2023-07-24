using FormsApp.Core.Models.Base;

using System.Collections.Generic;

namespace FormsApp.Core.Models
{
    public class Question : Model
    {
        #region Public Properties

        /// <summary>
        /// The number assigned to the question
        /// </summary>
        public int Number { get; set; } = 0;

        /// <summary>
        /// The text of the question
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// The list of options for the questions
        /// </summary>
        public List<Option> Options { get; set; } = new List<Option>();

        #endregion
    }
}

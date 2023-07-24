using FormsApp.Core.Interfaces;
using FormsApp.Core.Models.Base;
using FormsApp.Core.View_Model.ControlViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsApp.Core.Models
{
    public class Recommendation : Model, ITransformable<RecommendationViewModel>
    {
        #region Public Properties

        /// <summary>
        /// The recommendation text
        /// </summary>
        public string RecommendationText { get; set; } = string.Empty;

        /// <summary>
        /// The text contained by the question
        /// </summary>
        public string QuestionText => QuestionId == 0 ? "Overall" : $"Question{QuestionId}";

        /// <summary>
        /// The id of the question to which it is linked
        /// </summary>
        public int QuestionId { get; set; } = 0;

        /// <summary>
        /// The minimum value
        /// </summary>
        public double MinValue { get; set; } = 0;

        /// <summary>
        /// The maximum value
        /// </summary>
        public double MaxValue { get; set; } = 0;

        #endregion

        #region Interface Methods

        /// <summary>
        /// Transforms the item to recommendation view model
        /// </summary>
        /// <returns></returns>
        public RecommendationViewModel Transform()
        {
            return new RecommendationViewModel()
            {
                Id = Id,
                MaxValue = MaxValue,
                Recommendation = RecommendationText,
                QuestionId = QuestionText,
                MinValue = MinValue,
                IsNew = false
            };
        }

        #endregion
    }
}

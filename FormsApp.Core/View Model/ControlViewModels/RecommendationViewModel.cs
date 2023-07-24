using FormsApp.Core.Interfaces;
using FormsApp.Core.Models;
using FormsApp.Core.View_Model.Base;

using System.Security.Permissions;

namespace FormsApp.Core.View_Model.ControlViewModels
{
    public class RecommendationViewModel : BaseViewModel, ITransformable<Recommendation>
    {

        #region Public Properties

        public int Id { get; set; } = 0;

        /// <summary>
        /// The number of the recommendation
        /// </summary>
        public int Number { get; set; } = 0;

        /// <summary>
        /// The recommendation label
        /// </summary>
        public string Label => $"Recommendation {Number}";

        /// <summary>
        /// The recommendation to be given
        /// </summary>
        public string Recommendation { get; set; } = string.Empty;

        /// <summary>
        /// The id of the question to which it belongs
        /// If 0 then to overall result
        /// </summary>
        public string QuestionId { get; set; } = string.Empty;

        /// <summary>
        /// The min value of the range
        /// </summary>
        public double MinValue { get; set; } = 0;

        /// <summary>
        /// The max value
        /// </summary>
        public double MaxValue { get; set; } = 0;

        /// <summary>
        /// Indicates whether a recommendation view model is new or not
        /// </summary>
        public bool IsNew { get; set; } = false;

        #endregion

        #region Interface Methods

        /// <summary>
        /// Transforms the model
        /// </summary>
        /// <returns></returns>
        public Recommendation Transform()
        {
            return new Recommendation()
            {
                Id = Id,
                MaxValue = MaxValue,
                MinValue = MinValue,
                QuestionId = QuestionId == "Overall" ? 0 : int.Parse(QuestionId.Replace("Question", "")),
                RecommendationText = Recommendation
            };
        }

        #endregion

    }
}

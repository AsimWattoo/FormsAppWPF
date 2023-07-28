using FormsApp.Core.Models.Base;

namespace FormsApp.Core.Models
{
    public class Criteria : Model
    {
        #region Public Properties

        /// <summary>
        /// The category to which this criteria belongs
        /// </summary>
        public int CategoryId { get; set; } = 0;

        /// <summary>
        /// The industry to which this criteria belongs
        /// </summary>
        public int IndustryId { get; set; } = 0;

        /// <summary>
        /// The name of the industry
        /// </summary>
        public string IndustryName { get; set; } = string.Empty;

        /// <summary>
        /// The weight of the criteria
        /// </summary>
        public double Weight { get; set; } = 0;

        /// <summary>
        /// The required amount to ensure that criteria has passed
        /// </summary>
        public double PassingPoints { get; set; } = 0;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Criteria()
        {
            
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        public Criteria(int industryId, int categoryId, double weight, double passingPoints)
        {
            CategoryId = categoryId;
            IndustryId = industryId;
            Weight = weight;
            PassingPoints = passingPoints;
        }

        #endregion
    }
}

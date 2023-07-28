using FormsApp.Core.Models.Base;

namespace FormsApp.Core.Models
{
    public class CompanyPosition : Model
    {
        #region Public Properties

        /// <summary>
        /// The position in the company
        /// </summary>
        public string Position { get; set; } = string.Empty;

        #endregion

        #region Constructor

        public CompanyPosition()
        {
            
        }

        public CompanyPosition(string position)
        {
            Position = position;
        }

        #endregion
    }
}

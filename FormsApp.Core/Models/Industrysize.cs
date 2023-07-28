using FormsApp.Core.Models.Base;

namespace FormsApp.Core.Models
{
    public class IndustrySize : Model
    {
        #region Public Properties

        /// <summary>
        /// The size of the industry
        /// </summary>
        public string Size { get; set; } = string.Empty;

        #endregion

        #region Constructor

        public IndustrySize()
        {
            
        }

        public IndustrySize(string size)
        {
            Size = size;
        }

        #endregion
    }
}

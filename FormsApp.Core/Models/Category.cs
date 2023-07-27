using FormsApp.Core.Models.Base;

namespace FormsApp.Core.Models
{
    public class Category : Model
    {
        #region Public Properties

        /// <summary>
        /// The name of the category
        /// </summary>
        public string Name { get; set; } = string.Empty;

        #endregion
    }
}

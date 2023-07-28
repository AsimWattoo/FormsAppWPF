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

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Category()
        {
            
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        public Category(string name)
        {
            Name = name;
        }

        #endregion
    }
}

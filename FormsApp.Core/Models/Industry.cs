using FormsApp.Core.Models.Base;

namespace FormsApp.Core.Models
{
    public class Industry : Model
    {
        #region Public Properties

        /// <summary>
        /// The name of the industry
        /// </summary>
        public string Name { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Industry(string name)
        {
            Name = name;
        }

        public Industry()
        {
            
        }

        #endregion
    }
}

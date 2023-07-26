using System.Data.SQLite;
using System.IO;

namespace FormsApp.Core.DB
{
    /// <summary>
    /// The data which communicates with the backend database
    /// </summary>
    public class DBContext
    {
        #region Private Members

        /// <summary>
        /// The path of the database file
        /// </summary>
        private string _filePath = string.Empty;

        #endregion

        #region Public Properties

        /// <summary>
        /// The path of the database file
        /// </summary>
        public string FilePath => _filePath;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DBContext(string filePath)
        {
            _filePath = filePath;
            //Ensuring that database file exists
            if(!File.Exists(_filePath))
            {
                File.Create(filePath).Close();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates connection with the database
        /// </summary>
        public SQLiteConnection CreateConnection()
        {
            return new SQLiteConnection($"Data Source={_filePath};Version=3;");
        }

        #endregion
    }
}

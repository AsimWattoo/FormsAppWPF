using FormsApp.Core.DB;
using FormsApp.Core.IoCContainer;
using FormsApp.Core.Models.Base;

using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace FormsApp.Core.Repos.Base
{
    public abstract class IRepo<T>
        where T : Model
    {
        #region Protected Members

        /// <summary>
        /// The name of the table
        /// </summary>
        protected string _Table;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public IRepo(string table)
        {
            _Table = table;
            _EnsureTableExists();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Ensures that the table exists in the database or not
        /// </summary>
        protected void _EnsureTableExists()
        {
            string checkQuery = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{_Table}';";
            //Creates the connection
            using(SQLiteConnection connection = IoC.Get<DBContext>().CreateConnection())
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(checkQuery, connection);
                SQLiteDataReader reader= command.ExecuteReader();
                //If the table does not exist then create the table
                if(!reader.HasRows)
                {
                    string sql = GetTableSQL();
                    command = new SQLiteCommand(sql, connection);
                    //Executing the command to create the table
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Gets the sql of the table
        /// </summary>
        /// <returns></returns>
        protected abstract string GetTableSQL();

        /// <summary>
        /// Returns list of all the records
        /// </summary>
        /// <returns></returns>
        public abstract List<T> GetAll();

        /// <summary>
        /// Gets record for the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract T Get(int id);

        /// <summary>
        /// Updates the record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        public abstract void Update(int id, T model);

        /// <summary>
        /// Updates multiple items
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="models"></param>
        public abstract void UpdateAll(List<int> ids, List<T> models);

        /// <summary>
        /// Creates the model with the specified id
        /// </summary>
        /// <param name="model"></param>
        public abstract T Create(T model);

        /// <summary>
        /// Deletes the model with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract bool Delete(int id);

        #endregion
    }
}

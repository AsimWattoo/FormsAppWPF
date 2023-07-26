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
            //_EnsureTableExists();
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
                    reader.Close();
                    string sql = GetTableSQL();
                    command = new SQLiteCommand(sql, connection);
                    //Executing the command to create the table
                    command.ExecuteNonQuery();
                }
                reader.Close();
                connection.Close();
            }
        }

        /// <summary>
        /// Inserts the data
        /// </summary>
        protected void _Insert(T item)
        {
            using(SQLiteConnection connection = IoC.Get<DBContext>().CreateConnection())
            {
                connection.Open();
                string query = GetInsertQuery(item);
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets all the items with the specified id
        /// </summary>
        /// <param name="id"></param>
        protected T _Get(int id)
        {
            using(SQLiteConnection connection = IoC.Get<DBContext>().CreateConnection())
            {
                connection.Open();
                string query = $"SELECT * FROM {_Table} WHERE Id = {id}";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                //Reading the data
                if(reader.HasRows)
                {
                    reader.Read();
                    object[] items = new object[reader.FieldCount];
                    reader.GetValues(items);
                    return GetItem(items);
                }
            }
            return default(T);
        }

        /// <summary>
        /// Gets all the items from the table
        /// </summary>
        /// <returns></returns>
        protected List<T> _GetAll()
        {
            List<T> records = new List<T>();
            using (SQLiteConnection connection = IoC.Get<DBContext>().CreateConnection())
            {
                connection.Open();
                string query = $"SELECT * FROM {_Table}";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                //Reading the data
                while (reader.Read())
                {
                    object[] items = new object[reader.FieldCount];
                    reader.GetValues(items);
                    records.Add(GetItem(items));
                }
                reader.Close();
            }
            return records;
        }

        /// <summary>
        /// Deletes a record from the database
        /// </summary>
        /// <param name="id"></param>
        protected void _Delete(int id)
        {
            using (SQLiteConnection connection = IoC.Get<DBContext>().CreateConnection())
            {
                connection.Open();
                string query = $"DELETE FROM {_Table} WHERE Id = {id}";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates an item in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        protected void _Update(int id, T item)
        {
            using (SQLiteConnection connection = IoC.Get<DBContext>().CreateConnection())
            {
                connection.Open();
                string query = $"UPDATE {_Table} SET {GetUpdateQuery(item)} WHERE Id = {id}";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Gets the update query
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected abstract string GetUpdateQuery(T item);

        /// <summary>
        /// Converts the database read items to actual item
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        protected abstract T GetItem(object[] array);

        /// <summary>
        /// Gets the sql of the table
        /// </summary>
        /// <returns></returns>
        protected abstract string GetTableSQL();

        /// <summary>
        /// Get the insert query for the item
        /// </summary>
        /// <returns></returns>
        protected abstract string GetInsertQuery(T item);

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

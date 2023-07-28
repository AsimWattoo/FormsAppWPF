using FormsApp.Core.DB;
using FormsApp.Core.IoCContainer;
using FormsApp.Core.Models;
using FormsApp.Core.Models.Base;

using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

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

        /// <summary>
        /// The id of the last item
        /// </summary>
        protected int _lastId { get; set; } = 0;

        /// <summary>
        /// The items stored 
        /// </summary>
        protected List<T> _Items { get; set; } = new List<T>();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public IRepo(string table)
        {
            _Table = table;
            _EnsureTableExists();
            _Items = _GetAll();
            if (_Items.Count > 0)
            {
                _lastId = _Items.OrderByDescending(t => t.Id).First().Id;
            }
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
            using (SQLiteConnection connection = IoC.Get<DBContext>().CreateConnection())
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(checkQuery, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                //If the table does not exist then create the table
                if (!reader.HasRows)
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
            using (SQLiteConnection connection = IoC.Get<DBContext>().CreateConnection())
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
            using (SQLiteConnection connection = IoC.Get<DBContext>().CreateConnection())
            {
                connection.Open();
                string query = $"SELECT * FROM {_Table} WHERE Id = {id}";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                //Reading the data
                if (reader.HasRows)
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
        /// Used to perform a create operation
        /// </summary>
        /// <param name="model"></param>
        protected virtual void _PerformCreateOperation(T model) { }

        /// <summary>
        /// Allows to perform operation during delete operation
        /// </summary>
        /// <param name="model"></param>
        protected virtual void _PerformDeleteOperation(int id) { }

        /// <summary>
        /// Allows to perform operation during update operation
        /// </summary>
        /// <param name="model"></param>
        protected virtual void _PerformUpdateOperation(int id, T model) { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns list of all the records
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll() => _Items;

        /// <summary>
        /// Gets record for the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(int id)
        {
            T item = _Items.Where(t => t.Id == id).FirstOrDefault();
            return item;
        }

        /// <summary>
        /// Updates the record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        public void Update(int id, T model)
        {
            int index = _Items.FindIndex(t => t.Id == id);
            if (index >= 0)
            {
                _PerformUpdateOperation(id, model);
                _Update(model.Id, model);
                _Items[index] = model;
            }
        }

        /// <summary>
        /// Updates multiple items
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="models"></param>
        public void UpdateAll(List<int> ids, List<T> models)
        {
            if (ids.Count != models.Count)
            {
                return;
            }

            for (int i = 0; i < ids.Count; i++)
            {
                Update(ids[i], models[i]);
            }
        }

        /// <summary>
        /// Creates the model with the specified id
        /// </summary>
        /// <param name="model"></param>
        public T Create(T model)
        {
            model.Id = ++_lastId;
            _PerformCreateOperation(model);
            _Items.Add(model);
            _Insert(model);
            return model;
        }

        /// <summary>
        /// Creates list of items
        /// </summary>
        /// <param name="models"></param>
        public void Create(List<T> models)
        {
            foreach(T item in models)
            {
                Create(item);
            }
        }

        /// <summary>
        /// Deletes the model with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            T item = _Items.Where(t => t.Id == id).FirstOrDefault();
            if (item == null)
            {
                return false;
            }
            else
            {
                _PerformDeleteOperation(id);
                _Items.Remove(item);
                _Delete(id);
                return true;
            }
        }

        #endregion
    }
}

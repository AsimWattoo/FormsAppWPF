using FormsApp.Core.Models;
using FormsApp.Core.Repos.Base;

using System;

namespace FormsApp.Core.Repos
{
    public class IndustryRepo : IRepo<Industry>
    {
        #region Constructor

        /// <summary>
        /// Default Constructor3
        /// </summary>
        public IndustryRepo() : base("Industries")
        {
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Returns the insert query
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected override string GetInsertQuery(Industry item)
        {
            return $@"INSERT INTO {_Table} (Id, Name) VALUES ({item.Id}, '{item.Name}')";
        }

        /// <summary>
        /// Converts the item
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        protected override Industry GetItem(object[] array)
        {
            return new Industry()
            {
                Id = int.Parse(array[0].ToString()),
                Name = array[1].ToString()
            };
        }

        /// <summary>
        /// Returns the sql to create a table
        /// </summary>
        /// <returns></returns>
        protected override string GetTableSQL()
        {
            return $@"CREATE TABLE {_Table} (
Id NUMBER,
Name TEXT,
PRIMARY KEY ('Id'));";
        }

        /// <summary>
        /// Returns the update query
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override string GetUpdateQuery(Industry item)
        {
            return $@"Name = '{item.Name}'";
        }

        #endregion
    }
}

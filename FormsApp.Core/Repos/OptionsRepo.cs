using FormsApp.Core.Models;
using FormsApp.Core.Repos.Base;

using System.Collections.Generic;
using System.Linq;

namespace FormsApp.Core.Repos
{
    public class OptionsRepo : IRepo<Option>
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public OptionsRepo() : base("Options")
        {
        }

        #endregion

        #region Overriden Methods

        /// <summary>
        /// Returns the SQL to generate table
        /// </summary>
        /// <returns></returns>
        protected override string GetTableSQL()
        {
            return @"CREATE TABLE Options (
Id NUMBER,
QuestionId NUMBER,
Text TEXT,
Weight REAL,
PRIMARY KEY ('Id'));";
        }

        /// <summary>
        /// Converts an array to the object
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        protected override Option GetItem(object[] array)
        {
            return new Option()
            {
                Id = int.Parse(array[0].ToString()),
                QuestionId = int.Parse(array[1].ToString()),
                Text = array[2].ToString(),
                Weight = double.Parse(array[3].ToString()),
            };
        }

        /// <summary>
        /// Returns the insert query
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override string GetInsertQuery(Option item)
        {
            return $@"INSERT INTO {_Table} (Id, QuestionId, Text, Weight) VALUES ({item.Id}, {item.QuestionId},'{item.Text}',{item.Weight})";
        }

        /// <summary>
        /// Returns the update query
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override string GetUpdateQuery(Option item)
        {
            return $@"Text = '{item.Text}', Weight = {item.Weight}";
        }

        #endregion
    }
}

using FormsApp.Core.Models;
using FormsApp.Core.Repos.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsApp.Core.Repos
{
    public class IndustrySizeRepo : IRepo<IndustrySize>
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="table"></param>
        public IndustrySizeRepo() : base("IndustrySize")
        {
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Provides the insert query
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override string GetInsertQuery(IndustrySize item)
        {
            return $@"INSERT INTO {_Table} (Id, Size) VALUES ({item.Id}, '{item.Size}')";
        }

        /// <summary>
        /// Parses the item
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        protected override IndustrySize GetItem(object[] array)
        {
            return new IndustrySize()
            {
                Id = int.Parse(array[0].ToString()),
                Size = array[1].ToString(),
            };
        }

        /// <summary>
        /// Generates the SQL query
        /// </summary>
        /// <returns></returns>
        protected override string GetTableSQL()
        {
            return $@"CREATE TABLE {_Table} (
Id NUMBER,
Size TEXT,
PRIMARY KEY ('Id'));";
        }

        /// <summary>
        /// Provides the update query
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override string GetUpdateQuery(IndustrySize item)
        {
            return $"Size = '{item.Size}'";
        }

        #endregion
    }
}

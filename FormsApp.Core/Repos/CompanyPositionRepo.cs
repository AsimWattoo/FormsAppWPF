using FormsApp.Core.Models;
using FormsApp.Core.Repos.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsApp.Core.Repos
{
    public class CompanyPositionRepo : IRepo<CompanyPosition>
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="table"></param>
        public CompanyPositionRepo() : base("CompanyPosition")
        {
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Provides the insert query
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override string GetInsertQuery(CompanyPosition item)
        {
            return $@"INSERT INTO {_Table} (Id, Position) VALUES ({item.Id}, '{item.Position}')";
        }

        /// <summary>
        /// Parses the item
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        protected override CompanyPosition GetItem(object[] array)
        {
            return new CompanyPosition()
            {
                Id = int.Parse(array[0].ToString()),
                Position = array[1].ToString(),
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
Position TEXT,
PRIMARY KEY ('Id'));";
        }

        /// <summary>
        /// Provides the update query
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override string GetUpdateQuery(CompanyPosition item)
        {
            return $"Position = '{item.Position}'";
        }

        #endregion
    }
}

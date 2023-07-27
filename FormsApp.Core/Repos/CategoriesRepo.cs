using FormsApp.Core.Models;
using FormsApp.Core.Repos.Base;

namespace FormsApp.Core.Repos
{
    public class CategoriesRepo : IRepo<Category>
    {
        #region Default Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="table"></param>
        public CategoriesRepo() : base("Categories")
        {
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Provides the insert query
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override string GetInsertQuery(Category item)
        {
            return $@"INSERT INTO {_Table} (Id, Name) VALUES ({item.Id},'{item.Name}')";
        }

        /// <summary>
        /// Converts the item
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override Category GetItem(object[] array)
        {
            return new Category()
            {
                Id = int.Parse(array[0].ToString()),
                Name = array[1].ToString(),
            };
        }

        /// <summary>
        /// Returns the table SQL
        /// </summary>
        /// <returns></returns>
        protected override string GetTableSQL()
        {
            return $@"CREATE TABLE {_Table} (
Id INTEGER,
Name TEXT);";
        }

        /// <summary>
        /// Create the update query
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override string GetUpdateQuery(Category item)
        {
            return $@"Name = '{item.Name}'";
        }

        #endregion
    }
}

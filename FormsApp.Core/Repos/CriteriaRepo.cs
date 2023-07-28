using FormsApp.Core.IoCContainer;
using FormsApp.Core.Models;
using FormsApp.Core.Repos.Base;

namespace FormsApp.Core.Repos
{
    public class CriteriaRepo : IRepo<Criteria>
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CriteriaRepo() : base("Criteria")
        {
            foreach(Criteria criteria in _Items)
            {
                string name = IoC.Get<IndustryRepo>().Get(criteria.IndustryId)?.Name;
                criteria.IndustryName = name;
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Returns the query to insert the item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override string GetInsertQuery(Criteria item)
        {
            return $@"INSERT INTO {_Table} (Id, CategoryId, IndustryId, Weight, PassingPoints) VALUES ({item.Id}, {item.CategoryId}, {item.IndustryId}, {item.Weight}, {item.PassingPoints})";
        }

        /// <summary>
        /// Converts the item from array to <see cref="Criteria"/>
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        protected override Criteria GetItem(object[] array)
        {
            return new Criteria()
            {
                Id = int.Parse(array[0].ToString()),
                CategoryId = int.Parse(array[1].ToString()),
                IndustryId = int.Parse(array[2].ToString()),
                Weight = double.Parse(array[3].ToString()),
                PassingPoints = double.Parse(array[4].ToString()),
            };
        }

        /// <summary>
        /// Returns the query to create SQL table
        /// </summary>
        /// <returns></returns>
        protected override string GetTableSQL()
        {
            return $@"CREATE TABLE {_Table} (
Id NUMBER,
CategoryId NUMBER,
IndustryId NUMBER,
Weight REAL,
PassingPoints REAL,
PRIMARY KEY ('Id'));";
        }

        /// <summary>
        /// Returns the query to update an item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override string GetUpdateQuery(Criteria item)
        {
            return $"CategoryId = {item.CategoryId}, IndustryId = {item.IndustryId}, Weight = {item.Weight}, PassingPoints = {item.PassingPoints}";
        }

        /// <summary>
        /// Called when the create process starts
        /// </summary>
        /// <param name="model"></param>
        protected override void _PerformCreateOperation(Criteria model)
        {
            model.IndustryName = IoC.Get<IndustryRepo>().Get(model.IndustryId)?.Name;
        }

        #endregion
    }
}

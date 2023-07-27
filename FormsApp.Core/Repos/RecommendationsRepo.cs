using FormsApp.Core.Models;
using FormsApp.Core.Repos.Base;

using System;
using System.Collections.Generic;
using System.Linq;

namespace FormsApp.Core.Repos
{
    public class RecommendationsRepo : IRepo<Recommendation>
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RecommendationsRepo() : base("Recommendations")
        {
        }

        #endregion

        #region Interface Methods

        /// <summary>
        /// Returns SQL to create the table
        /// </summary>
        /// <returns></returns>
        protected override string GetTableSQL()
        {
            return @"CREATE TABLE Recommendations (
Id NUMBER,
RecommendationText TEXT,
QuestionId NUMBER,
MinValue REAL,
MaxValue REAL,
PRIMARY KEY ('Id'));";
        }

        /// <summary>
        /// Converts an array to the object
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        protected override Recommendation GetItem(object[] array)
        {
            return new Recommendation()
            {
                Id = int.Parse(array[0].ToString()),
                RecommendationText = array[1].ToString(),
                QuestionId = int.Parse(array[2].ToString()),
                MinValue = double.Parse(array[3].ToString()),
                MaxValue = double.Parse(array[4].ToString()),
            };
        }

        /// <summary>
        /// Returns the insert query
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override string GetInsertQuery(Recommendation item)
        {
            return $@"INSERT INTO {_Table} (Id, RecommendationText, QuestionId, MinValue, MaxValue) VALUES ({item.Id},'{item.RecommendationText}',{item.QuestionId},{item.MinValue},{item.MaxValue})";
        }

        /// <summary>
        /// Returns the update query
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override string GetUpdateQuery(Recommendation item)
        {
            return $@"QuestionId = {item.QuestionId}, RecommendationText = '{item.RecommendationText}', MinValue = {item.MinValue}, MaxValue = {item.MaxValue}";
        }

        #endregion
    }
}

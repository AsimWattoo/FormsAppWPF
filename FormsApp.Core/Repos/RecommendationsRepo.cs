using FormsApp.Core.Models;
using FormsApp.Core.Repos.Base;

using System;
using System.Collections.Generic;
using System.Linq;

namespace FormsApp.Core.Repos
{
    public class RecommendationsRepo : IRepo<Recommendation>
    {
        #region Private Members

        /// <summary>
        /// The list of recommendations
        /// </summary>
        private List<Recommendation> _recommendations = new List<Recommendation>();

        #endregion

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
        /// Creates the recommendation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override Recommendation Create(Recommendation model)
        {
            _recommendations.Add(model);
            return model;
        }

        /// <summary>
        /// Deletes the recommendation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override bool Delete(int id)
        {
            Recommendation recommendation = _recommendations.Where(t => t.Id == id).FirstOrDefault();
            if (recommendation == null)
                return false;
            else
            {
                _recommendations.Remove(recommendation);
                return true;
            }    
        }

        /// <summary>
        /// Returns a specific recommendation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Recommendation Get(int id)
        {
            return _recommendations.Where(t => t.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Returns list of all the recommendations
        /// </summary>
        /// <returns></returns>
        public override List<Recommendation> GetAll()
        {
            return _recommendations;
        }

        /// <summary>
        /// Updates the specified item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Update(int id, Recommendation model)
        {
            int index = _recommendations.FindIndex(t => t.Id == id);
            if(index != -1)
            {
                _recommendations[index] = model;
            }
        }

        /// <summary>
        /// Updates a list of items
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="models"></param>
        public override void UpdateAll(List<int> ids, List<Recommendation> models)
        {
            if (ids.Count != models.Count)
                return;

            for(int i = 0; i < ids.Count; i++)
            {
                Update(ids[i], models[i]);
            }
        }

        #endregion
    }
}

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

        /// <summary>
        /// The last id assigned
        /// </summary>
        private int _lastId = 0;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RecommendationsRepo() : base("Recommendations")
        {
            //_recommendations = _GetAll();
            if(_recommendations.Count > 0 )
            {
                _lastId = _recommendations.OrderByDescending(t => t.Id).First().Id;
            }
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

        /// <summary>
        /// Creates the recommendation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override Recommendation Create(Recommendation model)
        {
            model.Id = ++_lastId;
            _recommendations.Add(model);
            //_Insert(model);
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
                //_Delete(id);
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
        public override void Update(int id, Recommendation model)
        {
            int index = _recommendations.FindIndex(t => t.Id == id);
            if(index != -1)
            {
                //_Update(id, model);
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

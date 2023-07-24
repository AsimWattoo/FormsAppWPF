using FormsApp.Core.Models;
using FormsApp.Core.Repos.Base;

using System.Collections.Generic;
using System.Linq;

namespace FormsApp.Core.Repos
{
    public class QuestionsRepo : IRepo<Question>
    {
        #region Private Properties

        /// <summary>
        /// The list of questions obtained from the database
        /// </summary>
        private List<Question> _questions = new List<Question>();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public QuestionsRepo()
        {
            
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Stores the question in the list
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Question Create(Question model)
        {
            _questions.Add(model);
            return model;
        }

        /// <summary>
        /// Deletes the question with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            Question question = _questions.Where(t => t.Id == id).FirstOrDefault();
            if (question == null)
                return false;
            else
            {
                _questions.Remove(question);
                return true;
            }
        }

        /// <summary>
        /// Returns an item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Question Get(int id)
        {
            return _questions.Where(t => t.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Get all the items from the list
        /// </summary>
        /// <returns></returns>
        public List<Question> GetAll() => _questions;

        /// <summary>
        /// Updates the question in the list
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        public void Update(int id, Question model)
        {
            int index = _questions.FindIndex(t => t.Id == id);
            _questions[index] = model;
        }

        /// <summary>
        /// Updates the list of questions
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="models"></param>
        public void UpdateAll(List<int> ids, List<Question> models)
        {
            if (ids.Count != models.Count)
                return;

            for(int i = 0; i < ids.Count; i++)
            {
                int index = _questions.FindIndex(t => t.Id == ids[i]);
                _questions[index] = models[i];
            }
        }

        #endregion
    }
}

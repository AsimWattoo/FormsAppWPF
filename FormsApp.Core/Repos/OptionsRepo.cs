using FormsApp.Core.Models;
using FormsApp.Core.Repos.Base;

using System.Collections.Generic;
using System.Linq;

namespace FormsApp.Core.Repos
{
    public class OptionsRepo : IRepo<Option>
    {
        #region Private Members

        /// <summary>
        /// The list of options
        /// </summary>
        private List<Option> _options = new List<Option>();

        /// <summary>
        /// The last id which was assigned
        /// </summary>
        private int _lastId = 0;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public OptionsRepo() : base("Options")
        {
            _options = _GetAll();
            if(_options.Count > 0)
            {
                _lastId = _options.OrderByDescending(t => t.Id).First().Id;
            }
        }

        #endregion


        #region Overriden Methods

        /// <summary>
        /// Creates an option
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override Option Create(Option model)
        {
            model.Id = ++_lastId;
            _Insert(model);
            _options.Add(model);
            return model;
        }

        /// <summary>
        /// Deletes an option
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override bool Delete(int id)
        {
            _Delete(id);

            Option option = _options.Where(t => t.Id == id).FirstOrDefault();
            if(option != null)
            {
                _options.Remove(option);
               return true;
            }
            return false;
        }

        /// <summary>
        /// Gets an option
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Option Get(int id)
        {
            return _options.Where(t => t.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Gets all the options
        /// </summary>
        /// <returns></returns>
        public override List<Option> GetAll()
        {
            return _options;
        }

        /// <summary>
        /// Updates an option
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        public override void Update(int id, Option model)
        {
            _Update(id, model);
            int index = _options.FindIndex(t => t.Id == id);
            if(index >= 0)
            {
                _options[index] = model;
            }
        }

        /// <summary>
        /// Updates list of models
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="models"></param>
        public override void UpdateAll(List<int> ids, List<Option> models)
        {
            for(int i =  0; i < ids.Count; i++)
            {
                Update(ids[i], models[i]);
            }
        }

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

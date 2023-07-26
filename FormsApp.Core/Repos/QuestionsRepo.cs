using FormsApp.Core.IoCContainer;
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

        /// <summary>
        /// The last id assigned
        /// </summary>
        private int _lastId = 0;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public QuestionsRepo() : base("Questions")
        {
            //_loadQuestions();
            if (_questions.Count > 0)
            {
                _lastId = _questions.OrderByDescending(t => t.Id).First().Id;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Load Questions and options
        /// </summary>
        private void _loadQuestions()
        {
            _questions = _GetAll();
            foreach(Question question in _questions)
            {
                question.Options = IoC.Get<OptionsRepo>()
                    .GetAll()
                    .Where(t => t.QuestionId == question.Id)
                    .ToList();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns the sql of the table
        /// </summary>
        /// <returns></returns>
        protected override string GetTableSQL()
        {
            return @"CREATE TABLE Questions (
Id INTEGER,
Number INTEGER,
Text TEXT,
Weight REAL,
PRIMARY KEY ('Id'));";
        }

        /// <summary>
        /// Converts an array to the object
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        protected override Question GetItem(object[] array)
        {
            return new Question()
            {
                Id = int.Parse(array[0].ToString()),
                Number = int.Parse(array[1].ToString()),
                Text = array[2].ToString(),
                Weight = double.Parse(array[3].ToString())
            };
        }

        /// <summary>
        /// Returns the insert query
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override string GetInsertQuery(Question item)
        {
            return $@"INSERT INTO Questions (Id, Number, Text, Weight) VALUES ({item.Id},{item.Number},'{item.Text}',{item.Weight})";
        }

        /// <summary>
        /// Returns the update query
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override string GetUpdateQuery(Question item)
        {
            return $@"Number = {item.Number}, Text = '{item.Text}', Weight = {item.Weight}";
        }

        /// <summary>
        /// Stores the question in the list
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override Question Create(Question model)
        {
            //Creating the question
            model.Id = ++_lastId;
            //_Insert(model);

            //Creating the options
            for (int i = 0; i < model.Options.Count; i++)
            {
                model.Options[i].QuestionId = model.Id;
                //IoC.Get<OptionsRepo>().Create(model.Options[i]);
            }

            _questions.Add(model);
            return model;
        }

        /// <summary>
        /// Deletes the question with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override bool Delete(int id)
        {
            Question question = _questions.Where(t => t.Id == id).FirstOrDefault();
            if (question == null)
                return false;
            else
            {
                _questions.Remove(question);
                //_Delete(id);

                //foreach(Option option in question.Options)
                //{
                //    IoC.Get<OptionsRepo>().Delete(option.Id);
                //}

                return true;
            }
        }

        /// <summary>
        /// Returns an item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Question Get(int id)
        {
            return _questions.Where(t => t.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Get all the items from the list
        /// </summary>
        /// <returns></returns>
        public override List<Question> GetAll() => _questions;

        /// <summary>
        /// Updates the question in the list
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        public override void Update(int id, Question model)
        {
            int index = _questions.FindIndex(t => t.Id == id);

            //Removing all the options
            //List<Option> options = IoC.Get<OptionsRepo>().GetAll().Where(t => t.QuestionId == id).ToList();
            //options.ForEach(t => IoC.Get<OptionsRepo>().Delete(t.Id));

            //Adding new options
            //foreach(Option option in model.Options)
            //{
            //    option.QuestionId = id;
            //    IoC.Get<OptionsRepo>().Create(option);
            //}
            //_Update(id, model);
            _questions[index] = model;
        }

        /// <summary>
        /// Updates the list of questions
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="models"></param>
        public override void UpdateAll(List<int> ids, List<Question> models)
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

using FormsApp.Core.IoCContainer;
using FormsApp.Core.Models;
using FormsApp.Core.Repos.Base;

using System.Collections.Generic;
using System.Linq;

namespace FormsApp.Core.Repos
{
    public class QuestionsRepo : IRepo<Question>
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public QuestionsRepo() : base("Questions")
        {
            _loadQuestions();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Load Questions and options
        /// </summary>
        private void _loadQuestions()
        {
            foreach(Question question in _Items)
            {
                question.Options = IoC.Get<OptionsRepo>()
                    .GetAll()
                    .Where(t => t.QuestionId == question.Id)
                    .ToList();

                Category category = IoC.Get<CategoriesRepo>().GetAll().Where(t => t.Id == question.CategoryId).FirstOrDefault();
                question.CategoryName = category.Name;
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
CategoryId INTEGER,
CategoryName TEXT,
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
                Weight = double.Parse(array[3].ToString()),
                CategoryId = int.Parse(array[4].ToString()),
                CategoryName = array[5].ToString()
            };
        }

        /// <summary>
        /// Returns the insert query
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override string GetInsertQuery(Question item)
        {
            return $@"INSERT INTO Questions (Id, Number, Text, Weight, CategoryId, CategoryName) VALUES ({item.Id},{item.Number},'{item.Text}',{item.Weight}, {item.CategoryId}, '{item.CategoryName}')";
        }

        /// <summary>
        /// Returns the update query
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override string GetUpdateQuery(Question item)
        {
            return $@"Number = {item.Number}, Text = '{item.Text}', Weight = {item.Weight}, CategoryId = {item.CategoryId}, CategoryName = '{item.CategoryName}'";
        }

        /// <summary>
        /// Performs the required operation during creation process
        /// </summary>
        /// <param name="model"></param>
        protected override void _PerformCreateOperation(Question model)
        {
            //Creating the options
            for (int i = 0; i < model.Options.Count; i++)
            {
                model.Options[i].QuestionId = model.Id;
                IoC.Get<OptionsRepo>().Create(model.Options[i]);
            }

            Category category = IoC.Get<CategoriesRepo>()
                .GetAll()
                .Where(t => t.Id == model.CategoryId)
                .FirstOrDefault();
            model.CategoryName = category.Name;
        }

        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected override void _PerformDeleteOperation(int id)
        {
            Question question = _Items.Where(t => t.Id == id).FirstOrDefault();

            foreach(Option option in question.Options)
            {
                IoC.Get<OptionsRepo>().Delete(option.Id);
            }
        }

        /// <summary>
        /// Updates the question in the list
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        protected override void _PerformUpdateOperation(int id, Question model)
        {
            //Removing all the options
            List<Option> options = IoC.Get<OptionsRepo>().GetAll().Where(t => t.QuestionId == id).ToList();
            options.ForEach(t => IoC.Get<OptionsRepo>().Delete(t.Id));

            //Adding new options
            foreach(Option option in model.Options)
            {
                option.QuestionId = id;
                IoC.Get<OptionsRepo>().Create(option);
            }
        }

        #endregion
    }
}

using FormsApp.Core.Enums;
using FormsApp.Core.Interfaces;
using FormsApp.Core.Models.Base;
using FormsApp.Core.View_Model.ControlViewModels;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FormsApp.Core.Models
{
    public class Question : Model, ITransformable<QuestionViewModel>
    {
        #region Public Properties

        /// <summary>
        /// The number assigned to the question
        /// </summary>
        public int Number { get; set; } = 0;

        /// <summary>
        /// The category to which question belongs
        /// </summary>
        public int CategoryId { get; set; } = 0;

        /// <summary>
        /// The name of the category
        /// </summary>
        public string CategoryName { get; set; } = string.Empty;

        /// <summary>
        /// The text of the question
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// The list of options for the questions
        /// </summary>
        public List<Option> Options { get; set; } = new List<Option>();

        /// <summary>
        /// The weight of the question in overall answer
        /// </summary>
        public double Weight { get; set; } = 0;

        /// <summary>
        /// The type of the question
        /// </summary>
        public QuestionType Type { get; set; } = QuestionType.MCQ;

        /// <summary>
        /// The topic of the question
        /// </summary>
        public QuestionTopic Topic { get; set; } = QuestionTopic.Other;

        #endregion

        #region Interface Methods

        /// <summary>
        /// Transforms to the question view model
        /// </summary>
        /// <returns></returns>
        public QuestionViewModel Transform()
        {
            return new QuestionViewModel(Type, Topic)
            {
                Number = Number,
                Text = Text,
                Options = new ObservableCollection<OptionSelectViewModel>(Options
                    .Select(t => new OptionSelectViewModel(t.Text, t.Id, t.Weight))
                    .ToList()),
                Weight = Weight,
                CategoryId = CategoryId,
                CategoryName = CategoryName,
            };
        }

        #endregion
    }
}

using FormsApp.Core.Engines;
using FormsApp.Core.Enums;
using FormsApp.Core.IoCContainer;
using FormsApp.Core.Models;
using FormsApp.Core.Repos;
using FormsApp.Core.View_Model.Base;
using FormsApp.Core.View_Model.ControlViewModels;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;

namespace FormsApp.Core.View_Model.PageViewModel
{
    public class ResultPageViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The overall recommendation based on the answers
        /// </summary>
        public QuestionWiseRecommendations OverallRecommendation { get; set; } = new QuestionWiseRecommendations();

        /// <summary>
        /// The total score
        /// </summary>
        public double TotalScore { get; set; } = 0;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ResultPageViewModel(Dictionary<string,List<QuestionViewModel>> questions)
        {
            //Finding the industry type
            QuestionViewModel industryQuestion = questions["General"].Where(t => t.Type == QuestionType.Dropdown).First();
            //Finding the id of the industry
            int industryId = IoC.Get<IndustryRepo>().GetAll().Where(t => t.Name == industryQuestion.Value).First().Id;

            //Getting list of all the criteria
            List<Criteria> criteria = IoC.Get<CriteriaRepo>().GetAll();
            //Finding the criteria belonging to the selected industry
            criteria = criteria.Where(t => t.IndustryId == industryId).ToList();
            //Creating a dictionary from the criteria
            Dictionary<int, Criteria> catCriteria = criteria.ToDictionary(t => t.CategoryId, t => t);

            //Find average score of each category
            List<Category> categories = IoC.Get<CategoriesRepo>().GetAll();

            double passedCategories = 0;

            foreach(Category category in categories)
            {
                //Skipping the general category of questions
                if (category.Name == "General")
                    continue;

                //Finding average score of each category
                double averageWeight = questions[category.Name].Average(t => t.Options.Where(option => option.Number == t.SelectedOption).First().Weight);

                double totalWeight = averageWeight * catCriteria[category.Id].Weight;
                if(totalWeight >= catCriteria[category.Id].PassingPoints)
                {
                    passedCategories++;
                }
                else
                {
                    OverallRecommendation.Recommendations.Add($"Try to improve {category.Name}");
                }
            }
            OverallRecommendation.Result = Math.Round((passedCategories / (categories.Count - 1)) * 100, 2);
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ResultPageViewModel()
        {

        }

        #endregion
    }
}

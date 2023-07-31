using FormsApp.Core.Application;
using FormsApp.Core.Enums;
using FormsApp.Core.IoCContainer;
using FormsApp.Core.Models;
using FormsApp.Core.Repos;
using FormsApp.Core.View_Model.Base;
using FormsApp.Core.View_Model.ControlViewModels;

using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Windows.Input;

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

        /// <summary>
        /// The color of the result
        /// </summary>
        public string Color { get; set; } = "#000000";

        /// <summary>
        /// The message based on the result
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Indicates whether any recommendation has been generated or not
        /// </summary>
        public bool HasAnyRecommendations => OverallRecommendation.Recommendations.Count > 0;

        #endregion

        #region Private Members

        /// <summary>
        /// The recommendations for each category
        /// </summary>
        private Dictionary<int, string> _categoryRecommendations = new Dictionary<int, string>()
        {
            [3] = "Strive to identify and mitigate biases to ensure equitable outcomes.",
            [4] = "Prioritize user privacy and comply with data protection regulations.",
            [10] = "Provide clear explanations for AI decisions to build trust and understanding.",
            [7] = "Design AI systems to work collaboratively with human users and respect their autonomy.",
            [5] = "Establish clear responsibilities and track AI decision-making for accountability.",
            [8] = "Assess and address AI's impact on individuals and communities for positive outcomes.",
            [9] = "Test and validate AI models to ensure resistance to errors and comply with safety standards.",
            [6] = "Enable transparency and understandability of AI model decisions.",
            [2] = "Measure and maintain accuracy in real-world scenarios for reliable AI performance."
        };

        #endregion

        #region Commands

        /// <summary>
        /// The command to go to landing page
        /// </summary>
        public ICommand ResetCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ResultPageViewModel(Dictionary<string,List<QuestionViewModel>> questions)
        {

            ResetCommand = new RelayCommand(() =>
            {
                IoC.Get<ApplicationViewModel>().ChangePage(ApplicationPages.Landing);
            });

            //Finding the industry type
            QuestionViewModel industryQuestion = questions["General"].Where(t => t.Type == QuestionType.Dropdown && t.Topic == QuestionTopic.Industry).First();
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
                    OverallRecommendation.Recommendations.Add(_categoryRecommendations[category.Id]);
                }
            }
            OverallRecommendation.Result = Math.Round((passedCategories / (categories.Count - 1)) * 100, 2);

            if(OverallRecommendation.Result >= 75 && OverallRecommendation.Result <= 100)
            {
                Color = "#00F700";
                Message = "Complaint and Responsible";
            }
            else if(OverallRecommendation.Result >= 50 && OverallRecommendation.Result <= 74)
            {
                Color = "#f7d000";
                Message = "Requires ethical review";
            }
            else
            {
                Color = "#FF0000";
                Message = "Ethically unready";
            }

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

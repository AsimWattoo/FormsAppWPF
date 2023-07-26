using FormsApp.Core.Engines;
using FormsApp.Core.IoCContainer;
using FormsApp.Core.Models;
using FormsApp.Core.Repos;
using FormsApp.Core.View_Model.Base;
using FormsApp.Core.View_Model.ControlViewModels;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FormsApp.Core.View_Model.PageViewModel
{
    public class ResultPageViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The recommendations for each questions
        /// </summary>
        public ObservableCollection<QuestionWiseRecommendations> QuestionWiseRecommendations { get; set; } = new ObservableCollection<QuestionWiseRecommendations>();

        /// <summary>
        /// The overall recommendation based on the answers
        /// </summary>
        public QuestionWiseRecommendations OverallRecommendation { get; set; } = new QuestionWiseRecommendations();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ResultPageViewModel(List<QuestionViewModel> questions)
        {
            //Getting list of recommendations
            List<Recommendation> recommendations = IoC.Get<RecommendationsRepo>().GetAll();

            //Finding the overall result
            double overall = 0;
            foreach(QuestionViewModel question in questions)
            {
                double selectedWeight = question.Options.Where(t => t.Number == question.SelectedOption).First().Weight;
                overall += (selectedWeight * question.Weight) / 100;
            }

            questions.Insert(0, new QuestionViewModel()
            {
                Number = 0,
                Options = new ObservableCollection<OptionSelectViewModel>() 
                {
                    new OptionSelectViewModel() { Number = 1, Weight = overall },
                },
                SelectedOption = 1,
            });

            //Storing the recommendations
            List<QuestionWiseRecommendations> questionRecommendations = RulesEngine.GenerateRecommendations(questions, recommendations);

            OverallRecommendation = questionRecommendations.Where(t => t.QuestionId == 0).FirstOrDefault() ?? new QuestionWiseRecommendations()
            {
                QuestionId = 0,
                Result = overall
            };

            //Removing the overall recommendation from the list
            questionRecommendations.Remove(OverallRecommendation);
            QuestionWiseRecommendations = new ObservableCollection<QuestionWiseRecommendations>(questionRecommendations);
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

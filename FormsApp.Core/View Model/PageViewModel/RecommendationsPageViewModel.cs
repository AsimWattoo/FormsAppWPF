using FormsApp.Core.IoCContainer;
using FormsApp.Core.Models;
using FormsApp.Core.Repos;
using FormsApp.Core.View_Model.Base;
using FormsApp.Core.View_Model.ControlViewModels;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FormsApp.Core.View_Model.PageViewModel
{
    public class RecommendationsPageViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The recommendations to make
        /// </summary>
        public ObservableCollection<RecommendationViewModel> Recommendations { get; set; } = new ObservableCollection<RecommendationViewModel>();

        /// <summary>
        /// The options to attach recommendations to
        /// </summary>
        public ObservableCollection<string> QuestionOptions { get; set; } = new ObservableCollection<string>();

        #endregion

        #region Commands

        /// <summary>
        /// Adds a recommendation
        /// </summary>
        public ICommand AddRecommendationCommand { get; set; }

        /// <summary>
        /// Removes a recommendation
        /// </summary>
        public ICommand RemoveRecommendationCommand { get; set; }

        /// <summary>
        /// The command to save the changes
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// The command to discard the changes
        /// </summary>
        public ICommand DiscardCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RecommendationsPageViewModel()
        {
            _loadData();

            List<Question> questions = IoC.Get<QuestionsRepo>().GetAll();
            QuestionOptions.Add("Overall");
            questions.ForEach(q => QuestionOptions.Add($"Question{q.Number}"));

            AddRecommendationCommand = new RelayCommand(() =>
            {
                Recommendations.Add(new RecommendationViewModel()
                {
                    IsNew = true,
                    Number = Recommendations.Count + 1
                });
            });
            RemoveRecommendationCommand = new RelayParameterizedCommand(obj =>
            {
                int num;
                if (int.TryParse(obj.ToString(), out num))
                {
                    RecommendationViewModel rec = Recommendations.Where(t => t.Number == num).First();
                    Recommendations.Remove(rec);
                    _updateNumbering();
                }
            });
            SaveCommand = new RelayCommand(() =>
            {
                RecommendationsRepo repo = IoC.Get<RecommendationsRepo>();
                foreach (RecommendationViewModel vm in Recommendations)
                {
                    if (vm.IsNew)
                        repo.Create(vm.Transform());
                    else
                    {
                        Recommendation rec = vm.Transform();
                        repo.Update(rec.Id, rec);
                    }
                }
                _loadData();
            });
            DiscardCommand = new RelayCommand(() =>
            {
                _loadData();
            });
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Loads the data
        /// </summary>
        private void _loadData()
        {
            Recommendations = new ObservableCollection<RecommendationViewModel>(IoC
                .Get<RecommendationsRepo>()
                .GetAll()
                .Select(t => t.Transform())
                .ToList());
            _updateNumbering();
        }

        /// <summary>
        /// Updates the numbering of the recommendations
        /// </summary>
        private void _updateNumbering()
        {
            int index = 1;
            foreach (RecommendationViewModel recommendation in Recommendations)
                recommendation.Number = index++;
        }

        #endregion

    }
}

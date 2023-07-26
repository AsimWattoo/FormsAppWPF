using FormsApp.Core.Application;
using FormsApp.Core.DB;
using FormsApp.Core.IoCContainer;
using FormsApp.Core.Models;
using FormsApp.Core.Repos;

using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace FormsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IoC.RegisterStatic<ApplicationViewModel>();
            DBContext context = new DBContext("D:\\Work\\Programming\\Visual Studio 2022\\C-Sharp\\.Net Framework\\WPF\\FormsApp\\FormsApp\\bin\\Debug\\net6.0-windows\\Database.db");
            IoC.RegisterStatic(context);
            IoC.RegisterStatic<QuestionsRepo>();
            IoC.RegisterStatic<RecommendationsRepo>();
            IoC.Get<QuestionsRepo>().Create(new Question()
            {
                Id = 1,
                Number = 1,
                Options = new List<Option>()
                {
                    new Option() { Id = 1, Text = "Very Satisfied", Weight = 100 },
                    new Option() { Id = 2, Text = "Satisfied", Weight = 75 },
                    new Option() { Id = 3, Text = "Neutral", Weight = 50 },
                    new Option() { Id = 4, Text = "Dissatisfied", Weight = 25 },
                    new Option() { Id = 5, Text = "Very Dissatisfied", Weight = 0 },
                },
                Text = "How much are you satisfied with the AI model results?",
                Weight = 50,
            });
            IoC.Get<RecommendationsRepo>()
                .Create(new Recommendation()
                {
                    Id = 1,
                    MaxValue = 100,
                    MinValue = 90,
                    QuestionId = 1,
                    RecommendationText = "Try to improve the dataset",
                });
            IoC.Get<RecommendationsRepo>()
                .Create(new Recommendation()
                {
                    Id = 2,
                    MaxValue = 60,
                    MinValue = 40,
                    QuestionId = 0,
                    RecommendationText = "Try to increase results by performing data augmentation",
                });
        }

    }
}

using FormsApp.Core.Application;
using FormsApp.Core.IoCContainer;
using FormsApp.Core.Models;
using FormsApp.Core.Repos;

using System.Collections.Generic;
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
            });
        }

    }
}

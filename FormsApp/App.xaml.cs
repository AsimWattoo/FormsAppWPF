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
            //DBContext context = new DBContext("Database.db");
            //IoC.RegisterStatic(context);
            //IoC.RegisterStatic<OptionsRepo>();
            IoC.RegisterStatic<QuestionsRepo>();
            IoC.RegisterStatic<RecommendationsRepo>();

            //Use this command to create a new question
            IoC.Get<QuestionsRepo>().Create(new Question()
            {
                //Keep the numbering of the questions in order
                Number = 1,
                //Specify the options for a question
                Options = new List<Option>()
                {
                    //Follow this template to add further options
                    new Option()
                    {
                        // Give id to each question
                        // Must be unique for each question
                        Id = 1,
                        //The text of the option to be shown
                        Text = "Very Satisfied",
                        //The weight of an option for a given question in percentage can be between 0 and 100
                        Weight = 100,
                    }
                },
                //The text for the question
                Text = "How much are you satisfied with the AI model",
                //The weight of the question in overall result calculation.
                // This means like if a person selects the option 1 then the value of this question will be 100
                //As its weight is 50% so it will contribute (50 * 100) / 100 -> 50 to the overall score while rest will be from other questions.
                Weight = 50,
            });

            //Use this to specify rule
            IoC.Get<RecommendationsRepo>().Create(new Recommendation()
            {
                //Specify question id to 0 for overall result and 1,2,3... for questions in their order
                QuestionId = 0,
                //The text for a recommendation
                RecommendationText = "Use a different model",
                //If the score value lies with in the given range of max and min value then this recommendation will be given.
                //Like if overall score is between 40 and 70 then this recommendation will be given else it wont be given
                MaxValue = 70,
                MinValue = 40,
            });
        }

    }
}

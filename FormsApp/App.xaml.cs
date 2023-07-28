using FormsApp.Core.Application;
using FormsApp.Core.DB;
using FormsApp.Core.Enums;
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
            DBContext context = new DBContext("Database.db");
            IoC.RegisterStatic(context);
            IoC.RegisterStatic<OptionsRepo>();
            IoC.RegisterStatic<CategoriesRepo>();
            IoC.RegisterStatic<IndustryRepo>();
            IoC.RegisterStatic<CriteriaRepo>();
            IoC.RegisterStatic<QuestionsRepo>();
            IoC.RegisterStatic<RecommendationsRepo>();

            //IoC.Get<IndustryRepo>().Create(new List<Industry>()
            //{
            //    new Industry()
            //    {
            //        Name = "Health",
            //    },
            //    new Industry()
            //    {
            //        Name = "Manufacturing",
            //    },
            //});

            //IoC.Get<CategoriesRepo>().Create(new List<Category>()
            //{
            //    new Category()
            //    {
            //        Name = "General"
            //    },
            //    new Category()
            //    {
            //        Name = "Accuracy"
            //    },
            //    new Category()
            //    {
            //        Name = "Bias"
            //    },
            //});

            //IoC.Get<CriteriaRepo>().Create(new List<Criteria>()
            //{
            //    new Criteria()
            //    {
            //        CategoryId = 2,
            //        IndustryId = 1,
            //        Weight = 3,
            //        PassingPoints = 9,
            //    },
            //    new Criteria()
            //    {
            //        CategoryId = 3,
            //        IndustryId = 1,
            //        Weight = 2,
            //        PassingPoints = 8
            //    },
            //    new Criteria()
            //    {
            //        CategoryId = 2,
            //        IndustryId = 2,
            //        Weight = 2,
            //        PassingPoints = 8,
            //    },
            //    new Criteria()
            //    {
            //        CategoryId = 3,
            //        IndustryId = 2,
            //        Weight = 3,
            //        PassingPoints = 9,
            //    }
            //});

            //IoC.Get<QuestionsRepo>().Create(new List<Question>()
            //{
            //    new Question()
            //    {
            //        CategoryId = 1,
            //        Number = 1,
            //        Type = QuestionType.Dropdown,
            //        Text = "Select your industry:",
            //    },
            //    new Question()
            //    {
            //        CategoryId = 1,
            //        Number = 2,
            //        Type = QuestionType.Text,
            //        Text = "What is the size of your industry?",
            //    },
            //    new Question()
            //    {
            //        CategoryId = 1,
            //        Number = 3,
            //        Type = QuestionType.Text,
            //        Text = "What is your post in the company?",
            //    },
            //    new Question()
            //    {
            //        CategoryId = 2,
            //        Number = 4,
            //        Type = QuestionType.MCQ,
            //        Options = new List<Option>()
            //        {
            //            new Option() { Text = "Not at all", Weight = 1 },
            //            new Option() { Text = "A little", Weight = 2 },
            //            new Option() { Text = "Moderate", Weight = 3 },
            //            new Option() { Text = "Good", Weight = 4 },
            //            new Option() { Text = "Very Good", Weight = 5 }
            //        },
            //        Text = "What is the accuracy of the model",
            //    },
            //    new Question()
            //    {
            //        CategoryId = 2,
            //        Number = 5,
            //        Type = QuestionType.MCQ,
            //        Options = new List<Option>()
            //        {
            //            new Option() { Text = "Not at all", Weight = 1 },
            //            new Option() { Text = "A little", Weight = 2 },
            //            new Option() { Text = "Moderate", Weight = 3 },
            //            new Option() { Text = "Good", Weight = 4 },
            //            new Option() { Text = "Very Good", Weight = 5 }
            //        },
            //        Text = "How much as you satisfied with the model",
            //    },
            //    new Question()
            //    {
            //        CategoryId = 3,
            //        Number = 6,
            //        Type = QuestionType.MCQ,
            //        Options = new List<Option>()
            //        {
            //            new Option() { Text = "Not at all", Weight = 1 },
            //            new Option() { Text = "A little", Weight = 2 },
            //            new Option() { Text = "Moderate", Weight = 3 },
            //            new Option() { Text = "Good", Weight = 4 },
            //            new Option() { Text = "Very Good", Weight = 5 }
            //        },
            //        Text = "What is the prediction result of the model?",
            //    }
            //});
        }

    }
}

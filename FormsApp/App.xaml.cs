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
            DBContext context = new DBContext("Database.db");
            IoC.RegisterStatic(context);
            IoC.RegisterStatic<OptionsRepo>();
            IoC.RegisterStatic<QuestionsRepo>();
            IoC.RegisterStatic<RecommendationsRepo>();
        }

    }
}

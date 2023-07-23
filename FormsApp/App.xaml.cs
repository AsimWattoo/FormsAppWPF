using FormsApp.Core.Application;
using FormsApp.Core.IoCContainer;

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
        }

    }
}

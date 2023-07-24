using FormsApp.Core.View_Model.PageViewModel;

using System.Windows.Controls;

namespace FormsApp
{
    /// <summary>
    /// Interaction logic for QuestionsPage.xaml
    /// </summary>
    public partial class QuestionsPage : BasePage<QuestionsPageViewModel>
    {
        public QuestionsPage() : base(new QuestionsPageViewModel())
        {
            InitializeComponent();
        }
    }
}

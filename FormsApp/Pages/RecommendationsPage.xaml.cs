using FormsApp.Core.View_Model.PageViewModel;

namespace FormsApp
{
    /// <summary>
    /// Interaction logic for RecommendationsPage.xaml
    /// </summary>
    public partial class RecommendationsPage : BasePage<RecommendationsPageViewModel>
    {
        public RecommendationsPage() : base(new RecommendationsPageViewModel())
        {
            InitializeComponent();
        }
    }
}

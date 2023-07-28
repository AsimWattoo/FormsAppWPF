using FormsApp.Core.View_Model.PageViewModel;

namespace FormsApp
{
    /// <summary>
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : BasePage<LandingPageViewModel>
    {
        public LandingPage() : base(new LandingPageViewModel())
        {
            InitializeComponent();
        }
    }
}

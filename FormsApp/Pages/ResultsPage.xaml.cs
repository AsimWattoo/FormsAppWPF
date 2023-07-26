using FormsApp.Core.View_Model.PageViewModel;

using System.Windows.Controls;

namespace FormsApp
{
    /// <summary>
    /// Interaction logic for ResultsPage.xaml
    /// </summary>
    public partial class ResultsPage : BasePage<ResultPageViewModel>
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ResultsPage() : base(new ResultPageViewModel())
        {
            InitializeComponent();
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        public ResultsPage(ResultPageViewModel vm) : base(vm)
        {
            InitializeComponent();
        }

        #endregion
    }
}

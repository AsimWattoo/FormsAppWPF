using System.Windows;
using System.Windows.Controls;

namespace FormsApp
{
    /// <summary>
    /// Interaction logic for SidebarButton.xaml
    /// </summary>
    public partial class SidebarButton : UserControl
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SidebarButton()
        {
            InitializeComponent();
        }

        #endregion

        #region Dependency Properties


        /// <summary>
        /// The icon to be displayed
        /// </summary>
        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(string), typeof(SidebarButton), new PropertyMetadata("\uf128"));



        /// <summary>
        /// Indicates whether the button is selected or not
        /// </summary>
        public bool Selected
        {
            get { return (bool)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Selected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProperty =
            DependencyProperty.Register("Selected", typeof(bool), typeof(SidebarButton), new PropertyMetadata(false));



        #endregion
    }
}

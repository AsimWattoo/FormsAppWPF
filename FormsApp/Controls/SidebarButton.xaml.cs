using FormsApp.Core.View_Model.Base;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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


        /// <summary>
        /// The command to be performed when the item is clicked
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(SidebarButton), new PropertyMetadata(default(ICommand)));



        #endregion
    }
}

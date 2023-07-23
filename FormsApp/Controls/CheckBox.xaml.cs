using System.Windows;
using System.Windows.Controls;

namespace FormsApp
{
    /// <summary>
    /// Interaction logic for CheckBox.xaml
    /// </summary>
    public partial class CheckBox : UserControl
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CheckBox()
        {
            InitializeComponent();
        }

        #endregion

        #region Dependency Properties


        /// <summary>
        /// Indicates whether the checkbox is checked or not
        /// </summary>
        public bool Checked
        {
            get { return (bool)GetValue(CheckedProperty); }
            set { SetValue(CheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Checked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckedProperty =
            DependencyProperty.Register("Checked", typeof(bool), typeof(CheckBox), new PropertyMetadata(false));

        /// <summary>
        /// The text property of the control
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(CheckBox), new PropertyMetadata(string.Empty));

        #endregion

        #region Event Handlers

        /// <summary>
        /// Fires when the border mouse button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Checked = !Checked;
        }

        #endregion
    }
}

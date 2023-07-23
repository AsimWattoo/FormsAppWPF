using FormsApp.Animations.BasePageAnimations;
using FormsApp.Animations.FrameworkElementAnimations;
using FormsApp.AttachedProperties;

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Xml.Linq;

namespace FormsApp
{
    /// <summary>
    /// Interaction logic for QuestionControl.xaml
    /// </summary>
    public partial class QuestionControl : UserControl
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public QuestionControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        #endregion

        #region Dependency Properties


        /// <summary>
        /// Indicates whether the question control is expanded or not
        /// </summary>
        public bool Expanded
        {
            get { return (bool)GetValue(ExpandedProperty); }
            set { SetValue(ExpandedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Expanded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExpandedProperty =
            DependencyProperty.Register("Expanded", typeof(bool), typeof(QuestionControl), new PropertyMetadata(false));



        #endregion

        #region Event Handlers

        /// <summary>
        /// Fires when the border mouse button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(this is FrameworkElement element)
            {
                Expanded = !Expanded;
                double expandedHeight = ExpandedHeight.GetValue(this);
                double collapsedHeight = CollapseHeight.GetValue(this);
                double seconds = 0.3;
                if (Expanded)
                    await element.Expand(collapsedHeight, expandedHeight, seconds);
                else
                    await element.Collapse(expandedHeight, collapsedHeight, seconds);
            }

        }

        #endregion
    }
}

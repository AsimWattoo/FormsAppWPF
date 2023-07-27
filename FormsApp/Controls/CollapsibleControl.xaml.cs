using FormsApp.Animations.FrameworkElementAnimations;
using FormsApp.AttachedProperties;
using FormsApp.Core.Enums;
using FormsApp.Core.View_Model.ControlViewModels;

using System.Windows;
using System.Windows.Controls;

namespace FormsApp
{
    /// <summary>
    /// Interaction logic for CollapsibleControl.xaml
    /// </summary>
    public partial class CollapsibleControl : UserControl
    {
        #region Private Members

        /// <summary>
        /// Indicates whether the control is expanded or not
        /// </summary>
        private bool Expanded = false;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CollapsibleControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Dependency Properties

        /// <summary>
        /// The heading of the collapsible control
        /// </summary>
        public string Heading
        {
            get { return (string)GetValue(HeadingProperty); }
            set { SetValue(HeadingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Heading.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeadingProperty =
            DependencyProperty.Register("Heading", typeof(string), typeof(CollapsibleControl), new PropertyMetadata(string.Empty));


        /// <summary>
        /// The height of the item
        /// </summary>
        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.Register("ItemHeight", typeof(double), typeof(CollapsibleControl), new PropertyMetadata(default(double)));

        /// <summary>
        /// The items to show
        /// </summary>
        public Control Items
        {
            get { return (Control)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(Control), typeof(CollapsibleControl), new PropertyMetadata(default(Control), itemsPropertyValueChanged));

        /// <summary>
        /// Fires when the property value changes
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void itemsPropertyValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Control ctrl = d.GetValue(ItemsProperty) as Control;
            if(ctrl != null)
            {
                double itemHeight = (double)d.GetValue(ItemHeightProperty);
                //Fires when the control is loaded
                ctrl.Loaded += (sender, e) =>
                {
                    ItemsControl control = sender as ItemsControl;
                    if(control.Items.Count > 0)
                    {
                        if (control.Items[0] is QuestionViewModel vm)
                        {
                            double totalHeight = control.Items.Count * (vm.Type == QuestionType.MCQ ? itemHeight : 150) + control.Items.Count * 30 + 100;
                            ExpandedHeight.SetValue(d, totalHeight);
                        }
                    }
                };
            }
        }

        #endregion

        #region Event Handlers

        private async void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this is FrameworkElement element)
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

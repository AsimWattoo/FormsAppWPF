using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FormsApp
{
    /// <summary>
    /// Interaction logic for EditableQuestionControl.xaml
    /// </summary>
    public partial class EditableQuestionControl : UserControl
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public EditableQuestionControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Dependency Properties

        /// <summary>
        /// The number of the question
        /// </summary>
        public int Number
        {
            get { return (int)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Number.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(int), typeof(EditableQuestionControl), new PropertyMetadata(0));
        
        /// <summary>
        /// The text of the question
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(EditableQuestionControl), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The command to execute on click
        /// </summary>
        public ICommand EditCommand
        {
            get { return (ICommand)GetValue(EditCommandProperty); }
            set { SetValue(EditCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditCommandProperty =
            DependencyProperty.Register("EditCommand", typeof(ICommand), typeof(EditableQuestionControl), new PropertyMetadata(default(ICommand)));

        /// <summary>
        /// The command parameter for the edit command
        /// </summary>
        public object EditCommandParameter
        {
            get { return (object)GetValue(EditCommandParameterProperty); }
            set { SetValue(EditCommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditCommandParameterProperty =
            DependencyProperty.Register("EditCommandParameter", typeof(object), typeof(EditableQuestionControl), new PropertyMetadata(default(object)));

        /// <summary>
        /// The command to delete the question
        /// </summary>
        public ICommand DeleteCommand
        {
            get { return (ICommand)GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register("DeleteCommand", typeof(ICommand), typeof(EditableQuestionControl), new PropertyMetadata(default(ICommand)));

        /// <summary>
        /// The parameter for the delete command
        /// </summary>
        public object DeleteCommandParameter
        {
            get { return (object)GetValue(DeleteCommandParameterProperty); }
            set { SetValue(DeleteCommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteCommandParameterProperty =
            DependencyProperty.Register("DeleteCommandParameter", typeof(object), typeof(EditableQuestionControl), new PropertyMetadata(default(object)));

        #endregion

        #region Event Handlers

        /// <summary>
        /// Fires when the edit button is clicked.
        /// Calles the command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            EditCommand.Execute(EditCommandParameter);
        }

        /// <summary>
        /// Fires when the delete button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DeleteCommand.Execute(DeleteCommandParameter);
        }

        #endregion

    }
}

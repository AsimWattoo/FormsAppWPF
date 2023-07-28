using FormsApp.Core.Application;
using FormsApp.Core.IoCContainer;
using FormsApp.Core.View_Model.Base;

using System.Windows;
using System.Windows.Input;

namespace FormsApp.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {

        #region Private Members

        /// <summary>
        /// The window with which this view model is associated
        /// </summary>
        private Window _window;

        #endregion

        #region Public Properties

        /// <summary>
        /// The title of the window
        /// </summary>
        public string Title { get; set; } = "AI Ethics Compass";

        /// <summary>
        /// The height of the caption
        /// </summary>
        public double CaptionHeight { get; set; } = 40;

        /// <summary>
        /// Manages the resizing of the custom window
        /// </summary>
        public WindowResizer Resizer { get; set; }

        /// <summary>
        /// The size of the resize border
        /// </summary>
        public double ResizeBorderThickness { get; set; } = 5;

        /// <summary>
        /// The minimum width of the window
        /// </summary>
        public double MinimumWidth { get; set; } = 500;

        /// <summary>
        /// The minimum height of the window
        /// </summary>
        public double MinimumHeight { get; set; } = 750;

        /// <summary>
        /// The indication of form button selection
        /// </summary>
        public bool FormButtonSelected { get; set; } = true;

        /// <summary>
        /// The indication of editable button selected
        /// </summary>
        public bool EditableButtonSelected { get; set; } = false;

        /// <summary>
        /// The indication of recommendation button selected
        /// </summary>
        public bool RecommendationButtonSelected { get; set; } = false;

        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The Command to Maximize Window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The Command to close window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to move to form page
        /// </summary>
        public ICommand FormCommand { get; set; }

        /// <summary>
        /// The command to go to editable page
        /// </summary>
        public ICommand QuestionsEditableCommand { get; set; }

        /// <summary>
        /// The command to go to recommendations page
        /// </summary>
        public ICommand RecommendationsCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindowViewModel(Window window)
        {
            _window = window;
            Resizer = new WindowResizer(_window);
            MinimizeCommand = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => _window.WindowState = _window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized);
            CloseCommand = new RelayCommand(() => _window.Close());
            FormCommand = new RelayCommand(() => _selectPage(ApplicationPages.Questions));
            QuestionsEditableCommand = new RelayCommand(() => _selectPage(ApplicationPages.EditableQuestions));
            RecommendationsCommand = new RelayCommand(() => _selectPage(ApplicationPages.Recommendations));
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Changes the page and state for button
        /// </summary>
        /// <param name="page"></param>
        private void _selectPage(ApplicationPages page)
        {
            IoC.Get<ApplicationViewModel>().ChangePage(page);
            switch (page)
            {
                case ApplicationPages.Questions:
                    FormButtonSelected = true;
                    RecommendationButtonSelected = false;
                    EditableButtonSelected = false;
                    break;
                case ApplicationPages.EditableQuestions:
                    FormButtonSelected = false;
                    RecommendationButtonSelected = false;
                    EditableButtonSelected = true;
                    break;
                case ApplicationPages.Recommendations:
                    FormButtonSelected = false;
                    RecommendationButtonSelected = true;
                    EditableButtonSelected = false;
                    break;
            }
        }

        #endregion

    }
}

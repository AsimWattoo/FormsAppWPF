using System;
using System.Windows.Input;

namespace FormsApp.Core.View_Model.Base
{
    public class RelayCommand : ICommand
    {
        #region Event

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Private Members

        /// <summary>
        /// the action to execute for the command
        /// </summary>
        private Action _action;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RelayCommand(Action action)
        {
            _action = action;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Indicates whether the command can be executed or not
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _action();
        }

        #endregion
    }
}

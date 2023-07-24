using System;
using System.Windows.Input;

namespace FormsApp.Core.View_Model.Base
{
    public class RelayParameterizedCommand : ICommand
    {
        #region Event Handlers

        /// <summary>
        /// Indicates whether the command change attribute changed or not
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Private Members

        /// <summary>
        /// The action to perform
        /// </summary>
        private Action<object> _action;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RelayParameterizedCommand(Action<object> action)
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
        /// <exception cref="NotImplementedException"></exception>
        public void Execute(object parameter)
        {
            _action(parameter);
        }

        #endregion

    }
}

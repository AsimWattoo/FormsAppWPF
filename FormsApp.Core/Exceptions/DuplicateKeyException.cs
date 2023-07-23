using System;

namespace FormsApp.Core.Exceptions
{
    public class DuplicateKeyException : Exception
    {

        #region Constructor

        /// <summary>
        /// Default constructor accepting message for the exception
        /// </summary>
        /// <param name="message"></param>
        public DuplicateKeyException(string message) : base(message)
        {

        }

        #endregion

    }
}

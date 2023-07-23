using PropertyChanged;

using System.ComponentModel;
using System.Runtime.Remoting.Channels;

namespace FormsApp.Core.View_Model.Base
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Events

        /// <summary>
        /// The event to notify property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #endregion

        #region Public Methods

        /// <summary>
        /// Notifies that the property value has changed
        /// </summary>
        /// <param name="propertyName"></param>
        public void PropertyValueChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}

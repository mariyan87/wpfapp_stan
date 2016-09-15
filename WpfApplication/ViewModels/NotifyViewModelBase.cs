using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication.ViewModels
{
    public class NotifyViewModelBase : INotifyPropertyChanged
    {
        ///
        /// Multicast event for property change notifications.
        ///
        public event PropertyChangedEventHandler PropertyChanged;

        ///
        /// Checks if a property already matches a desired value.  Sets the property and
        /// notifies listeners only when necessary.
        ///
        protected bool SetProperty<T>(ref T oldValue, T newValue, string propertyName)
        {
            if (object.Equals(oldValue, newValue)) return false;

            oldValue = newValue;
            this.RaisePropertyChanged(propertyName);
            return true;
        }

        ///
        /// Notifies listeners that a property value has changed.
        ///
        ///Name of the property used to notify listeners.  
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }        
    }
}

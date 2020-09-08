using System.ComponentModel;

namespace SaveFileLogNAS.ViewModel.Events
{
    public class PropertyEvent
        : IProperyEvent
    {
        /// <summary>
        /// Event raised.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Create the OnPropertyChanged method to raise the event.
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System.ComponentModel;

namespace SaveFileLogNAS.ViewModel
{
    public interface ILogViewModel
        : INotifyPropertyChanged
    {
        /// <summary>
        /// Log Content Text.
        /// </summary>
        string LogContentText { get; set; }

        /// <summary>
        /// Info Name Text.
        /// </summary>
        string InfoNameText { get; set; }

        /// <summary>
        /// Is Error.
        /// </summary>
        bool IsError { get; set; }

        /// <summary>
        /// Create the OnPropertyChanged method to raise the event.
        /// </summary>
        /// <param name="propertyName"></param>
        void OnPropertyChanged(string propertyName);
    }
}

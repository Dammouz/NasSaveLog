using SaveFileLogNAS.ViewModel.Events;

namespace SaveFileLogNAS.ViewModel
{
    public class LogViewModel : PropertyEvent, ILogViewModel
    {
        /// <summary>
        /// Log Content Text.
        /// </summary>
        public string LogContentText
        {
            get { return _logContentText; }
            set
            {
                _logContentText = value;
                OnPropertyChanged(nameof(LogContentText));
            }
        }
        private string _logContentText = string.Empty;

        /// <summary>
        /// Info Name Text.
        /// </summary>
        public string InfoNameText
        {
            get { return _infoNameText; }
            set
            {
                _infoNameText = value;
                OnPropertyChanged(nameof(InfoNameText));
            }
        }
        private string _infoNameText = string.Empty;

        /// <summary>
        /// Is Error.
        /// </summary>
        public bool IsError
        {
            get { return _isError; }
            set
            {
                _isError = value;
                OnPropertyChanged(nameof(IsError));
            }
        }
        private bool _isError = false;
    }
}

using SaveFileLogNAS.ViewModel.Events;

namespace SaveFileLogNAS.ViewModel
{
    public class LogViewModel
        : PropertyEvent,
          ILogViewModel
    {
        /// <summary>
        /// Log Content Text.
        /// </summary>
        public string LogContentText
        {
            get => _logContentText;
            set
            {
                _logContentText = value;
                RaisePropertyChanged();
            }
        }
        private string _logContentText = string.Empty;

        /// <summary>
        /// Info Name Text.
        /// </summary>
        public string InfoNameText
        {
            get => _infoNameText;
            set
            {
                _infoNameText = value;
                RaisePropertyChanged();
            }
        }
        private string _infoNameText = string.Empty;

        /// <summary>
        /// Is Error.
        /// </summary>
        public bool IsError
        {
            get => _isError;
            set
            {
                _isError = value;
                RaisePropertyChanged();
            }
        }
        private bool _isError;
    }
}

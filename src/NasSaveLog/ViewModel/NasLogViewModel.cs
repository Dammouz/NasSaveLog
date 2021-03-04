using NasSaveLog.ViewModel.Events;

namespace NasSaveLog.ViewModel
{
    public class NasLogViewModel : PropertyEvent, INasLogViewModel
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
                OnPropertyChange();
            }
        }
        private string _logContentText;

        /// <summary>
        /// Info Name Text.
        /// </summary>
        public string InfoNameText
        {
            get => _infoNameText;
            set
            {
                _infoNameText = value;
                OnPropertyChange();
            }
        }
        private string _infoNameText;

        /// <summary>
        /// Is Error.
        /// </summary>
        public bool IsError
        {
            get => _isError;
            set
            {
                _isError = value;
                OnPropertyChange();
            }
        }
        private bool _isError;
    }
}

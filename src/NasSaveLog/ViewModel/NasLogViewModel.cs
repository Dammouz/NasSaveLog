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
            get;
            set
            {
                field = value;
                OnPropertyChange();
            }
        }

        /// <summary>
        /// Info Name Text.
        /// </summary>
        public string InfoNameText
        {
            get;
            set
            {
                field = value;
                OnPropertyChange();
            }
        }

        /// <summary>
        /// Is Error.
        /// </summary>
        public bool IsError
        {
            get;
            set
            {
                field = value;
                OnPropertyChange();
            }
        }
    }
}

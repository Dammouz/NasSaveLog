using SaveFileLogNAS.ViewModel.Events;

namespace SaveFileLogNAS.ViewModel
{
   public class LogViewModel : PropertyEvent, ILogViewModel
   {
      /// <summary>
      /// Log Content Text
      /// </summary>
      private string _logContentText = string.Empty;
      public string LogContentText {
         get { return _logContentText; }
         set {
            _logContentText = value;
            OnPropertyChanged(nameof(LogContentText));
         }
      }

      /// <summary>
      /// Info Name Text.
      /// </summary>
      private string _infoNameText = string.Empty;
      public string InfoNameText {
         get { return _infoNameText; }
         set {
            _infoNameText = value;
            OnPropertyChanged(nameof(InfoNameText));
         }
      }

      /// <summary>
      /// Is Error.
      /// </summary>
      private bool _isError = false;
      public bool IsError
      {
         get { return _isError; }
         set {
            _isError = value;
            OnPropertyChanged(nameof(IsError));
         }
      }
   }
}

using System.ComponentModel;

namespace SaveFileLogNAS.ViewModel.Events
{
   public interface IProperyEvent
   {
      /// <summary>
      /// Event raised.
      /// </summary>
      event PropertyChangedEventHandler PropertyChanged;

      /// <summary>
      /// Create the OnPropertyChanged method to raise the event.
      /// </summary>
      /// <param name="propertyName"></param>
      void OnPropertyChanged(string propertyName);
   }
}

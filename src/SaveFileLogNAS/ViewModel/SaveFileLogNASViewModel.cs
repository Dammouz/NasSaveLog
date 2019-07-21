using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Common;
using GalaSoft.MvvmLight.Command;
using SaveFileLogNAS.Business;
using SaveFileLogNAS.Globalization;
using SaveFileLogNAS.Helpers;

namespace SaveFileLogNAS.ViewModel
{
   public class SaveFileLogNASViewModel : BindableBase
   {
      #region .ctor

      public SaveFileLogNASViewModel()
      {
         LogNas = new LogNas();
         LogObjectViewModel = new LogViewModel();
         Locales = MakeLocales();
      }

      #endregion

      #region Globalization

      // Locales
      public IGui Locales { get; }

      /// <summary>
      /// Make language.
      /// </summary>
      /// <returns></returns>
      private static IGui MakeLocales()
      {
         var locale = Properties.Settings.Default.Locale;
         if (locale.IsNotNullNorEmpty() && Locale.IsExistingCulture(locale))
         {
            return Locale.GetLocaleGui(locale);
         }

         CultureInfo ci = CultureInfo.InstalledUICulture;
         return Locale.GetLocaleGui(ci.Name);
      }

      #endregion


      ////////////////
      // ATTRIBUTES //
      ////////////////

      // Waiting time before clearing GUI once file saved
      private const int WaitingTimeAfterSaving = 2000;
      
      // Log NAS
      public LogNas LogNas { get; private set; }

      // For XAML
      public LogViewModel LogObjectViewModel { get; set;}
      public bool IsError {
         get { return _isError; }
         set {
            _isError = value;
            LogObjectViewModel.IsError = _isError;
            LogNas.IsError = _isError;
            RaisePropertyChanged(nameof(IsError));
         }
      }
      private bool _isError = false;

      /// <summary>
      /// Check if fields are OK.
      /// </summary>
      /// <returns></returns>
      private bool AreFieldsOK()
      {
         return IsFieldLogContentOK() && IsFieldInfoNameOK();
      }

      /// <summary>
      /// Check if the log content is good.
      /// </summary>
      /// <returns>Log content field is good</returns>
      private bool IsFieldLogContentOK()
      {
         if (!IsFieldOK(LogObjectViewModel.LogContentText, Locales.InitialTextOnLogContent, Locales.ErrorOnFieldLogContent))
         {
            return false;
         }

         LogNas.Content = LogObjectViewModel.LogContentText;
         LogNas.Contents = new List<string> { LogObjectViewModel.LogContentText };
         return true;
      }

      /// <summary>
      /// Check if info name is good.
      /// </summary>
      /// <returns>Info name is good</returns>
      private bool IsFieldInfoNameOK()
      {
         if (!IsFieldOK(LogObjectViewModel.InfoNameText, Locales.InitialTextOnInfoName, Locales.ErrorOnFieldInfoName))
         {
            return false;
         }

         LogNas.LogInfo = LogObjectViewModel.InfoNameText;
         return true;
      }

      /// <summary>
      /// Check if the field is good, not empty or still with initial value.
      /// </summary>
      /// <param name="fieldContent">content of the field</param>
      /// <param name="fieldInitialValue">initial value of the field</param>
      /// <param name="fieldErrorMessage">error mesage in case of</param>
      /// <returns></returns>
      private static bool IsFieldOK(string fieldContent, string fieldInitialValue, string fieldErrorMessage/*, object controlField*/)
      {
         if (!string.IsNullOrEmpty(fieldContent) && !fieldContent.Equals(fieldInitialValue))
         {
            return true;
         }

         // If field is not OK
         MessageBox.Show(fieldErrorMessage);
         //controlField.Focus();
         return false;
      }


      /// <summary>
      /// Make a valid path for the log file in the path given in App.Config.
      /// Create a directory if not existing. Create on Desktop if an exception is thrown.
      /// </summary>
      private string MakeValidPath()
      {
         var path = Properties.Settings.Default.NASFolder;
         if (Directory.Exists(path))
         {
            return path;
         }

         try
         {
            DirectoryInfo di = Directory.CreateDirectory(path);
         }
         catch (Exception ex)
         {
            CommonText.LogMsg($"{Locales.ErrorCreatingFolder}{CommonText.NewLine}{ex.Message}");
            path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
         }
         return path;
      }

      #region Commands

      #region CommandSaveLog

      /// <summary>
      /// Command to save log.
      /// </summary>
      public ICommand SaveLogCommand {
         get
         {
            _saveLogCommand = new RelayCommand(SaveLog);
            return _saveLogCommand;
         }
      }
      private ICommand _saveLogCommand;

      /// <summary>
      /// Save log.
      /// </summary>
      public void SaveLog()
      {
         if (!AreFieldsOK())
         {
            return;
         }

         LogNas.Path = MakeValidPath();
         LogNas.LogDateTime = DateTime.Now;

         // Save results in file
         if (!CommonWriteStream.WriteFilePath(LogNas.Path, LogNas.FullLogName, LogNas.Content))
         {
            return;
         }

         // Clear interface after saving
         if (MessageBox.Show($"{Locales.MessageBoxLogSavedOK}{CommonText.NewLine}{LogNas.FullPath}") == MessageBoxResult.OK)
         {
            System.Threading.Thread.Sleep(WaitingTimeAfterSaving);
            ClearLog();
         }
      }

      #endregion

      #region CommandDisplayHelp

      /// <summary>
      /// Command to display help.
      /// </summary>
      public ICommand DisplayHelpCommand {
         get
         {
            _displayHelpCommand = new RelayCommand(DisplayHelp);
            return _displayHelpCommand;
         }
      }
      private ICommand _displayHelpCommand;

      /// <summary>
      /// Display help.
      /// </summary>
      public void DisplayHelp()
      {
         // Help:
         var helpMessage = $"{Locales.MessageBoxHelpHelp}";

         // About:
         var aboutMessage = $"{Locales.MessageBoxHelpAbout}{CommonText.NewLine}{CommonText.NewLine}"
             + $"{CommonConsts.SoftCompanyName} - {CommonConsts.SoftName}{CommonText.NewLine}"
             + $"{Locales.MessageBoxHelpBuild}{CommonConsts.SoftDate}{CommonText.NewLine}"
             + $"{Locales.MessageBoxHelpVersion}{CommonConsts.SoftVersion}{CommonText.NewLine}";

         // Fill MessageBox parameters
         var messageBoxContent = $"{helpMessage}{CommonText.NewLine}{CommonText.NewLine}{CommonText.NewLine}{aboutMessage}";
         var messageBoxCaption = Locales.MessageBoxHelpCaption;

         MessageBox.Show(messageBoxContent, messageBoxCaption, MessageBoxButton.OK, MessageBoxImage.Question);
      }

      #endregion

      #region CommandClearLog

      /// <summary>
      /// Command to clear log.
      /// </summary>
      public ICommand ClearLogCommand {
         get {
            _clearLogCommand = new RelayCommand(ClearLog);
            return _clearLogCommand;
         }
      }
      private ICommand _clearLogCommand;

      /// <summary>
      /// Clear log.
      /// And clear entire GUI and content.
      /// </summary>
      public void ClearLog()
      {
         LogNas = new LogNas();
         LogObjectViewModel.LogContentText = string.Empty;
         LogObjectViewModel.InfoNameText = string.Empty;
         IsError = false;
      }

      #endregion

      #endregion
   }
}

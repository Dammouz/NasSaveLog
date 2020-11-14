using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Common;
using GalaSoft.MvvmLight.Command;
using SaveFileLogNAS.Business;
using SaveFileLogNAS.Globalization;
using SaveFileLogNAS.ViewModel.Events;

namespace SaveFileLogNAS.ViewModel
{
    public class SaveFileLogNASViewModel
        : PropertyEvent
    {
        #region .ctor

        public SaveFileLogNASViewModel()
        {
            var delay = ConfigurationManager.AppSettings["WaitingTimeAfterSavingInMs"];
            int.TryParse(delay, out var waitingTimeAfterSaving);
            WaitingTimeAfterSavingInMs = waitingTimeAfterSaving;

            var locale = ConfigurationManager.AppSettings["Locale"];
            Locale = LocaleHelper.MakeLocales(locale);

            LogNas = new LogNas();
            LogObjectViewModel = new LogViewModel();
        }

        #endregion .ctor

        #region Properties

        /// <summary>
        /// Path to NAS log folder.
        /// </summary>
        private string NasFolder => ConfigurationManager.AppSettings["NASFolder"];

        /// <summary>
        /// Locale used for the GUI.
        /// </summary>
        public static IGui Locale { get; private set; }

        /// <summary>
        /// Waiting time in ms before clearing GUI once file saved.
        /// </summary>
        private static int WaitingTimeAfterSavingInMs { get; set; }

        /// <summary>
        /// Log NAS.
        /// </summary>
        public LogNas LogNas { get; private set; }

        /// <summary>
        /// For XAML.
        /// </summary>
        public LogViewModel LogObjectViewModel { get; private set; }

        /// <summary>
        /// Notify if errors.
        /// </summary>
        public bool IsError
        {
            get => _isError;
            set
            {
                _isError = value;
                LogObjectViewModel.IsError = _isError;
                LogNas.IsError = _isError;
                RaisePropertyChanged(nameof(IsError));
            }
        }
        private bool _isError;

        #endregion Properties

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
            if (IsFieldOK(LogObjectViewModel.LogContentText, Locale.InitialTextOnLogContent, Locale.ErrorOnFieldLogContent))
            {
                LogNas.Content = LogObjectViewModel.LogContentText;
                LogNas.Contents = new List<string>
                {
                    LogObjectViewModel.LogContentText
                };

                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if info name is good.
        /// </summary>
        /// <returns>Info name is good</returns>
        private bool IsFieldInfoNameOK()
        {
            if (IsFieldOK(LogObjectViewModel.InfoNameText, Locale.InitialTextOnInfoName, Locale.ErrorOnFieldInfoName))
            {
                LogNas.LogInfo = LogObjectViewModel.InfoNameText;

                return true;
            }

            return false;
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
            if (string.IsNullOrEmpty(fieldContent) || fieldContent.Equals(fieldInitialValue))
            {
                // If field is not OK
                MessageBox.Show(fieldErrorMessage);
                //controlField.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// Make a valid path for the log file in the path given in App.Config.
        /// Create a directory if not existing. Create on Desktop if an exception is thrown.
        /// </summary>
        private static string MakeValidPath(string path)
        {
            if (Directory.Exists(path))
            {
                return path;
            }

            try
            {
                var di = Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
                CommonText.LogMsg($"{Locale.ErrorCreatingFolder}{ComonTextConstants.NewLine}{ex.Message}");
                path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            return path;
        }

        #region Commands

        #region CommandSaveLog

        /// <summary>
        /// Command to save log.
        /// </summary>
        public ICommand SaveLogCommand
        {
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

            LogNas.LogDateTime = DateTime.Now;
            LogNas.Path = MakeValidPath(NasFolder);

            // Save results in file
            if (!CommonWriteStream.WriteFilePath(LogNas.Path, LogNas.FullLogName, LogNas.Content))
            {
                return;
            }

            // Clear interface after saving
            if (MessageBox.Show($"{Locale.MessageBoxLogSavedOK}{ComonTextConstants.NewLine}{LogNas.FullPath}") == MessageBoxResult.OK)
            {
                System.Threading.Thread.Sleep(WaitingTimeAfterSavingInMs);
                ClearLog();
            }
        }

        #endregion CommandSaveLog

        #region CommandDisplayHelp

        /// <summary>
        /// Command to display help.
        /// </summary>
        public ICommand DisplayHelpCommand
        {
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
            var helpMessage = $"{Locale.MessageBoxHelpHelp}";

            // About:
            var aboutMessage = $"{Locale.MessageBoxHelpAbout}{ComonTextConstants.NewLine}{ComonTextConstants.NewLine}"
                + $"{CommonConsts.SoftCompanyName} - {CommonConsts.SoftName}{ComonTextConstants.NewLine}"
                + $"{Locale.MessageBoxHelpBuild}{CommonConsts.SoftDate}{ComonTextConstants.NewLine}"
                + $"{Locale.MessageBoxHelpVersion}{CommonConsts.SoftVersion}{ComonTextConstants.NewLine}";

            // Fill MessageBox parameters
            var messageBoxContent = $"{helpMessage}{ComonTextConstants.NewLine}{ComonTextConstants.NewLine}{ComonTextConstants.NewLine}{aboutMessage}";
            var messageBoxCaption = Locale.MessageBoxHelpCaption;

            MessageBox.Show(messageBoxContent, messageBoxCaption, MessageBoxButton.OK, MessageBoxImage.Question);
        }

        #endregion CommandDisplayHelp

        #region CommandClearLog

        /// <summary>
        /// Command to clear log.
        /// </summary>
        public ICommand ClearLogCommand
        {
            get
            {
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

        #endregion CommandClearLog

        #endregion Commands
    }
}

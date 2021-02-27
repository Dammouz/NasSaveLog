using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Common;
using Common.Extensions;
using NasSaveLog.Business;
using NasSaveLog.Common;
using NasSaveLog.Globalization;
using NasSaveLog.ViewModel.Events;

namespace NasSaveLog.ViewModel
{
    public class NasSaveLogViewModel : PropertyEvent
    {
        #region .ctor

        public NasSaveLogViewModel()
        {
            int.TryParse(ConfigurationManager.AppSettings["WaitingTimeAfterSavingInMs"], out var waitingTimeAfterSaving);
            WaitingTimeAfterSavingInMs = waitingTimeAfterSaving;

            Locale = LocaleHelper.MakeLocales(ConfigurationManager.AppSettings["Locale"]);

            _previousLogNasPath = ConfigurationManager.AppSettings["NasSaveLogFolder"];
            LogNas = new NasLog();
            LogObjectViewModel = new NasLogViewModel();
        }

        #endregion .ctor

        #region Properties

        /// <summary>
        /// Path to NAS log folder.
        /// </summary>
        private static string NasLogFolder => ConfigurationManager.AppSettings["NasSaveLogFolder"];

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
        public INasLog LogNas { get; private set; }

        /// <summary>
        /// For XAML.
        /// </summary>
        public INasLogViewModel LogObjectViewModel { get; private set; }

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
                OnPropertyChange();
            }
        }
        private bool _isError;

        private string _previousLogNasPath;
        private const string _explorerExe = "explorer.exe";

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
                _saveLogCommand = new RelayCommand(x => SaveLog());
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
            LogNas.Path = MakeValidPath(NasLogFolder);

            // Save results in file
            if (CommonWriteStream.WriteFilePath(LogNas.Path, LogNas.FullLogName, LogNas.Content))
            {
                // Clear interface after saving
                if (MessageBox.Show($"{Locale.MessageBoxLogSavedOK}{ComonTextConstants.NewLine}{LogNas.FullPath}") == MessageBoxResult.OK)
                {
                    System.Threading.Thread.Sleep(WaitingTimeAfterSavingInMs);
                    _previousLogNasPath = LogNas.Path;
                    ClearLog();
                }
            }
        }

        #endregion CommandSaveLog

        #region CommandOpenLog

        /// <summary>
        /// Command to open log folder.
        /// </summary>
        public ICommand OpenLogCommand
        {
            get
            {
                _openLogCommand = new RelayCommand(x => OpenLog());
                return _openLogCommand;
            }
        }
        private ICommand _openLogCommand;

        /// <summary>
        /// Open log folder.
        /// </summary>
        public void OpenLog()
        {
            if (_previousLogNasPath.IsNotNullNorEmpty())
            {
                try
                {
                    System.Diagnostics.Process.Start(_explorerExe, _previousLogNasPath);
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"{exception.Message}{ComonTextConstants.NewLine}Path: '{_previousLogNasPath}'", "An error occurs", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        #endregion CommandOpenLog

        #region CommandDisplayHelp

        /// <summary>
        /// Command to display help.
        /// </summary>
        public ICommand DisplayHelpCommand
        {
            get
            {
                _displayHelpCommand = new RelayCommand(x => DisplayHelp());
                return _displayHelpCommand;
            }
        }
        private ICommand _displayHelpCommand;

        /// <summary>
        /// Display help.
        /// </summary>
        public static void DisplayHelp()
        {
            // Help:
            var helpMessage = $"{Locale.MessageBoxHelpHelp}";

            // About:
            var aboutMessage = $"{Locale.MessageBoxHelpAbout}{ComonTextConstants.NewLine}{ComonTextConstants.NewLine}"
                + $"{CommonConstants.SoftCompanyName} - {CommonConstants.SoftName}{ComonTextConstants.NewLine}"
                + $"{Locale.MessageBoxHelpBuild}{CommonConstants.SoftDate}{ComonTextConstants.NewLine}"
                + $"{Locale.MessageBoxHelpVersion}{CommonConstants.SoftVersion}{ComonTextConstants.NewLine}";

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
                _clearLogCommand = new RelayCommand(x => ClearLog());
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
            LogNas = new NasLog();
            LogObjectViewModel.LogContentText = string.Empty;
            LogObjectViewModel.InfoNameText = string.Empty;
            IsError = false;
        }

        #endregion CommandClearLog

        #endregion Commands
    }
}

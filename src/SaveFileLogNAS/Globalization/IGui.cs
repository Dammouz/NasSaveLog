namespace SaveFileLogNAS.Globalization
{
   public interface IGui
   {
      // Initial values
      string InitialTextOnLogContent { get; }
      string InitialTextOnInfoName { get; }

      // Controls
      string AppTitle { get; }
      string CheckBoxIsError { get; }
      string ButtonSave { get; }
      string ButtonHelp { get; }
      string ButtonClear { get; }

      // Tooltips
      string AppToolTip { get; }
      string TextBoxLogContentToolTip { get; }
      string TextBoxInfoNameToolTip { get; }
      string CheckBoxIsErrorToolTip { get; }
      string ButtonSaveToolTip { get; }
      string ButtonHelpToolTip { get; }
      string ButtonClearToolTip { get; }

      // Saving
      string MessageBoxLogSavedOK { get; }

      // Help message box
      string MessageBoxHelpCaption { get; }
      string MessageBoxHelpHelp { get; }
      string MessageBoxHelpAbout { get; }
      string MessageBoxHelpBuild { get; }
      string MessageBoxHelpVersion { get; }

      // Field error messages
      string ErrorOnFieldLogContent { get; }
      string ErrorOnFieldInfoName { get; }

      // Error on folder path
      string ErrorCreatingFolder { get; }
   }
}

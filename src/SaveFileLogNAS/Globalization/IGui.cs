namespace SaveFileLogNAS.Globalization
{
    public interface IGui
    {
        #region Initial values

        string InitialTextOnLogContent { get; }
        string InitialTextOnInfoName { get; }

        #endregion Initial values

        #region Controls

        string AppTitle { get; }
        string CheckBoxIsError { get; }
        string ButtonSave { get; }
        string ButtonHelp { get; }
        string ButtonClear { get; }

        #endregion Controls

        #region Tooltips

        string AppToolTip { get; }
        string TextBoxLogContentToolTip { get; }
        string TextBoxInfoNameToolTip { get; }
        string CheckBoxIsErrorToolTip { get; }
        string ButtonSaveToolTip { get; }
        string ButtonHelpToolTip { get; }
        string ButtonClearToolTip { get; }

        #endregion Tooltips

        #region Saving

        string MessageBoxLogSavedOK { get; }

        #endregion Saving

        #region Help message box

        string MessageBoxHelpCaption { get; }
        string MessageBoxHelpHelp { get; }
        string MessageBoxHelpAbout { get; }
        string MessageBoxHelpBuild { get; }
        string MessageBoxHelpVersion { get; }

        #endregion Help message box

        #region Field error messages

        string ErrorOnFieldLogContent { get; }
        string ErrorOnFieldInfoName { get; }

        #endregion Field error messages

        #region Error on folder path

        string ErrorCreatingFolder { get; }

        #endregion Error on folder path
    }
}

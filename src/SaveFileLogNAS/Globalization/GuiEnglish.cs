using Common;

namespace SaveFileLogNAS.Globalization
{
    public class GuiEnglish : IGui
    {
        #region Initial values

        public string InitialTextOnLogContent { get; } = "Copy logs here...";
        public string InitialTextOnInfoName { get; } = "Write informations about name here...";

        #endregion Initial values

        #region Controls

        public string AppTitle { get; } = "Save File Log NAS";
        public string CheckBoxIsError { get; } = "Error?";
        public string ButtonSave { get; } = "Save";
        public string ButtonHelp { get; } = "?";
        public string ButtonClear { get; } = "X";

        #endregion Controls

        #region Tooltips

        public string AppToolTip { get; } = "Save File Log NAS";
        public string TextBoxLogContentToolTip { get; } = "Copy logs here...";
        public string TextBoxInfoNameToolTip { get; } = "Write informations about name here...";
        public string CheckBoxIsErrorToolTip { get; } = "Error?";
        public string ButtonSaveToolTip { get; } = "Save";
        public string ButtonHelpToolTip { get; } = "Help?";
        public string ButtonClearToolTip { get; } = "Clear all";

        #endregion Tooltips

        #region Saving

        public string MessageBoxLogSavedOK { get; } = "Saved OK. Log files:";

        #endregion Saving

        #region Help message box

        public string MessageBoxHelpCaption { get; } = "Help";
        public string MessageBoxHelpHelp { get; } = $"HELP !{ComonTextConstants.NewLine}{ComonTextConstants.NewLine}"
                                                  + $"Copy log files content from Open Media Vault "
                                                  + $"in the main text box. Then click on \"Save\" to save"
                                                  + $"the file in the log folder. If this one doesn't exist, "
                                                  + $"the log file will be save on the Desktop.{ComonTextConstants.NewLine}"
                                                  + $"Add subsidiary informations in the second field.";
        public string MessageBoxHelpAbout { get; } = "ABOUT :";
        public string MessageBoxHelpBuild { get; } = "Build :   ";
        public string MessageBoxHelpVersion { get; } = "Version :   ";

        #endregion Help message box

        #region Field error messages

        public string ErrorOnFieldLogContent { get; } = "Copy log in the appropriate field.";
        public string ErrorOnFieldInfoName { get; } = "Copy informations about name in the appropriate field.";

        #endregion Field error messages

        #region Error on folder path

        public string ErrorCreatingFolder { get; } = "Error on creation of the log folder.";

        #endregion Error on folder path
    }
}

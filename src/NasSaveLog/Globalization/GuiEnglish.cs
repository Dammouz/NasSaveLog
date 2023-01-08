using Common.Constants;

namespace NasSaveLog.Globalization
{
    internal class GuiEnglish : IGui
    {
        #region Initial values

        public virtual string InitialTextOnLogContent { get; } = "Copy logs here...";
        public virtual string InitialTextOnInfoName { get; } = "Write informations about log name here...";

        #endregion Initial values

        #region Controls

        public virtual string AppTitle { get; } = "NAS Save Log";
        public virtual string CheckBoxIsError { get; } = "Error?";
        public virtual string ButtonSave { get; } = "Save";
        public virtual string ButtonOpen { get; } = "Open";
        public virtual string ButtonHelp { get; } = "?";
        public virtual string ButtonClear { get; } = "X";

        #endregion Controls

        #region Tooltips

        public virtual string AppToolTip { get; } = "NAS Save Log";
        public virtual string TextBoxLogContentToolTip { get; } = "Copy logs here...";
        public virtual string TextBoxInfoNameToolTip { get; } = "Write informations about name here...";
        public virtual string CheckBoxIsErrorToolTip { get; } = "Error?";
        public virtual string ButtonSaveToolTip { get; } = "Save";
        public virtual string ButtonOpenToolTip { get; } = "Open";
        public virtual string ButtonHelpToolTip { get; } = "Help?";
        public virtual string ButtonClearToolTip { get; } = "Clear all";

        #endregion Tooltips

        #region Saving

        public virtual string MessageBoxLogSavedOK { get; } = "Saved OK. Log files:";

        #endregion Saving

        #region Help message box

        public virtual string MessageBoxHelpCaption { get; } = "Help";
        public virtual string MessageBoxHelpHelp { get; } = $"HELP !"
            + $"{TextConstants.NewLine}{TextConstants.NewLine}"
            + $"Copy log files content from Open Media Vault "
            + $"in the main text box. Then click on \"Save\" to save"
            + $"the file in the log folder. If this one doesn't exist, "
            + $"the log file will be save on the Desktop."
            + $"{TextConstants.NewLine}"
            + $"Add subsidiary informations in the second field.";
        public virtual string MessageBoxHelpAbout { get; } = "ABOUT :";
        public virtual string MessageBoxHelpBuild { get; } = "Build :   ";
        public virtual string MessageBoxHelpVersion { get; } = "Version :   ";

        #endregion Help message box

        #region Field error messages

        public virtual string ErrorOnFieldLogContent { get; } = "Copy log in the appropriate field.";
        public virtual string ErrorOnFieldInfoName { get; } = "Copy informations about name in the appropriate field.";

        #endregion Field error messages

        #region Error on folder path

        public virtual string ErrorCreatingFolder { get; } = "Error on creation of the log folder.";

        #endregion Error on folder path
    }
}

using Common.Constants;

namespace NasSaveLog.Globalization
{
    internal class GuiEnglish : IGui
    {
        #region Initial values

        public virtual string InitialTextOnLogContent => "Copy logs here...";
        public virtual string InitialTextOnInfoName => "Write informations about log name here...";

        #endregion Initial values

        #region Controls

        public virtual string AppTitle => "NAS Save Log";
        public virtual string CheckBoxIsError => "Error?";
        public virtual string ButtonSave => "Save";
        public virtual string ButtonOpen => "Open";
        public virtual string ButtonHelp => "?";
        public virtual string ButtonClear => "X";

        #endregion Controls

        #region Tooltips

        public virtual string AppToolTip => "NAS Save Log";
        public virtual string TextBoxLogContentToolTip => "Copy logs here...";
        public virtual string TextBoxInfoNameToolTip => "Write informations about name here...";
        public virtual string CheckBoxIsErrorToolTip => "Error?";
        public virtual string ButtonSaveToolTip => "Save";
        public virtual string ButtonOpenToolTip => "Open";
        public virtual string ButtonHelpToolTip => "Help?";
        public virtual string ButtonClearToolTip => "Clear all";

        #endregion Tooltips

        #region Saving

        public virtual string MessageBoxLogSavedOK => "Saved OK. Log files:";

        #endregion Saving

        #region Help message box

        public virtual string MessageBoxHelpCaption => "Help";

        public virtual string MessageBoxHelpHelp { get; } = $"HELP !"
                                                            + $"{TextConstants.NewLine}{TextConstants.NewLine}"
                                                            + $"Copy log files content from Open Media Vault "
                                                            + $"in the main text box. Then click on \"Save\" to save"
                                                            + $"the file in the log folder. If this one doesn't exist, "
                                                            + $"the log file will be save on the Desktop."
                                                            + $"{TextConstants.NewLine}"
                                                            + $"Add subsidiary informations in the second field.";
        public virtual string MessageBoxHelpAbout => "ABOUT :";
        public virtual string MessageBoxHelpBuild => "Build :   ";
        public virtual string MessageBoxHelpVersion => "Version :   ";

        #endregion Help message box

        #region Field error messages

        public virtual string ErrorOnFieldLogContent => "Copy log in the appropriate field.";
        public virtual string ErrorOnFieldInfoName => "Copy informations about name in the appropriate field.";

        #endregion Field error messages

        #region Error on folder path

        public virtual string ErrorCreatingFolder => "Error on creation of the log folder.";

        #endregion Error on folder path
    }
}

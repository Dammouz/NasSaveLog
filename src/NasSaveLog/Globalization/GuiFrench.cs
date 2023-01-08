using Common.Constants;

namespace NasSaveLog.Globalization
{
    internal class GuiFrench : GuiEnglish
    {
        #region Initial values

        public override string InitialTextOnLogContent { get; } = "Copier les logs ici ...";
        public override string InitialTextOnInfoName { get; } = "Écrire les informations de nom du log ici ...";

        #endregion Initial values

        #region Controls

        public override string CheckBoxIsError { get; } = "Erreur ?";
        public override string ButtonSave { get; } = "Enregistrer";
        public override string ButtonOpen { get; } = "Ouvrir";

        #endregion Controls

        #region Tooltips

        public override string AppToolTip { get; } = "NAS Save Log";
        public override string TextBoxLogContentToolTip { get; } = "Copier les logs ici ...";
        public override string TextBoxInfoNameToolTip { get; } = "Écrire les informations de nom ici ...";
        public override string CheckBoxIsErrorToolTip { get; } = "Erreur ?";
        public override string ButtonSaveToolTip { get; } = "Enregistrer";
        public override string ButtonOpenToolTip { get; } = "Ouvrir";
        public override string ButtonHelpToolTip { get; } = "Aide ?";
        public override string ButtonClearToolTip { get; } = "RAZ";

        #endregion Tooltips

        #region Saving

        public override string MessageBoxLogSavedOK { get; } = "Sauvegarde effectuée. Fichier de log :";

        #endregion Saving

        #region Help message box

        public override string MessageBoxHelpCaption { get; } = "Aide";
        public override string MessageBoxHelpHelp { get; } = $"HELP !{TextConstants.NewLine}{TextConstants.NewLine}"
                                                  + $"Copier les fichiers de log d'Open Media Vault "
                                                  + $"dans le champ de texte. Puis cliquer sur \"Enregistrer\" pour enregistrer"
                                                  + $"le fichier dans le dossier de log. Si celui-ci est inexistant, "
                                                  + $"le fichier sera enregistré sur le bureau.{TextConstants.NewLine}"
                                                  + $"Ajouter un complément de nom dans le champ d'informations.";
        public override string MessageBoxHelpAbout { get; } = "À PROPOS :";
        public override string MessageBoxHelpBuild { get; } = "Compilation :   ";

        #endregion Help message box

        #region Field error messages

        public override string ErrorOnFieldLogContent { get; } = "Copier le log dans le champ.";
        public override string ErrorOnFieldInfoName { get; } = "Écrire les informations de nom.";

        #endregion Field error messages

        #region Error on folder path

        public override string ErrorCreatingFolder { get; } = "Erreur lors de la création du dossier de sauvegarde.";

        #endregion Error on folder path
    }
}

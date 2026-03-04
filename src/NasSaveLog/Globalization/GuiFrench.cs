using Common.Constants;

namespace NasSaveLog.Globalization
{
    internal class GuiFrench : GuiEnglish
    {
        #region Initial values

        public override string InitialTextOnLogContent => "Copier les logs ici ...";
        public override string InitialTextOnInfoName => "Écrire les informations de nom du log ici ...";

        #endregion Initial values

        #region Controls

        public override string CheckBoxIsError => "Erreur ?";
        public override string ButtonSave => "Enregistrer";
        public override string ButtonOpen => "Ouvrir";

        #endregion Controls

        #region Tooltips

        public override string AppToolTip => "NAS Save Log";
        public override string TextBoxLogContentToolTip => "Copier les logs ici ...";
        public override string TextBoxInfoNameToolTip => "Écrire les informations de nom ici ...";
        public override string CheckBoxIsErrorToolTip => "Erreur ?";
        public override string ButtonSaveToolTip => "Enregistrer";
        public override string ButtonOpenToolTip => "Ouvrir";
        public override string ButtonHelpToolTip => "Aide ?";
        public override string ButtonClearToolTip => "RAZ";

        #endregion Tooltips

        #region Saving

        public override string MessageBoxLogSavedOK => "Sauvegarde effectuée. Fichier de log :";

        #endregion Saving

        #region Help message box

        public override string MessageBoxHelpCaption => "Aide";

        public override string MessageBoxHelpHelp { get; } = $"HELP !{TextConstants.NewLine}{TextConstants.NewLine}"
                                                             + $"Copier les fichiers de log d'Open Media Vault "
                                                             + $"dans le champ de texte. Puis cliquer sur \"Enregistrer\" pour enregistrer"
                                                             + $"le fichier dans le dossier de log. Si celui-ci est inexistant, "
                                                             + $"le fichier sera enregistré sur le bureau.{TextConstants.NewLine}"
                                                             + $"Ajouter un complément de nom dans le champ d'informations.";
        public override string MessageBoxHelpAbout => "À PROPOS :";
        public override string MessageBoxHelpBuild => "Compilation :   ";

        #endregion Help message box

        #region Field error messages

        public override string ErrorOnFieldLogContent => "Copier le log dans le champ.";
        public override string ErrorOnFieldInfoName => "Écrire les informations de nom.";

        #endregion Field error messages

        #region Error on folder path

        public override string ErrorCreatingFolder => "Erreur lors de la création du dossier de sauvegarde.";

        #endregion Error on folder path
    }
}

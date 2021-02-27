using Common;

namespace NasSaveLog.Globalization
{
    public class GuiFrench : IGui
    {
        #region Initial values

        public string InitialTextOnLogContent { get; } = "Copier les logs ici ...";
        public string InitialTextOnInfoName { get; } = "Écrire les informations de nom ici ...";

        #endregion Initial values

        #region Controls

        public string AppTitle { get; } = "NAS Save Log";
        public string CheckBoxIsError { get; } = "Erreur ?";
        public string ButtonSave { get; } = "Enregistrer";
        public string ButtonOpen { get; } = "Ouvrir";
        public string ButtonHelp { get; } = "?";
        public string ButtonClear { get; } = "X";

        #endregion Controls

        #region Tooltips

        public string AppToolTip { get; } = "NAS Save Log";
        public string TextBoxLogContentToolTip { get; } = "Copier les logs ici ...";
        public string TextBoxInfoNameToolTip { get; } = "Écrire les informations de nom ici ...";
        public string CheckBoxIsErrorToolTip { get; } = "Erreur ?";
        public string ButtonSaveToolTip { get; } = "Enregistrer";
        public string ButtonOpenToolTip { get; } = "Ouvrir";
        public string ButtonHelpToolTip { get; } = "Aide ?";
        public string ButtonClearToolTip { get; } = "RAZ";

        #endregion Tooltips

        #region Saving

        public string MessageBoxLogSavedOK { get; } = "Sauvegarde effectuée. Fichier de log :";

        #endregion Saving

        #region Help message box

        public string MessageBoxHelpCaption { get; } = "Aide";
        public string MessageBoxHelpHelp { get; } = $"HELP !{ComonTextConstants.NewLine}{ComonTextConstants.NewLine}"
                                                  + $"Copier les fichiers de log d'Open Media Vault "
                                                  + $"dans le champ de texte. Puis cliquer sur \"Enregistrer\" pour enregistrer"
                                                  + $"le fichier dans le dossier de log. Si celui-ci est inexistant, "
                                                  + $"le fichier sera enregistré sur le bureau.{ComonTextConstants.NewLine}"
                                                  + $"Ajouter un complément de nom dans le champ d'informations.";
        public string MessageBoxHelpAbout { get; } = "À PROPOS :";
        public string MessageBoxHelpBuild { get; } = "Compilation :   ";
        public string MessageBoxHelpVersion { get; } = "Version :   ";

        #endregion Help message box

        #region Field error messages

        public string ErrorOnFieldLogContent { get; } = "Copier le log dans le champ.";
        public string ErrorOnFieldInfoName { get; } = "Écrire les informations de nom.";

        #endregion Field error messages

        #region Error on folder path

        public string ErrorCreatingFolder { get; } = "Erreur lors de la création du dossier de sauvegarde.";

        #endregion Error on folder path
    }
}

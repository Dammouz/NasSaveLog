using Common;

namespace SaveFileLogNAS.Globalization
{
   public class GuiEnglish : IGui
   {
      // Initial values
      public string InitialTextOnLogContent { get; } = "Copy logs here...";
      public string InitialTextOnInfoName { get; } = "Write informations about name here...";

      // Controls
      public string AppTitle { get; } = "Save File Log NAS";
      public string CheckBoxIsError { get; } = "Error?";
      public string ButtonSave { get; } = "Save";
      public string ButtonHelp { get; } = "?";
      public string ButtonClear { get; } = "X";

      // Tooltips
      public string AppToolTip { get; } = "Save File Log NAS";
      public string TextBoxLogContentToolTip { get; } = "Copy logs here...";
      public string TextBoxInfoNameToolTip { get; } = "Write informations about name here...";
      public string CheckBoxIsErrorToolTip { get; } = "Error?";
      public string ButtonSaveToolTip { get; } = "Save";
      public string ButtonHelpToolTip { get; } = "Help?";
      public string ButtonClearToolTip { get; } = "Clear all";

      // Saving
      public string MessageBoxLogSavedOK { get; } = "Saved OK. Log files:";

      // Help message box
      public string MessageBoxHelpCaption { get; } = "Help";
      public string MessageBoxHelpHelp { get; } = $"HELP !{CommonText.NewLine}{CommonText.NewLine}"
                                                + $"Copier les fichiers de log d'Open Media Vault "
                                                + $"dans le champ de texte. Puis cliquer sur \"Save\" pour enregistrer"
                                                + $"le fichier dans le dossier de log. Si celui-ci est inexistant, "
                                                + $"le fichier sera enregistré sur le bureau.{CommonText.NewLine}"
                                                + $"Ajouter un complément de nom dans le champ d'informations.";
      public string MessageBoxHelpAbout { get; } = "ABOUT :";
      public string MessageBoxHelpBuild { get; } = "Compilation :   ";
      public string MessageBoxHelpVersion { get; } = "Version :   ";

      // Field error messages
      public string ErrorOnFieldLogContent { get; } = "Copy log in the appropriate field.";
      public string ErrorOnFieldInfoName { get; } = "Copy informations about name in the appropriate field.";

      // Error on folder path
      public string ErrorCreatingFolder { get; } = "Error on creation of the log folder.";
   }
}

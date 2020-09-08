using System.Windows;
using System.Windows.Input;
using SaveFileLogNAS.Common;
using SaveFileLogNAS.ViewModel;

namespace SaveFileLogNAS.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SaveFileLogNASView
        : Window
    {
        public SaveFileLogNASView()
        {
            var saveFileLogNASViewModel = new SaveFileLogNASViewModel();
            InitializeComponent();
            DataContext = saveFileLogNASViewModel;
        }

        #region Behaviors

        /// <summary>
        /// Erase content when tb_logContent got focus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxLogContent_GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.TextBoxLogContent.Text.Equals(AppConstants.InitialTextOnLogContent))
            {
                this.TextBoxLogContent.Text = string.Empty;
            }
        }

        /// <summary>
        /// Erase content when tb_infoName got focus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxInfoName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.TextBoxInfoName.Text.Equals(AppConstants.InitialTextOnInfoName))
            {
                this.TextBoxInfoName.Text = string.Empty;
            }
        }

        /// <summary>
        /// Perform the click when the ENTER key is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxInfoName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.ButtonSave.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
            }
        }

        #endregion Behaviors
    }
}

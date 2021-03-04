using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using NasSaveLog.ViewModel;

namespace NasSaveLog.Views
{
    /// <summary>
    /// Interaction logic for NasSaveLogView.xaml
    /// </summary>
    public partial class NasSaveLogView : Window
    {
        public NasSaveLogView()
        {
            var viewModel = new NasSaveLogViewModel();
            InitializeComponent();
            DataContext = viewModel;
        }

        #region Behaviors

        /// <summary>
        /// Erase content when tb_logContent got focus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxLogContent_GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.TextBoxLogContent.Text.Equals(NasSaveLogViewModel.Locale.InitialTextOnLogContent))
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
            if (this.TextBoxInfoName.Text.Equals(NasSaveLogViewModel.Locale.InitialTextOnInfoName))
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
                this.ButtonSave.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }

        #endregion Behaviors
    }
}

using System;
using System.Windows;

namespace NasSaveLog.Views
{
    /// <summary>
    /// Interaction logic for App.xaml, main method
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                var app = new App();
                app.InitializeComponent();
                app.Run();
            }
        }

        protected void AppStartup(object sender, StartupEventArgs e)
        {
            this.StartupUri = new Uri($"{nameof(NasSaveLogView)}.xaml", UriKind.Relative);
        }
    }
}

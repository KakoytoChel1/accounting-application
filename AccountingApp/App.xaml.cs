using System;
using System.Windows;

namespace AccountingApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"Exception's message: {e.Exception.Message}\n\nException's details: {e.Exception.ToString()}", "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;

            Environment.FailFast("Code 'Crash'.");
        }
    }
}

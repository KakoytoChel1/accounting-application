using AccountingApp.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace AccountingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var mainPage = Application.Current.MainWindow as MainWindow;
            var mainViewModel = mainPage.DataContext as MainViewModel;

            if (trayChecked.IsChecked == false)
            {
                if (mainViewModel != null && !mainViewModel.IsListUpdating)
                {
                    e.Cancel = false;
                }
                else if(mainViewModel != null && mainViewModel.IsListUpdating)
                {
                    var res = MessageBox.Show("Are you sure you want to close the app and abort the data sync process?", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                    if(res == MessageBoxResult.OK)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            else if(trayChecked.IsChecked == true)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}

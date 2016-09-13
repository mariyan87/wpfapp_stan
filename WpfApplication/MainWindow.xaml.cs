using System.Windows;
using WpfApplication.ViewModels;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal MainWindow(MainViewModel mainViewModel)
        {
            this.InitializeComponent();

            this.ViewModel = mainViewModel;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await this.ViewModel.InitializeAsync();
        }

        internal MainViewModel ViewModel
        {
            get
            {
                return this.DataContext as MainViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
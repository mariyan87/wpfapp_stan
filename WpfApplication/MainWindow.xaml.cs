using System.Linq;
using System.Collections.Generic;
using System.Windows;
using WpfApplication.Model;
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

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            ShowFilteredData();
        }

        private void ShowFilteredData()
        {
            string searchTerm = tbSearchByName.Text.Trim();

            lvPeople.ItemsSource = ViewModel.People.Where(p => string.Compare(p.GivenName, searchTerm, true) == 0);
        }

        private void tbSearchByName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            btnSearch.IsEnabled = !string.IsNullOrWhiteSpace(tbSearchByName.Text);
        }
    }
}
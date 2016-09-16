using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApplication.Model;
using WpfApplication.Services;

namespace WpfApplication.ViewModels
{
    internal class MainViewModel: NotifyViewModelBase
    {
        private readonly PeopleService peopleService;
        private DelegateCommand<string> _filterPeopleCmd;
        private ObservableCollection<Person> _allPeople;
        private ObservableCollection<Person> _filteredPeople;
        private string _searchTerm;

        internal MainViewModel(PeopleService peopleService)
        {
               this.peopleService = peopleService;       
        }
        
        public async Task InitializeAsync()
        {
            _allPeople = new ObservableCollection<Person>(await this.peopleService.GetPeopleAsync());
            Debug.Assert(_allPeople != null && _allPeople.Any());
        }


        public ObservableCollection<Person> FilteredPeople
        {
            get { return _filteredPeople; }
            set
            {
                _filteredPeople = value;
                RaisePropertyChanged("FilteredPeople");
            }
        }

        public DelegateCommand<string> FilterPeopleCmd
        {
            get
            {
                if (null == _filterPeopleCmd)
                    _filterPeopleCmd = new DelegateCommand<string>(FilterPeople, CanFilterPeople);

                return _filterPeopleCmd;
            }
        }

        private void FilterPeople(string searchTerm)
        {
            // var results = _allPeople.Where(p => string.Compare(p.GivenName, _searchTerm, true) == 0);
            var results = _allPeople.Where(p => p.GivenName.ToLower().Contains(_searchTerm));// changed to Contains to hame more results to use busy indicator
            FilteredPeople = new ObservableCollection<Person>(results);
        }

        private bool CanFilterPeople(string searchTerm)
        {
            return !string.IsNullOrWhiteSpace(_searchTerm);
        }
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value.ToLower().Trim();
                _filterPeopleCmd.RaiseCanExecuteChanged();
            }
        }
    }
}

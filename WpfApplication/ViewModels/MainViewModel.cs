using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WpfApplication.Model;
using WpfApplication.Services;

namespace WpfApplication.ViewModels
{
    internal class MainViewModel: NotifyViewModelBase
    {
        private readonly PeopleService peopleService;

        internal MainViewModel(PeopleService peopleService)
        {
            this.peopleService = peopleService;
        }

        public async Task InitializeAsync()
        {
            _people = new ObservableCollection<Person>(await this.peopleService.GetPeopleAsync());
            Debug.Assert(_people != null && _people.Any());
        }

        private ObservableCollection<Person> _people;

        public ObservableCollection<Person> People
        {
            get { return _people; }
        }
    }
}

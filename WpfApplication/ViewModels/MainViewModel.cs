using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WpfApplication.Services;

namespace WpfApplication.ViewModels
{
    internal class MainViewModel
    {
        private readonly PeopleService peopleService;

        internal MainViewModel(PeopleService peopleService)
        {
            this.peopleService = peopleService;
        }

        public async Task InitializeAsync()
        {
            var people = await this.peopleService.GetPeopleAsync();
            Debug.Assert(people != null && people.Any());
        }
    }
}

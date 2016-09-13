using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using WpfApplication.Model;

namespace WpfApplication.Services
{
    internal class PeopleService
    {
        public Task<IEnumerable<Person>> GetPeopleAsync()
        {
            return Task.Run(async () =>
            {
                await Task.Delay(2000);
                const string fileName = @"Assets\FakeNameGenerator.com_84961f90.csv";
                var text = File.ReadAllText(fileName);
                using (var stringReader = new StringReader(text))
                {
                    var parser = new CsvReader(stringReader)
                    {
                        Configuration =
                        {
                            HasHeaderRecord = true,
                            CultureInfo = new CultureInfo("en-US")
                        }
                    };

                    // force enumeration, otherwise async clients would try reading from a closed stringReader and get an exception
                    var people = parser.GetRecords<Person>();
                    return people.ToList().AsEnumerable();
                }
            });
        }

    }
}

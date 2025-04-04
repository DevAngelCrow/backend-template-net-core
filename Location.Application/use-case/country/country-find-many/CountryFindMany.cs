using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Domain.repositories;
using Location.Domain.value_objects.country;

namespace Location.Application.use_case.country.country_find_many
{
    internal class CountryFindMany
    {
        private readonly CountryRepository repository;

        public CountryFindMany(CountryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<CountryId>?> run(IEnumerable<int> countries)
        {
            IEnumerable<CountryId> countriesIds = countries.Select(country => new CountryId(country));
            return await repository.FindMany(countriesIds);
        }
    }
}

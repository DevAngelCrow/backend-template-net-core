using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Domain.value_objects;
using Location.Domain.entities;
using Location.Domain.repositories;
using Location.Domain.value_objects.country;
using System.Diagnostics.Metrics;

namespace Location.Application.use_case.country.country_create
{
    internal class CountryCreate
    {
        private readonly CountryRepository repository;
        public CountryCreate(CountryRepository repository)
        {
            this.repository = repository;
        }
        public async Task run(string name, string abbreviation, string code, bool state)
        {
            Country country = new Country(
                new CountryId(1),
                new CountryName(name),
                new CountryAbbreviation(abbreviation),
                new CountryCode(code));

            await this.repository.Create(country);

        }
    }
}

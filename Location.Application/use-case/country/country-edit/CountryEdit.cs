using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Domain.entities;
using Location.Domain.repositories;
using Location.Domain.value_objects.country;

namespace Location.Application.use_case.country.country_edit
{
    internal class CountryEdit
    {
        private readonly CountryRepository repository;
        public CountryEdit(CountryRepository repository)
        {
            this.repository = repository;
        }

        public async Task run(int id, string name, string abbreviation, string code, bool state)
        {
            Country country = new Country(
                new CountryId(id),
                new CountryName(name),
                new CountryAbbreviation(abbreviation),
                new CountryCode(code)
                );
            await this.repository.GetOneById(country.id);

            await this.repository.Update(country);
        }
    }
}

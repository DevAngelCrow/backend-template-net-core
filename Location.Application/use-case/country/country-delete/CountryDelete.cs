using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Domain.entities;
using Location.Domain.repositories;
using Location.Domain.value_objects.country;

namespace Location.Application.use_case.country.country_delete
{
    public class CountryDelete
    {
        public readonly CountryRepository repository;

        public CountryDelete(CountryRepository repository)
        {
            this.repository = repository;
        }

        public async Task run(int id)
        {
            CountryId idCountry = new CountryId(id);

            await this.repository.GetOneById(idCountry);

            await this.repository.Delete(idCountry);

        }

    }
}

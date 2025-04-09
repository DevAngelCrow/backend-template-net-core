using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Domain.entities;
using Location.Domain.repositories;
using Location.Domain.value_objects.country;
using Shared.Domain.errors;

namespace Location.Application.use_case.country.country_get_one_by_id
{
    public class CountryGetOneById
    {
        private readonly CountryRepository repository;
        public CountryGetOneById(CountryRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Country?> run(int id)
        {
            Country? country = await this.repository.GetOneById(new CountryId(id));

            if (country == null)
            {
                throw CustomError.notFound("Country not found");
            }

            return country;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Domain.dtos.country;
using Location.Domain.entities;
using Location.Domain.repositories;

namespace Location.Application.use_case.country.country_get_all
{
    public class CountryGetAll
    {
        private readonly CountryRepository repository;

        public CountryGetAll(CountryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<PaginatedCountryDTO> run(bool pagination, int page, int per_page)
        {
            return await this.repository.GetAll(pagination, page, per_page);

        }
    }
}

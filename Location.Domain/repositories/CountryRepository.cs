using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Location.Domain;
using Location.Domain.dtos.country;
using Location.Domain.entities;
using Location.Domain.value_objects.country;

namespace Location.Domain.repositories
{
    public interface CountryRepository
    {
        public Task Create(Country country);
        public Task<PaginatedCountryDTO> GetAll(bool pagination, int page, int per_page);
        public Task<Country?> GetOneById(CountryId id);
        public Task Update(Country country);
        public Task Delete(CountryId id);
        public Task<IEnumerable<CountryId>?> FindMany(IEnumerable<CountryId> countries);
    }
}

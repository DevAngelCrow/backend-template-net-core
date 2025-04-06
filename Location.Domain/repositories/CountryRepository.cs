using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Location.Domain;
using Location.Domain.entities;
using Location.Domain.value_objects.country;

namespace Location.Domain.repositories
{
    internal interface CountryRepository
    {
        public Task Create(Country country);
        public Task<IEnumerable<Country>> GetAll();
        public Task<Country?> GetOneById(CountryId id);
        public Task Update(Country country);
        public Task Delete(CountryId id);
        public Task<IEnumerable<CountryId>?> FindMany(IEnumerable<CountryId> countries);
    }
}

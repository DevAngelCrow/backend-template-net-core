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
        Task Create(Country country);
        Task<IEnumerable<Country>> GetAll();
        Task<Country?> GetOneById(CountryId id);
        Task Update(Country country);
        Task Delete(CountryId id);
        Task<IEnumerable<CountryId>?> FindMany(IEnumerable<CountryId> countries);
    }
}

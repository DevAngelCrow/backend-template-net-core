using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Domain.entities;
using Location.Domain.value_objects.municipality;

namespace Location.Domain.repositories
{
    internal interface MunicipalityRepository
    {
        Task Create(Municipality municipality);
        Task<IEnumerable<Municipality>> GetAll();
        Task<Municipality> GetOneById(MunicipalityId id);
        Task Update(Municipality municipality);
        Task Delete(MunicipalityId id);
    }
}

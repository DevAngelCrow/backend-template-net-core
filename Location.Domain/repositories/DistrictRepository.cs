using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Domain.entities;
using Location.Domain.value_objects.district;

namespace Location.Domain.repositories
{
    internal interface DistrictRepository
    {
        Task Create(District district);
        Task<IEnumerable<District>> GetAll();
        Task<District> GetOneById(DistrictId id);
        Task Update(District district);
        Task Delete(DistrictId id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Domain.entities;
using Location.Domain.value_objects.department;

namespace Location.Domain.repositories
{
    internal interface DepartmentRepository
    {
        Task Create(Department department);
        Task<IEnumerable<Department>> GetAll();
        Task<Department?> GetOneById(DepartmentId id);
        Task Update(Department department);
        Task Delete(DepartmentId id);
    }
}

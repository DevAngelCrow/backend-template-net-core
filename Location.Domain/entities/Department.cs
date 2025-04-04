using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Domain.value_objects.department;

namespace Location.Domain.entities
{
    internal class Department
    {
        public DepartmentId id { get; set; }
        public DepartmentName name { get; set; }
        public DepartmentDescription description { get; set; }
        public DepartmentIdCountry id_country { get; set; }

        public Department(DepartmentId id, DepartmentName name, DepartmentDescription description, DepartmentIdCountry id_country)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.id_country = id_country;
        }
    }
}

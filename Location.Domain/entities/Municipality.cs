using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Domain.value_objects.municipality;

namespace Location.Domain.entities
{
    internal class Municipality
    {
        public MunicipalityId id { get; set; }
        public MunicipalityName name { get; set; }
        public MunicipalityDescription description { get; set; }
        public MunicipalityIdDepartment id_department { get; set; }

        public Municipality(MunicipalityId id, MunicipalityName name, MunicipalityDescription description, MunicipalityIdDepartment id_department)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.id_department = id_department;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Domain.value_objects.district;

namespace Location.Domain.entities
{
    internal class District
    {
        public DistrictId id { get; set; }
        public DistrictName name { get; set; }
        public DistrictDescription description { get; set; }
        public DistrictState state { get; set; }

        public District(DistrictId id, DistrictName name, DistrictDescription description, DistrictState state)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.state = state;
        }
    }
}

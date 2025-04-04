using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location.Domain.value_objects.district
{
    internal class DistrictDescription
    {
        public string? value { get; set; }
        public DistrictDescription(string value = null)
        {
            this.value = value;
        }
    }
}

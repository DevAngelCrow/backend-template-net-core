using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location.Domain.value_objects.country
{
    public class CountryId
    {
        public int id { get; set; }
        public CountryId(int id)
        {
            this.id = id;
        }
    }
}

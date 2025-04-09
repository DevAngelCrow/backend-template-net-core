using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location.Domain.value_objects.country
{
    public class CountryId
    {
        public int value { get; set; }
        public CountryId(int value)
        {
            this.value = value;
        }
    }
}

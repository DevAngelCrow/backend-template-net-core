using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Domain.errors;

namespace Location.Domain.value_objects.country
{
    public class CountryName
    {
        public string value { get; set; }

        public CountryName(string value)
        {
            this.value = value;
            required(this.value);
        }

        private void required(string value)
        {
            if (value == null) {
                throw CustomError.badRequest("The field name is required");
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Domain.errors;

namespace Location.Domain.value_objects.country
{
    internal class CountryName
    {
        public string name { get; set; }

        public CountryName(string name)
        {
            this.name = name;
            required(this.name);
        }

        private void required(string name)
        {
            throw CustomError.badRequest("The field name is required");
        }
    }
}

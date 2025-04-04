using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Domain.errors;

namespace Location.Domain.value_objects.country
{
    internal class CountryAbbreviation
    {
        public string? value { get; set; } = null;
        public CountryAbbreviation(string value)
        {
            this.value = value;
            required();
        }

        private void required()
        {
            if (string.IsNullOrEmpty(this.value))
            {
                throw CustomError.badRequest("The field abbreviation is required");
            }
        }
    }
}

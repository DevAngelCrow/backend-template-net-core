using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Domain.errors;

namespace Location.Domain.value_objects.district
{
    internal class DistrictName
    {
        public string value { get; set; }

        public DistrictName(string value)
        {
            this.value = value;
            required();

        }
        private void required()
        {
            if (string.IsNullOrEmpty(this.value))
            {
                throw CustomError.badRequest("The field description is required");
            }
        }
    }
}

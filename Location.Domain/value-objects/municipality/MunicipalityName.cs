using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Domain.errors;

namespace Location.Domain.value_objects.municipality
{
    internal class MunicipalityName
    {
        public string value { get; set; }
        public MunicipalityName(string value)
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

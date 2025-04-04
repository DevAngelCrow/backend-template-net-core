using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Domain.errors;

namespace Location.Domain.value_objects.department
{
    internal class DepartmentIdCountry
    {
        public int value { get; set; }
        public DepartmentIdCountry(int idCountry)
        {
            this.value = idCountry;
            required();
            validInteger();
        }

        private void required()
        {
            if (this.value <= 0)
            {
                throw CustomError.badRequest("The value cannot be less than 0.");
            }
        }
        private void validInteger()
        {
            if (this.value.GetType() != typeof(int))
            {
                throw CustomError.badRequest("The id country field type is not valid, it must be an integer.");
            }
        }
    }
}

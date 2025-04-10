using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Domain.errors;

namespace Location.Domain.value_objects.country
{
    public class CountryId
    {
        public int value { get; set; }
        public CountryId(int value)
        {
            this.value = value;
            this.validId();
        }

        private void validId()
        {
            if (value <= 0)
            {
                throw CustomError.badRequest("The value cannot be less than 0");
            }
        }
    }
}

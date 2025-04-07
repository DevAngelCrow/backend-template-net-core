using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Domain.errors;

namespace Location.Domain.value_objects.country
{
    public class CountryState
    {
        public bool value { get; set; }
        public CountryState(bool value)
        {
            this.value = value;
            required(this.value);
        }
        private void required(bool value)
        {
            //if (value.GetType() == typeof(bool))
            //{
            //    throw CustomError.badRequest("The field state is required");
            //}
        }
    }
}

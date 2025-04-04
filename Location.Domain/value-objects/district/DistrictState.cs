using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Domain.errors;

namespace Location.Domain.value_objects.district
{
    internal class DistrictState
    {

        public bool state { get; set; }
        public DistrictState(bool state)
        {
            this.state = state;
            required(this.state);
        }
        private void required(bool value)
        {
            if (value.GetType() == typeof(bool))
            {
                throw CustomError.badRequest("The field state is required");
            }
        }
    }
}

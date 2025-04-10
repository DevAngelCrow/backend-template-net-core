using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Domain.dtos.country;
using Location.Domain.value_objects.country;

namespace Location.Domain.entities
{
    public class Country
    {
        public CountryId id { get; set; }
        public CountryName name { get; set; }
        public CountryAbbreviation abbreviation { get; set; }
        public CountryCode code { get; set; }
        public CountryState state { get; set; }

        public Country(CountryId id, CountryName name, CountryAbbreviation abbreviation, CountryCode code, CountryState state)
        {
            this.id = id;
            this.name = name;
            this.abbreviation = abbreviation;
            this.code = code;
            this.state = state;
        }

        public CountryPrimitivesDTO mapToPrimitives()
        {
            return new CountryPrimitivesDTO()
            {
                Id = this.id.value,
                Name = this.name.value,
                Abbreviation = this.abbreviation.value,
                Code = this.code.value,
                state = this.state.value,
            };
        }
    }
}

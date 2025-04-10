using Location.Domain.dtos.country;

namespace backend_template_net_core.dtos.country
{
    public class GetAllCountryDTO
    {
        public required IEnumerable<CountryPrimitivesDTO> Countries { get; set; }
        public int? CurrentPage { get; set; }
        public int? TotalPages { get; set; }
        public int? totalItems { get; set; }
        public int? PerPage {  get; set; }
    }
}

using Location.Domain.entities;

namespace Location.Domain.dtos.country
{
    public class PaginatedCountryDTO
    {
        public required List<Country> CountryList { get; set; }
        public int? TotalPages { get; set; }
        public int? PerPage { get; set; }
        public int? Page {  get; set; }
        public int? TotalItems { get; set; }
        

    }
}

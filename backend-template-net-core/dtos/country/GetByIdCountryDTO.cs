namespace backend_template_net_core.dtos.country
{
    public class GetByIdCountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Code { get; set; }
        public bool State { get; set; }
    }
}

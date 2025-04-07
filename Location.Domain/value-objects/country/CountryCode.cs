using Shared.Domain.errors;


namespace Location.Domain.value_objects.country
{
    public class CountryCode
    {
        public string value { get; set; }
        public CountryCode(string value)
        {
            this.value = value;
            required(this.value);
        }

        public void required(string value)
        {
            if (string.IsNullOrEmpty(this.value))
            {
                throw CustomError.badRequest("The field code is required");
            }
        }


    }
}

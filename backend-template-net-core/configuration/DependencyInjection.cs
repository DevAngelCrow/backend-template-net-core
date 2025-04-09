using Location.Application.use_case.country.country_create;
using Location.Application.use_case.country.country_get_one_by_id;
using Location.Domain.repositories;
using Location.Infrastructure.implementation.countryRepository;


namespace backend_template_net_core.configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services) {

            //country
            services.AddScoped<CountryRepository, ImplCountryRepository>();
            services.AddScoped<CountryCreate>();
            services.AddScoped<CountryGetOneById>();
            return services;
        }
    }
}

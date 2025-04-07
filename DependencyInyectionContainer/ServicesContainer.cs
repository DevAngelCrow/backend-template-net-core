using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Location.Infrastructure.implementation.countryRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shared.Infrastructure.db;
using Location.Application.use_case.country;
using Location.Application.use_case.country.country_create;
using Location.Domain.repositories;

namespace DependencyInyectionContainer
{
    public static class ServicesContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {

            services.AddScoped<CountryCreate>();
            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services) { 
            services.AddScoped<CountryRepository, ImplCountryRepository>();
            return services;
        }
    }
}

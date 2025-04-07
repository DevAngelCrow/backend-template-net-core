using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Domain.entities;
using Location.Domain.repositories;
using Location.Domain.value_objects.country;
using Shared.Domain.errors;
using Shared.Infrastructure.db;
using Shared.Infrastructure.db.models;

namespace Location.Infrastructure.implementation.countryRepository
{
    internal class ImplCountryRepository : CountryRepository
    {
        private readonly ApplicationDbContext appDbContext;
        public ImplCountryRepository(ApplicationDbContext appDbContext) {
            this.appDbContext = appDbContext;
        }
        public async Task Create(Country country)
        {
            try
            {
                Console.WriteLine(country.ToString(), "Esto trae country");
                CtlCountry countryModel = new CtlCountry
                {
                    Name = country.name.value,
                    Abbreviation = country.abbreviation.value,
                    Code = country.code.value,
                    State = country.state.value,
                };

                await appDbContext.AddAsync(countryModel);
                await appDbContext.SaveChangesAsync();
            }catch{
                throw CustomError.internalServerError("Error interno en el servidor");
            }
            //throw new NotImplementedException();
        }

        public Task Delete(CountryId id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CountryId>?> FindMany(IEnumerable<CountryId> countries)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Country>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Country?> GetOneById(CountryId id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Country country)
        {
            throw new NotImplementedException();
        }
    }
}

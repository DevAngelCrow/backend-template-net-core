using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Domain.dtos.country;
using Location.Domain.entities;
using Location.Domain.repositories;
using Location.Domain.value_objects.country;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.errors;
using Shared.Infrastructure.db;
using Shared.Infrastructure.db.models;

namespace Location.Infrastructure.implementation.countryRepository
{
    internal class ImplCountryRepository : CountryRepository
    {
        private List<Country> countries = new List<Country>();
        private readonly ApplicationDbContext appDbContext;
        public ImplCountryRepository(ApplicationDbContext appDbContext) {
            this.appDbContext = appDbContext;
        }
        public async Task Create(Country country)
        {
            try
            {
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
                throw CustomError.internalServerError("Internal server error");
            }
        }

        public Task Delete(CountryId id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CountryId>?> FindMany(IEnumerable<CountryId> countries)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedCountryDTO> GetAll(bool pagination, int page, int per_page)
        {
            try
            {
                int totalCount = await appDbContext.CtlCountries.CountAsync();

                List<CtlCountry> countries = await appDbContext.CtlCountries.OrderBy(country => country.Id).Skip( (page - 1) * per_page ).Take(per_page).ToListAsync();
                
                
                this.countries = countries.Select(country => this.mapToDomain(country)).ToList();

                PaginatedCountryDTO itemsDTO = new PaginatedCountryDTO{
                    CountryList = this.countries,
                    Page = page,
                    PerPage = per_page,
                    TotalItems = totalCount,
                    TotalPages = (totalCount % per_page) == 0 ? (totalCount/per_page) : (totalCount / per_page) + 1,
                };
                PaginatedCountryDTO itemsResult = itemsDTO;
                
                return itemsResult;
                
            }
            catch {
                throw CustomError.internalServerError("Internal server error");
            }
        }

        async public Task<Country?> GetOneById(CountryId id)
        {
            try
            {

                var country = await appDbContext.CtlCountries.SingleAsync(entity => entity.Id == id.value);

                if (country == null) {
                    return null;
                }

                return this.mapToDomain(country);
            }
            catch {
                throw CustomError.internalServerError("Internal server error");
            }
            ;
        }

        public Task Update(Country country)
        {
            throw new NotImplementedException();
        }

        private Country mapToDomain(CtlCountry country) {
            return new Country(
                new CountryId(country.Id),
                new CountryName(country.Name),
                new CountryAbbreviation(country.Abbreviation),
                new CountryCode(country.Code),
                new CountryState(country.State ?? false)
                );
        }
    }
}

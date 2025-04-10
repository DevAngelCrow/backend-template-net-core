using System.Threading.Tasks;
using backend_template_net_core.dtos.country;
using Location.Application.use_case.country.country_create;
using Location.Application.use_case.country.country_get_one_by_id;
using backend_template_net_core.configuration;
using Microsoft.AspNetCore.Mvc;
using Location.Application.use_case.country.country_get_all;
using Location.Domain.entities;
using Location.Domain.dtos.country;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend_template_net_core.Controllers.location.country
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryCreate _createUseCase;
        private readonly CountryGetOneById _getOneById;
        private readonly CountryGetAll _countryGetAll;
        public CountryController(CountryCreate createUseCase, CountryGetOneById getOneById, CountryGetAll countryGetAll)
        {
            _createUseCase = createUseCase;
            _getOneById = getOneById;
            _countryGetAll = countryGetAll;
        }

        // GET: api/<CountryController>
        [HttpGet]
        public async Task<IActionResult> Get(bool pagination, int page, int per_page)
        {
            var countries = await _countryGetAll.run(pagination, page, per_page);

            List<CountryPrimitivesDTO> itemsCountry = countries.CountryList.Select(value => value.mapToPrimitives()).ToList();

            GetAllCountryDTO response = new GetAllCountryDTO()
            {
                Countries = itemsCountry,
                CurrentPage = countries?.Page,
                PerPage = countries?.PerPage,
                totalItems = countries?.TotalItems,
                TotalPages = countries?.TotalPages,
            };

            return Ok(HttpResponseCustomHelper.Success(response, "OK"));
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            
                var country = await _getOneById.run(id);
                GetByIdCountryDTO getByIdCountryDTO = new GetByIdCountryDTO()
                {
                    Id = country.id.value,
                    Name = country.name.value,
                    Abbreviation = country.abbreviation.value,
                    Code = country.code.value,
                    State = country.state.value
                };


                return Ok(HttpResponseCustomHelper.Success(getByIdCountryDTO, "Ok"));
            
            
            
        }

        // POST api/<CountryController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<object>))]
        public async Task<IActionResult> PostCountry([FromBody] CreateCountryDTO value)
        {
            try
            {
                await _createUseCase.run(value.Name, value.Abbreviation, value.Code, value.State);
                return Created("", HttpResponseCustomHelper.Created("Country created successful"));
               
            }
            catch (Exception ex) {
                return BadRequest(HttpResponseCustomHelper.CreateErrorResponse<object>(ex));
            }

            
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

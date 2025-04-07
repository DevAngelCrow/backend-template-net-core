using Location.Application.use_case.country.country_create;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend_template_net_core.Controllers.location.country
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryCreate _createUseCase;
        public CountryController(CountryCreate createUseCase)
        {
            _createUseCase = createUseCase;
        }

        // GET: api/<CountryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CountryController>
        [HttpPost]
        public async Task<IActionResult> PostCountry([FromBody] string value)
        {
           
            Console.WriteLine("esto viene");
            await _createUseCase.run("nombre", "abreviacion", "codigo", true);
            return Ok(new {message = "Pais creado con éxito"});
            //await _createUseCase.run(value.name, value.abbreviation, value, value)
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

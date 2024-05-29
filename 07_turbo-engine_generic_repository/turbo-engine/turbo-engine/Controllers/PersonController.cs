using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using turbo_engine.Model;
using turbo_engine.Business;

namespace turbo_engine.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<BookController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }        
        
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) { return BadRequest(); }
            return Ok(_personBusiness.Create(person));
        }        

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) { return BadRequest(); }
            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}

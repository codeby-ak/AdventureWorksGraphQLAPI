using AdventureWorksGraphQLAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksGraphQLAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly AdventureWorks2022Context _dbcontext;

        public PersonController(AdventureWorks2022Context dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("GetPersons")]
        public IActionResult GetPersons()
        {
            var persons = _dbcontext.Products.ToList();
            return Ok(persons);
        }
    }
}

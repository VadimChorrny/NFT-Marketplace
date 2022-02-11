using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values 
        [HttpGet, Authorize] // can will be bag
        public IEnumerable<string> Get()
        {
            return new string[] { "Secret 1", "Secret 2" };
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var houses = new List<House>
            {
                new House {Id = 1, Location = "Mechelen", Prize = 1000.00, Rooms = 5}
            };

            return Ok(houses);
        }
    }
}

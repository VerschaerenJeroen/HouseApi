using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public HouseController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<House>>> Get()
        {
            return Ok(await _dataContext.Houses.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<House>> Get(int id)
        {
            var house = await _dataContext.Houses.FindAsync(id);
            if (house == null)
                return BadRequest("House not found.");
            return Ok(house);
        }

        [HttpPost]
        public async Task<ActionResult<List<House>>> AddHouse(House house)
        {
            _dataContext.Houses.Add(house);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Houses.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<House>>> UpdateHouse(House request)
        {
            var dbHouse = await _dataContext.Houses.FindAsync(request.Id);
            if (dbHouse == null)
                return BadRequest("House not found.");

            dbHouse.Location = request.Location;
            dbHouse.Prize = request.Prize;
            dbHouse.Rooms = request.Rooms;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Houses.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<House>> Delete(int id)
        {
            var house = await _dataContext.Houses.FindAsync(id);
            if (house == null)
                return BadRequest("House not found.");

            _dataContext.Houses.Remove(house);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Houses.ToListAsync());
        }

    }
}

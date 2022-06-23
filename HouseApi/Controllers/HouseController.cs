using AutoMapper;
using HouseApi.Dtos;
using HouseApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public HouseController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<House>>> Get()
        {
            var houses = await _dataContext.Houses.ToListAsync();

            var housesDto = _mapper.Map<List<HouseDto>>(houses);
            return Ok(housesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<House>> Get(int id)
        {
            var dbHouse = await _dataContext.Houses.FindAsync(id);
            if (dbHouse == null)
                return BadRequest("House not found.");

            var houseDto = _mapper.Map<HouseDto>(dbHouse);

            return Ok(houseDto);
        }

        [HttpPost]
        public async Task<ActionResult<List<House>>> AddHouse(HouseDto houseDto)
        {
            var house = _mapper.Map<House>(houseDto);

            _dataContext.Houses.Add(house);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Houses.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<House>>> UpdateHouse(HouseDto request)
        {
            var dbHouse = await _dataContext.Houses.FindAsync(request.Id);
            if (dbHouse == null)
                return BadRequest("House not found.");

            var house = _mapper.Map<House>(request);
            dbHouse.Location = house.Location;
            dbHouse.Prize = house.Prize;
            dbHouse.Rooms = house.Rooms;

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

            var houses = await _dataContext.Houses.ToListAsync();

            var housesDto = _mapper.Map<List<HouseDto>>(houses);

            return Ok(await _dataContext.Houses.ToListAsync());
        }

    }
}

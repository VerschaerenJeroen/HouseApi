using AutoMapper;
using HouseApi.Dtos;
using HouseApi.Models;

namespace HouseApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<House, HouseDto>().ReverseMap();
        }
    }
}

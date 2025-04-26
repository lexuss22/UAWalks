using AutoMapper;
using UAWalks.API.Model.Domain;
using UAWalks.API.Model.DTO;


namespace UAWalks.API.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Region,RegionDto>().ReverseMap();
           

        }
    }
}

using AutoMapper;
using Core.Entities;
using WebApi.DTOs;
namespace WebApi.Configuration
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<ServiceObjectCrUpDto, ServiceObject>().ReverseMap();
            CreateMap<ServiceObjectBoDto, ServiceObject>().ReverseMap();
        }
    }
}

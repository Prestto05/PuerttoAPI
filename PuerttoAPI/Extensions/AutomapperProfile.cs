using AutoMapper;
using Core.Puertto;
using Infrastructure.Entities;

namespace PuerttoAPI.Extensions
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Example, ExampleEntity>().ReverseMap();

        }
    }
}

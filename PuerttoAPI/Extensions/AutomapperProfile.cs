using AutoMapper;
using Core.Puertto.DTOs.Security;
using Infrastructure.Entities;
using AuditEntity =Infrastructure.Entities.Security.Audit;
using AuditDtos = Core.Puertto.DTOs.Security.Audit;

namespace PuerttoAPI.Extensions
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<AuditDtos, AuditEntity>()
                 .ForMember(dest => dest.IdUserRegisterAudit, opt => opt.MapFrom(src => src.IdUserAudit))
                 .ForMember(dest => dest.IpPublicAudit, opt => opt.MapFrom(src => src.IpPublicAudit))
                 .ForMember(dest => dest.MacAddressAudit, opt => opt.MapFrom(src => src.MacAddressAudit))
                 .ForMember(dest => dest.LongitudeAudit, opt => opt.MapFrom(src => src.LongitudeAudit))
                 .ForMember(dest => dest.LatitudeAudit, opt => opt.MapFrom(src => src.LatitudeAudit))
                 .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment));

        }
    }
}

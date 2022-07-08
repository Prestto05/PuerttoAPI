using AutoMapper;
using Core.Puertto.DTOs.Security;
using Core.Puertto.Exceptions;
using Infrastructure.Interfaces.Security;
using PuerttoAPI.Interfaces;
using System.Net;

namespace PuerttoAPI.Services.Security
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IAuditServices _auditServices;
        private readonly IPersonaRepository  _personaRepository;
        private readonly IMapper _mapper;

        public UsuarioServices(IAuditServices auditServices, IPersonaRepository personaRepository, IMapper mapper )
        { 
            _auditServices = auditServices;
            _personaRepository = personaRepository;
            _mapper = mapper;
        }

        public async Task<RespuestaCrearComprad> RegistrarCompradorAsync(RequestRegisterComp requestRegisterComp, Audit audit)
        {
            try
            {
                var auditEntity = _mapper.Map<Infrastructure.Entities.Security.Audit>(audit);
                var response = await _personaRepository.CreateUsuarioComprador(requestRegisterComp.Email, requestRegisterComp.Password, "asdsdad", auditEntity);
                return response;
            }
            catch (Exception ex)
            {
                var friendlyMessage = "Lamentamos los inconvenientes, por favor intente de nuevo.";
                var httpStatusCode = (int)HttpStatusCode.InternalServerError;
                throw new HttpException(ex.Message, friendlyMessage, httpStatusCode, ex.InnerException);
            }
           
        }
    }
}

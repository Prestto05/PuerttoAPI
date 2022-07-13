using Core.Puertto.DTOs.Security;
using Microsoft.AspNetCore.Mvc;
using PuerttoAPI.Interfaces;

namespace PuerttoAPI.Controllers
{
    public class UsuarioController : ControllerBase
    {
        private readonly IAuditServices _auditServices;
        private readonly IUsuarioServices _usuarioServices;

        public UsuarioController(IAuditServices auditServices, IUsuarioServices usuarioServices)
        {
            _auditServices = auditServices;
            _usuarioServices = usuarioServices;
        }

        //[HttpPost("registrocomprador")]
        //public async Task<RespuestaCrearComprad> RegistroComparador([FromBody]  RequestRegisterComp requestRegister)
        //{
        //    var audit = await _auditServices.GetFieldsAuditory(HttpContext).ConfigureAwait(true);
        //    var result = await _usuarioServices.RegistrarCompradorAsync(requestRegister, audit).ConfigureAwait(true);
        //    return result;
        //}
    }
}

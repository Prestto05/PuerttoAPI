using Core.Puertto.DTOs.Security;
using Microsoft.AspNetCore.Mvc;
using PuerttoAPI.Interfaces;

namespace PuerttoAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("puertto/security")]
    public class SecurityController : ControllerBase
    {

        private readonly IAuditServices _auditServices;

        public SecurityController(IAuditServices auditServices)
        {
            _auditServices = auditServices;
        }

        //[HttpGet("Auditoria")]
        //public async Task<Audit> RetrieveAuditAsync()
        //{
        //    return await _auditServices.GetFieldsAuditory(HttpContext).ConfigureAwait(true);
        //}

    }
}

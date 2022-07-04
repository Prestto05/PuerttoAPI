using Core.Puertto.DTOs.Security;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;


        public SecurityController(IAuditServices auditServices, UserManager<IdentityUser> userManager)
        {
            _auditServices = auditServices;
            _userManager = userManager;
        }

        //[HttpGet("Auditoria")]
        //public async Task<Audit> RetrieveAuditAsync()
        //{
        //    return await _auditServices.GetFieldsAuditory(HttpContext).ConfigureAwait(true);
        //}


        //[HttpPost("singin")]

        //public async Task<LoginResponse> Login([FromBody] LoginRequest loginRequest)
        //{
        //    var user = await _userManager.FindByNameAsync(loginRequest.Correo);
        //}

    }
}

using Core.Puertto.DTOs.Security;
using Core.Puertto.Exceptions;
using PuerttoAPI.Interfaces;
using System.Net;

namespace PuerttoAPI.Services.Security
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IAuditServices _auditServices;

        public UsuarioServices(IAuditServices auditServices )
        { 
            _auditServices = auditServices;
        }

        public async Task<ReponseRegisterComp> RegistrarCompradorAsync(RequestRegisterComp requestRegisterComp, Audit audit)
        {
            try
            {
                return null;
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

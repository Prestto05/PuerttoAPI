using Core.Puertto.DTOs.Security;

namespace PuerttoAPI.Interfaces
{
    public interface IAuditServices
    {

        Task<Audit> GetFieldsAuditory(HttpContext httpContext);

    }
}

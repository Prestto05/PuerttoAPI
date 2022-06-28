using Core.Puertto.DTOs.Security;

namespace PuerttoAPI.Interfaces
{
    public interface IAudit
    {

        Task<Audit> GetFieldsAuditory(HttpContext httpContext);

    }
}

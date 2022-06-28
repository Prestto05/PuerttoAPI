using Core.Puertto.DTOs.Security;
using PuerttoAPI.Interfaces;

namespace PuerttoAPI.Services.Security
{
    public class AuditService : IAudit
    {
        public Task<Audit> GetFieldsAuditory(HttpContext httpContext)
        {
            var audit = new Audit();
            audit.IdUserAudit = int.Parse(httpContext.User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
            audit.IpPublicAudit = (string.IsNullOrEmpty(httpContext.Connection.RemoteIpAddress.ToString())) ? string.Empty: httpContext.Connection.RemoteIpAddress.ToString();


            return audit;
        }
    }
}

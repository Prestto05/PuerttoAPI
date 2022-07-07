using Core.Puertto.DTOs.Security;
using PuerttoAPI.Interfaces;

namespace PuerttoAPI.Services.Security
{
    public class AuditService : IAuditServices
    {
        public async Task<Audit> GetFieldsAuditory(HttpContext httpContext)
        {
            var audit = new Audit();
            if(httpContext.Request.Headers.TryGetValue("iduser" ,out var outIduser)) audit.IdUserAudit = int.Parse(outIduser);
            else { audit.IdUserAudit = 0; }
            audit.IpPublicAudit = (string.IsNullOrEmpty(httpContext.Connection.RemoteIpAddress.ToString())) ? string.Empty: httpContext.Connection.RemoteIpAddress.ToString();
            if (httpContext.Request.Headers.TryGetValue("macaddress", out var outmacadd)) audit.MacAddressAudit = outmacadd;
            else { audit.MacAddressAudit = string.Empty; }
            if (httpContext.Request.Headers.TryGetValue("longitude", out var outlong)) audit.LongitudeAudit = outlong;
            else { audit.LongitudeAudit = string.Empty; }
            if (httpContext.Request.Headers.TryGetValue("latitude", out var outlat)) audit.LatitudeAudit = outlat;
            else { audit.LatitudeAudit = string.Empty; }
            return audit;        
        }

    }
}

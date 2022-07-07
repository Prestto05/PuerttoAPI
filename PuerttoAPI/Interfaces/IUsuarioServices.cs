using Core.Puertto.DTOs.Security;

namespace PuerttoAPI.Interfaces
{
    public interface IUsuarioServices
    {
        Task<ReponseRegisterComp> RegistrarCompradorAsync(RequestRegisterComp requestRegisterComp, Audit audit);
    }
}

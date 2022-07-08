using Core.Puertto.DTOs.Security;

namespace PuerttoAPI.Interfaces
{
    public interface IUsuarioServices
    {
        Task<RespuestaCrearComprad> RegistrarCompradorAsync(RequestRegisterComp requestRegisterComp, Audit audit);
    }
}

using Core.Puertto.DTOs.Security;
using Infrastructure.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audit = Infrastructure.Entities.Security.Audit;

namespace Infrastructure.Interfaces.Security
{
    public interface IPersonaRepository : IAsyncRepositoryAlt<PersonEntity, Guid>
    {
        Task<RespuestaCrearComprad> CreateUsuarioComprador(string correo, string contraseña, string keyunique, Audit audit );

    }
}

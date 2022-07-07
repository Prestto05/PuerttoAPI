using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Security
{
    public class UserEntity: EntityWithAudit<Guid>
    {
        public string Correo { get; set; }

        public string Contraseña { get; set; }

        public string ClaveUnica { get; set; }

        public bool? RecuperarContraseña { get; set; }

        public string? CodigoRecuperacion { get; set; }

        public int? IdSuscripcion { get; set; }

        public EstadoUsuario  StateUser { get; set; }

        public int IdTipoUsuario { get; set; }

        public int IdPersona { get; set; }
    }

    public enum EstadoUsuario 
    {
        Active = 0,
        Inactive = 1,

    }

}

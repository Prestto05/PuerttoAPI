using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Puertto.DTOs.Security
{
    public class RequestRegisterComp
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class ReponseRegisterComp
    {
        public string Token { get; set; }

        public DateTime Expiracion { get; set; }
    }

    public class RespuestaCrearComprad
    {
        public string Id { get; set; }

        public string Correo { get; set; }
    }
}

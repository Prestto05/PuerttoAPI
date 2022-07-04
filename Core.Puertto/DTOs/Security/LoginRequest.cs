using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Puertto.DTOs.Security
{
    public class LoginRequest
    {
        public string Correo { get; set; }

        public string Contraseña { get; set; }
    }


    public class LoginResponse
    {
        public string Token { get; set; }

        public DateTime Expiracion { get; set; }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Puertto.DTOs.Security
{
    public class UserToken
    {
        public string Token { get; set; }

        public string? Email { get; set; }

        public TimeSpan Validaty { get; set; }

        public int id_usuario { get; set; }


        public string EmailId { get; set; }

        public string Rol { get; set; }

        public Guid GuidId { get; set; }

        public DateTime ExpiredTime { get; set; }

    }
}

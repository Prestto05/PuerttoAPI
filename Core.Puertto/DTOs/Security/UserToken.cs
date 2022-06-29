using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Puertto.DTOs.Security
{
    public class UserToken
    {
        public int IdUser { get; set; }

        public string? Name { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Security
{
    public class UserEntity: EntityWithAudit<Guid>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string KeyUnique { get; set; }

        public bool IsRecoverPassword { get; set; }

        public string CodeCoverPassword { get; set; }

        public int IdTypeSubscription { get; set; }

        public StateUser  StateUser { get; set; }

        public int IdTypeUser { get; set; }

        public int IdPerson { get; set; }
    }

    public enum StateUser 
    {
        Active = 0,
        Inactive = 1,

    }

}

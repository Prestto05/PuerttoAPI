using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Security
{
    public class SecurityContext :DbContext
    {
        public SecurityContext(DbContextOptions<SecurityContext> options): base(options)
        {

        }
    }
}

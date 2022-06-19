using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class ExampleEntity : Entity<Guid>
    {
        public int Number { get; set; }

        public string Data { get; set; }
    }
}

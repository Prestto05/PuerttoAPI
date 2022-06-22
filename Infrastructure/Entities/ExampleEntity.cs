using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class ExampleEntity : Entity<int>
    {
        public int Number { get; set; }

        public string Data { get; set; }
    }

    public class ValueEntity : Entity<Guid>
    {
        public int precios{ get; set; }

        public DateTime? CreateOn { get; set; }

        public int IdExample { get; set; }
    }

}

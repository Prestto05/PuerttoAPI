using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class CatalogBaseEntity : Entity<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Alias { get; set; }

        public State State { get; set; }
    }

    public enum State 
    {
        Active = 0,
        Inactive = 1
    }
}

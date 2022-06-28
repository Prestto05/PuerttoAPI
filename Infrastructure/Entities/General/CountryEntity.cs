using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.General
{
    public class CountryEntity : Entity<int>
    {
        public string Code { get; set; }

        public string CodeIso { get; set; }

        public int CodePhone { get; set; }

        public string CountryName { get; set; }
    }


    public class CityEntity : Entity<int>
    {
        public string CityName { get; set; }

        public string CodeCountry { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.General
{
    public class CategoriaGeneralEntity : Entity<int>
    {
        public string Nombre { get; set; }

        public EstadoEntity Estado { get; set; }
    }

    public class CategoriaEspecificaEntity : Entity<int>
    {
        public string Nombre { get; set; }

        public EstadoEntity Estado { get; set; }

        public int IdCategoriaGeneral { get; set; }
    }


    public class DestinoUsoEntity : Entity<int>
    {
        public string Nombre { get; set; }

        public EstadoEntity Estado { get; set; }

    }


    public class CategoriaEspecificaDestinoUsoEntity : Entity<int>
    {
        public int IdCategoriaEspecificaEntity { get; set; }

        public int IdDestinoUsoEntity { get; set; }
    }

    public class ColoresEntity : Entity<int>
    {
        public string Nombre { get; set; }

        public string Hexadecimal { get; set; }

        public EstadoEntity Estado { get; set; }
    }


    public class Bancos : CatalogBaseEntity {
    
    }


}

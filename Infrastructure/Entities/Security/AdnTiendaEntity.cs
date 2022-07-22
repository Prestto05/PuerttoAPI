using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Security
{
    public class AdnTiendaEntity : EntityWithAudit<int>
    {
        public string? Tienda { get; set; }

        public string? DescripcionTienda { get; set; }

        public int? Pais { get; set; }

        public int? Ciudad { get; set; }

        public string? Direccion { get; set; }

        public bool MasLocales { get; set; }

        public DateTime InicioActividades { get; set; }

        public string? FotoTienda { get; set; }

        public EstadoTienda Estado { get; set; }

        public Guid IdPersona { get; set; }

    }

    public enum EstadoTienda
    {
        Activo= 0,
        Inactivo = 1,
    }

    public class AdnTiendaCategoriaEntity :Entity<int>
    {
        public int IdCategoria { get; set; }

        public int IdAdnTienda { get; set; }
    }

}

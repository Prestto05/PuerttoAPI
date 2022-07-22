using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Security
{
    public class AdnPagoEntity : EntityWithAudit<int>
    {
        public string Titular { get; set; }

        public string Identificacion{ get; set; }

        public string Correo { get; set; }

        public int IdBanco { get; set; }

        public int TipoCuenta { get; set; }

        public string Cuenta { get; set; }

        public string CodigoTelefono { get; set; }

        public string Telefono { get; set; }

        public EstadoPagoAdn Estado { get; set; }

        public Guid IdPersona { get; set; }

    }

    public enum EstadoPagoAdn
    {
        Activo = 0,
        Inactivo = 1
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Puertto.DTOs.Security
{
    public class RequestRegisterAdn
    {
        public string NombresCompletos { get; set; }

        public string ApellidosCompletos { get; set; }

        public string Correo { get; set; }

        public string Contraseña { get; set; }

        public int TipoIdentificaion { get; set; }

        public string Cedula { get; set; }

        public string Ruc { get; set; }

        public string RazonSocial { get; set; }

        public int IdPais { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime InicioActividades { get; set; }

        public TiendaAdn TiendaAdn { get; set; }

        public PagosAdn Pagos { get; set; }
    }

    public class TiendaAdn
    {
        public string Tienda { get; set; }

        public string Descripcion { get; set; }

        public int IdPais { get; set; }

        public int IdCiudad { get; set; }

        public int Direccion { get; set; }

        public bool MasLocales { get; set; }

        public int Telefono { get; set; }

        public List<int> Categorias { get; set; }
    }

    public class PagosAdn
    {
        public string Titula { get; set; }

        public int TipoIdentificacion { get; set; }

        public string Cedula { get; set; }

        public string Ruc { get; set; }

        public int IdEntidadFinanciera { get; set; }

        public int IdTipoCuenta { get; set; }

        public int CuentaNo { get; set; }
    }
}

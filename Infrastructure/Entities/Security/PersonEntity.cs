using Core.Puertto.DTOs.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Security
{
    public class PersonEntity : EntityWithAudit<Guid>
    {
        public string? NombresCompletos { get; set; }   

        public string? ApellidosCompletos { get; set; }

        public int? IdGenero { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public string? Direccion { get; set; }

        public string? DireccionSecundario { get; set; }

        public int? IdTipoIdentificacion { get; set; }

        public string? Identificacion { get; set; }

        public string? RazonSocial { get; set; }

        public string? CodigoTelefono { get; set; }

        public string? Telefono { get; set; }

        public int? IdPais { get; set; }

        public string? FotoPerfil { get; set; }

        public EstadoPersona Estado { get; set; }

        public string? DescripcionPersona { get; set; }

    }

    public enum EstadoPersona
    {
        creado = 0,
        Active = 1,
        Inactive = 2,
    }
}

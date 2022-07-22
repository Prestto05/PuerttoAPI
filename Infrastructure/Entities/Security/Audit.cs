using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Security
{
    /// <summary>
    /// Campos de auditorias
    /// </summary>
    public class Audit 
    {
        /// <summary>
        /// Identificador de usario que registra una acciòn
        /// </summary>
        public string? IdUserRegisterAudit { get; set; }

        /// <summary>
        /// Fecha de creaciòn para la auditoria
        /// </summary>
        public DateTime CreateOnAudit { get; set; }

        /// <summary>
        /// Identificador de usario que modfico el registro
        /// </summary>
        public string? IdUserModifyAudit { get; set; }

        /// <summary>
        /// Fecha de modificaciòn del registro 
        /// </summary>
        public DateTime? ModifyOnAudit { get; set; }

        /// <summary>
        /// Direcciòn de protocolo (IP) del usario 
        /// </summary>
        public string? IpPublicAudit { get; set; }

        /// <summary>
        /// Identificador unico de 48 bits que corresponde de forma unica a un dispositivo
        /// </summary>
        public string? MacAddressAudit { get; set; }

        /// <summary>
        /// Valor latitud de donde se hace la acciòn
        /// </summary>
        public string? LatitudeAudit { get; set; }

        /// <summary>
        /// Valor de longitud de donde se hace la acciòn
        /// </summary>
        public string? LongitudeAudit { get; set; }

        /// <summary>
        /// Comentatitio o algun valor descriptivo
        /// </summary>
        public string? Comment { get; set; }

    }

}

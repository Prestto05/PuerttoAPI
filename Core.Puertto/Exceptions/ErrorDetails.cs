using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Puertto.Exceptions
{
    /// <summary>
    /// Detalles de Error.
    /// </summary>
    public class ErrorDetails
    {
        /// <summary>
        /// Descripción detallada del error para referencia técnica del desarrollador que consume el API.
        /// </summary>
        public string DeveloperMessage { get; set; }

        /// <summary>
        /// Mensaje amigable del error orientado al usuario final.
        /// </summary>
        public string UserMessage { get; set; }

        /// <summary>
        /// Código de estado HTTP.
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Enlace para consultar más información acerca del error.
        /// </summary>
        public string MoreInfo { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

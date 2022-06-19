using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Puertto.Exceptions
{
    /// <summary>
    /// Excepción personalizada para manejar los errores a través de toda la arquitectura de la aplicación.
    /// </summary>
    public class HttpException : Exception
    {
        /// <summary>
        /// inicializa una nueva instancia de la clase <see cref="HttpException"/>.
        /// </summary>
        /// <param name="message">Mensaje que representa la descripción real del error, destinado al desarrollador que consume el API.</param>
        /// <param name="friendlyMessage">Mensaje amigable para el usuario final.</param>
        /// <param name="statusCode">Código de estado HTTP para que el Middleware establezca correctamente la respuesta HTTP.</param>
        /// <param name="innerException">Excepción que origina el error.</param>
        public HttpException(string message, string friendlyMessage, int statusCode, Exception innerException = null) :
            base(message, innerException)
        {
            FriendlyMessage = friendlyMessage;
            StatusCode = statusCode;
        }

        /// <summary>
        /// Código de estado HTTP.
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// Mensaje amigable del error.
        /// </summary>
        public string FriendlyMessage { get; }
    }
}

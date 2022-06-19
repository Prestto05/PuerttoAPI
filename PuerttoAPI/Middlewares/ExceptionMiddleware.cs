using Core.Puertto.Exceptions;
using PuerttoAPI.Interfaces;
using System.Net;

namespace PuerttoAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ExceptionMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _configuration = configuration;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (HttpException httpEx)
            {
                await HandleHttpExceptionAsync(httpContext, httpEx).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex).ConfigureAwait(false);
            }
        }

        private static Task HandleHttpExceptionAsync(HttpContext context, HttpException httpException)
        {
            var urlBase = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}";
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = httpException.StatusCode;

            return context.Response.WriteAsync(new ErrorDetails
            {
                DeveloperMessage = httpException.Message,
                UserMessage = httpException.FriendlyMessage,
                ErrorCode = context.Response.StatusCode,
                MoreInfo = $"{urlBase}/errors/{httpException.StatusCode}"
            }.ToString());
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var urlBase = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}";
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorDetails
            {
                DeveloperMessage = exception.ToString(),
                UserMessage = "Lamentamos el inconveniente, ocurrió un error interno en nuestro servicio.",
                ErrorCode = context.Response.StatusCode,
                MoreInfo = $"{urlBase}/errors/{context.Response.StatusCode}"
            }.ToString());
        }

    }
}

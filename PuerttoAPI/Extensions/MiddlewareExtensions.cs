using Core.Puertto.DTOs.Security;
using PuerttoAPI.Middlewares;

namespace PuerttoAPI.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }     
    }
}

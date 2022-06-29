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

        //public static IApplicationBuilder UseSecurityHeadersMiddleware(this IApplicationBuilder app, SecurityHeadersBuilder builder)
        //{
        //    SecurityHeadersPolicy policy = builder.Build();
        //    return app.UseMiddleware<SecurityHeadersMiddleware>(policy);
        //}
    }
}

using Infrastructure.Context.General;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace PuerttoAPI.Extensions
{
    public static class WebHostExtensions 
    {
        public static IHost SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var factoryGeneral = services.GetService<Func<GeneralContext>>();
                using var contextGeneral = factoryGeneral();
                //var factorySecurity = services.GetService<Func<SecurityContext>>();
                //using var contextSecurity = factorySecurity();
                //FtlContextSeed.EnsurePopulatedAsync(context).Wait();
            }
            return host;
        }
    }



}

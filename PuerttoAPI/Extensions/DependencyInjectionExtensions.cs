using PuerttoAPI.Interfaces;
using PuerttoAPI.Services;

namespace PuerttoAPI.Extensions
{
    public static class DependencyInjectionExtensions
    {

        public static void InjectApiServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IExample, ExampleServices>();
        }

        public static void InjectRepositoriesDependencies(this IServiceCollection services)
        {
        }
    }
}

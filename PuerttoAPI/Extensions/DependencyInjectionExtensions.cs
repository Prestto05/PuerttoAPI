using AutoMapper;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

using PuerttoAPI.Interfaces;
using PuerttoAPI.Services;
using PuerttoAPI.Services.General;
using PuerttoAPI.Services.Security;

namespace PuerttoAPI.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void InjectAutomapperService(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile(new AutomapperProfile()); });
            var mapper = config.CreateMapper();
            services.AddSingleton<IMapper>(mapper);
        }

        public static void InjectApiServicesDependencies(this IServiceCollection services)
        {           
            services.AddScoped<IGeneralServices, GeneralServices>();
            services.AddScoped<IAuditServices, AuditService>();
            services.AddScoped<IUsuarioServices, UsuarioServices>();
        }

        public static void InjectRepositoriesDependencies(this IServiceCollection services)
        {
           // services.AddTransient<IExaampleRepository, ExampleRepository>();
        }
    }
}

using Infrastructure.Context.General;
using Infrastructure.Context.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace PuerttoAPI.Extensions
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IHostBuilder _hostBuilder  { get; set; }

        public Startup(IConfiguration configuration )
        {
            Configuration = configuration;
       
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services, IHostBuilder host)
        {
           
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNameCaseInsensitive = true)
                .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddSwagger();



            //services.BuildServiceProvider().CreateScope().ServiceProvider.GetRequiredService<GeneralContext>();


            // DI
            //services.AddHttpContextAccessor();
            ConfigureDatabaseServices(services);


            services.AddSingleton<IConfiguration>(Configuration);
            services.InjectAutomapperService();
            services.InjectRepositoriesDependencies();
            services.InjectApiServicesDependencies();
            
            //host.Build().SeedData();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.ConfigureCustomLoggingMiddleware();

            app.ConfigureCustomExceptionMiddleware();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCustomSwagger();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureDatabaseServices(IServiceCollection services)
        {
            var generalConnection = Configuration.GetConnectionString("GeneralConnection");
            var securityConnection = Configuration.GetConnectionString("SecurityConnection");


            services.AddDbContextFactory<GeneralContext>(options => options
                .UseLazyLoadingProxies(false)
                .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning))
                .UseMySql(generalConnection, ServerVersion.AutoDetect(generalConnection),
                    opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(15).TotalSeconds)).EnableSensitiveDataLogging());

            services.AddDbContextFactory<GeneralContext>(options => options
               .UseLazyLoadingProxies(false)
               .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning))
               .UseMySql(securityConnection, ServerVersion.AutoDetect(securityConnection),
                   opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(15).TotalSeconds)).EnableSensitiveDataLogging());

        }

    }

}
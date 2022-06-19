using Infrastructure.Context.General;
using Infrastructure.Context.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json.Serialization;

namespace PuerttoAPI.Extensions
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc(options => options.EnableEndpointRouting = true)
            //    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            //    .AddFluentValidation(o =>
            //    {
            //        o.RegisterValidatorsFromAssemblyContaining<InstitutionValidator>();
            //        o.RegisterValidatorsFromAssemblyContaining<ProductValidator>();
            //        o.RegisterValidatorsFromAssemblyContaining<OperationsCriteriaValidator>();
            //        o.RegisterValidatorsFromAssemblyContaining<ExtendedPropertiesValidator>();
            //        o.RegisterValidatorsFromAssemblyContaining<OperationCriteriaTypeValidator>();
            //        o.ImplicitlyValidateChildProperties = true;
            //    });


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
            

           ConfigureDatabaseServices(services);

            // DI
            services.AddSingleton<IConfiguration>(Configuration);
            //services.InjectAutomapperService();
            //services.InjectRepositoriesDependencies();
            //services.InjectServiceAdaptersDependencies();
            services.InjectApiServicesDependencies();
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
            services.AddDbContextFactory<GeneralContext>(options => options
                .UseLazyLoadingProxies(false)
                .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning))
                .UseMySQL(Configuration.GetConnectionString("GeneralConnection"),
                    opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(15).TotalSeconds)).EnableSensitiveDataLogging());
        }

    }

}


//Configuration.GetConnectionString("GeneralConnection")
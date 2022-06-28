using Infrastructure.Context.General;
using Infrastructure.Context.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Text;

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

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer( x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration.GetValue<string>("Jwt:Issuer"),
                    ValidAudience = Configuration.GetValue<string>("Jwt:Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Jwt:Key")))
                };

            });

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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureDatabaseServices(IServiceCollection services)
        {
            var generalConnection = Configuration.GetConnectionString("GeneralConnection");
            var securityConnection = Configuration.GetConnectionString("SecurityConnection");
            var logisitcsConnection = Configuration.GetConnectionString("LogisticsConnection");
            var financialConnection = Configuration.GetConnectionString("FinancialConnection");
            var inventarioConnection = Configuration.GetConnectionString("InventarioConnection");


            services.AddDbContextFactory<GeneralContext>(options => options
                .UseLazyLoadingProxies(false)
                .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning))
                .UseMySql(generalConnection, ServerVersion.AutoDetect(generalConnection),
                    opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(15).TotalSeconds)).EnableSensitiveDataLogging());

            services.AddDbContextFactory<SecurityContext>(options => options
               .UseLazyLoadingProxies(false)
               .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning))
               .UseMySql(securityConnection, ServerVersion.AutoDetect(securityConnection),
                   opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(15).TotalSeconds)).EnableSensitiveDataLogging());

            services.AddDbContextFactory<SecurityContext>(options => options
              .UseLazyLoadingProxies(false)
              .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning))
              .UseMySql(securityConnection, ServerVersion.AutoDetect(securityConnection),
                  opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(15).TotalSeconds)).EnableSensitiveDataLogging());

            services.AddDbContextFactory<SecurityContext>(options => options
              .UseLazyLoadingProxies(false)
              .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning))
              .UseMySql(securityConnection, ServerVersion.AutoDetect(securityConnection),
                  opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(15).TotalSeconds)).EnableSensitiveDataLogging());

            services.AddDbContextFactory<SecurityContext>(options => options
              .UseLazyLoadingProxies(false)
              .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning))
              .UseMySql(securityConnection, ServerVersion.AutoDetect(securityConnection),
                  opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(15).TotalSeconds)).EnableSensitiveDataLogging());

        }

    }

}
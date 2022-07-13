using Core.Puertto.Extensions;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace PuerttoAPI.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Title = "Recurso Transaccional de Compar y Venta API",
                    Version = "v1.0",
                    Description =
                        @"recurso logistico para la compra y venta de productos a traves de Puertto.",
                    TermsOfService = new System.Uri("https://www.google.com"),
                    Contact = new OpenApiContact() { Name = "Prestto", Email = "sistemas.prestto05@gmail.com" }
                });
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

               //options.OperationFilter<CustomHeaderSwaggerAttribute>();

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });

                // Get xml comments path
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                var xmlModePath = Path.Combine(AppContext.BaseDirectory, "Core.Puertto.xml");

                // Set xml path
                options.IncludeXmlComments(xmlPath, true);
                options.IncludeXmlComments(xmlModePath, true);
                options.EnableAnnotations();

                // UseFullTypeNameInSchemaIds replacement for .NET Core
                //options.CustomSchemaIds(x => x.FullName);
                //options.ExampleFilters();

                options.CustomSchemaIds(currentClass =>
                {
                    if (currentClass.IsGenericType && currentClass.Name.Contains("DomainEntityList"))
                    {
                        string returnedValue = $"{currentClass.GenericTypeArguments.First().Name}List";
                        return returnedValue;
                    }
                    return currentClass.Name;
                });
            });
            //services.AddSwaggerExamples();
            //services.AddSwaggerExamplesFromAssemblyOf<Institution>();
            //services.AddSwaggerExamplesFromAssemblyOf<Product>();
            //services.AddSwaggerExamplesFromAssemblyOf<OperationCriteria>();
            //services.AddSwaggerExamplesFromAssemblyOf<OperationCriteriaType>();
            //services.AddSwaggerExamplesFromAssemblyOf<ExtendedProperty>();
        }
        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Arquitectura transaccional Puertto API V1.0");
            });
        }
    }
}

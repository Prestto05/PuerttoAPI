using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Puertto.Extensions
{
    public class CustomHeaderSwaggerAttribute : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();


            var listpParamterBase = new List<OpenApiParameter>()
            {
                new OpenApiParameter()
                {
                    Name ="iduser",
                    In = ParameterLocation.Header,
                    Required = false,
                    Schema = new OpenApiSchema{ Type = "string"}
                },
                new OpenApiParameter()
                {
                    Name ="token",
                    In = ParameterLocation.Header,
                    Required = false,
                    Schema = new OpenApiSchema{ Type = "string"}
                },
                new OpenApiParameter()
                {
                    Name ="macaddress",
                    In = ParameterLocation.Header,
                    Required = false,
                    Schema = new OpenApiSchema{ Type = "string"}
                },
                new OpenApiParameter()
                {
                    Name ="longitude",
                    In = ParameterLocation.Header,
                    Required = false,
                    Schema = new OpenApiSchema{ Type = "string"}
                },
                new OpenApiParameter()
                {
                    Name ="latitude",
                    In = ParameterLocation.Header,
                    Required = false,
                    Schema = new OpenApiSchema{ Type = "string"}
                }
            };
            operation.Parameters = listpParamterBase;
        }
    }
}

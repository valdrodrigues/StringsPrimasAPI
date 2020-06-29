using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace TesteExercicioDois.Infra.CrossCutting.Swagger
{
    public class SwaggerConfig
    {
        public static void UseSwagger(IApplicationBuilder app, string versionName = "v1", string apiName = "API teste Inventti")
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"swagger/{versionName}/swagger.json", apiName);
                c.RoutePrefix = string.Empty;
            });
        }

        public static void AddSwagger(IServiceCollection services, string runningAssemblyName, Info info)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(info.Version, info);

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{runningAssemblyName}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}

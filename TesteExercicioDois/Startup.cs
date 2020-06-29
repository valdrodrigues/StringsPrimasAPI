using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using TesteExercicioDois.Infra.CrossCuttin.IoC;
using TesteExercicioDois.Infra.CrossCutting.Swagger;

namespace TesteExercicioDois
{
    public class Startup
    {
        private const string SwaggerVersionName = "v1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            InjectorConfig.RegisterServices(services);

            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            var info = new Info
            {
                Version = SwaggerVersionName,
                Title = "API teste Inventti",
                Description = "API para testar strings primas",
            };

            SwaggerConfig.AddSwagger(services, assemblyName, info);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(builder =>
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            );

            SwaggerConfig.UseSwagger(app, SwaggerVersionName);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

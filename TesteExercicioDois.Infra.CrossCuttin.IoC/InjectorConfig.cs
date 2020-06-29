using Microsoft.Extensions.DependencyInjection;
using System;
using TesteExercicioDois.Application;
using TesteExercicioDois.Application.Service;
using TesteExercicioDois.Domain.IApplication;

namespace TesteExercicioDois.Infra.CrossCuttin.IoC
{
    public class InjectorConfig
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient(typeof(Lazy<>), typeof(Lazier<>));

            //Application
            services.AddScoped<ValidacaoStringPrimaApplication>();

            //Service
            services.AddScoped<IValidacaoStringPrimaService, ValidacaoStringPrimaService>();
        }
    }
}

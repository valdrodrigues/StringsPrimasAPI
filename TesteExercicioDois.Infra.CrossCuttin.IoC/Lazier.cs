using Microsoft.Extensions.DependencyInjection;
using System;

namespace TesteExercicioDois.Infra.CrossCuttin.IoC
{
    public class Lazier<T> : Lazy<T> where T : class
    {
        public Lazier(IServiceProvider provider) : base(() => provider.GetRequiredService<T>())
        { }
    }
}

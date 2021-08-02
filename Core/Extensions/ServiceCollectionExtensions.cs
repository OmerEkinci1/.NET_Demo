using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // Burası void değil IServiceCollection dönüyodu.
        public static void AddDependencyResolvers(this IServiceCollection serviceCollection, IConfiguration configuration, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            //return ServiceTool.Create(serviceCollection);
        }
    }
}

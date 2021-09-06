using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers.Autofac
{
    public class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            // Ninject Usage
            // var kernel = new StandartKernel(new AutofacBusinessModule());
            //return builder.Get<T>();
            var builder = new ContainerBuilder();
            return (T)builder.RegisterType<T>();
        }
    }
}

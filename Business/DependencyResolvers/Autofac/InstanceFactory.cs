using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new ContainerBuilder(new AutofacBusinessModule());
            return kernel.Get<T>();
        }
    }
}

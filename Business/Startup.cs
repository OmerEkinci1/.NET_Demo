﻿using Autofac;
using Business.Constants;
using Business.DependencyResolvers.Autofac;
using Business.Fakes.DArch;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Business
{
    public partial class BusinessStartup
    {
        public BusinessStartup(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            HostEnvironment = hostEnvironment;
        }

        public IConfiguration Configuration { get; }

        protected IHostEnvironment HostEnvironment { get; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            Func<IServiceProvider, ClaimsPrincipal> getPrincipal = (sp) =>
                sp.GetService<IHttpContextAccessor>().HttpContext?.User ??
                new ClaimsPrincipal(new ClaimsIdentity(Messages.Unknown));

            services.AddScoped<IPrincipal>(getPrincipal);
            services.AddMemoryCache();

            var coreModule = new CoreModule();

            services.AddDependencyResolvers(Configuration, new ICoreModule[] { coreModule });

            services.AddSingleton<ConfigurationManager>();

            ValidatorOptions.Global.DisplayNameResolver = (type, memberInfo, expression) =>
            {
                return memberInfo.GetCustomAttribute<System.ComponentModel.DataAnnotations.DisplayAttribute>()
                    ?.GetName();
            };
        }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            ConfigureServices(services);

            services.AddTransient<IIntegrationDal, EfIntegrationDal>();

            services.AddDbContext<ProjectDbContext, DArchInMemory>(ServiceLifetime.Transient);
        }

        public void ConfigureStagingServices(IServiceCollection services)
        {
            ConfigureServices(services);

            services.AddTransient<IIntegrationDal, EfIntegrationDal>();
            //services.AddDbContext<PostgresqlDbContext>();

            services.AddDbContext<ProjectDbContext,MsDbContext>();
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            ConfigureServices(services);

            services.AddTransient<IIntegrationDal, EfIntegrationDal>();

            //services.AddDbContext<ProjectDbContext>();

            services.AddDbContext<ProjectDbContext, MsDbContext>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacBusinessModule(new ConfigurationManager(Configuration, HostEnvironment)));
        }
    }
}

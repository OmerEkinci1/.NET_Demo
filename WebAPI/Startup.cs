using Business;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
            : base(configuration, hostEnvironment)
        {

        }

        //public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowOrigin",
            //        builder => builder.WithOrigins("http://localhost:4200"));
            //});

            //services.AddDependencyResolvers(new ICoreModule[] {
            //    new CoreModule()
            //});

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });


            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            //services.AddTransient<FileLogger>();
            //services.AddTransient<PostgreSqlLogger>();
            //services.AddTransient<MsSqlLogger>();

            //base.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            ServiceTool.ServiceProvider = app.ApplicationServices;

            var configurationManager = app.ApplicationServices.GetService<ConfigurationManager>();
            switch (configurationManager.Mode)
            {
                case ApplicationMode.Development:
                    //app.UseDbFakeDataCreator();
                    //break;

                case ApplicationMode.Profiling:
                case ApplicationMode.Staging:

                    break;
                case ApplicationMode.Production:
                    break;
            }
            

            app.UseDeveloperExceptionPage();

            app.ConfigureCustomExceptionMiddleware();

            app.UseCors("AllowOrigin");

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthentication();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

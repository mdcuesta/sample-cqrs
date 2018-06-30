using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sampler.CQRS.Core;
using StructureMap;

namespace Sampler.CQRS.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        private IServiceCollection ServiceCollection { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton(Configuration);

            ServiceCollection = services;
        }

        public void ConfigureContainer(Registry registry)
        {
            // Use StructureMap-specific APIs to register services in the registry.
            registry.Scan(_ =>
            {
                _.AssembliesAndExecutablesFromApplicationBaseDirectory();
                _.AddAllTypesOf<IDependencyConfig>();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            IEnumerable<IDependencyConfig> dependencyConfigs = app.ApplicationServices.GetServices<IDependencyConfig>();

            foreach(IDependencyConfig dependencyConfig in dependencyConfigs)
            {
                dependencyConfig.Configure(ServiceCollection);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //app.UseAuthentication();
            app.UseMvc();
        }
    }
}

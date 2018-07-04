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

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton(Configuration);

            var container = new Container();

            container.Configure(config =>
            {
                var registry = new Registry();
                registry.Scan(_ =>
                {
                    _.AssembliesAndExecutablesFromApplicationBaseDirectory();

                    // Default Convention
                    _.WithDefaultConventions();

                    // Register all Dependency Configurations
                    _.AddAllTypesOf<IDependencyConfig>();

                    // Register all Initializers
                    _.AddAllTypesOf<IInitializer>();

                    // Register all CommandHandlers
                    _.AddAllTypesOf(typeof(ICommandHandler<>));

                    // Register all QueryHandlers
                    _.AddAllTypesOf(typeof(IQueryHandler<,>));

                    // Register all MessageHandlers
                    _.AddAllTypesOf(typeof(IMessageHandler<>));
                });
                config.AddRegistry(registry);
            });

            // Load DependencyConfigurations and Execute
            IEnumerable<IDependencyConfig> dependencyConfigs = container.GetAllInstances<IDependencyConfig>();

            foreach (IDependencyConfig dependencyConfig in dependencyConfigs)
            {
                dependencyConfig.Configure(services);
            }

            container.Populate(services);

            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Load Initializers and Execute
            IEnumerable<IInitializer> initializers = app.ApplicationServices.GetServices<IInitializer>();

            foreach(IInitializer initializer in initializers)
            {
                initializer.Init();
            }

            // .NET Core MVC Specifics

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

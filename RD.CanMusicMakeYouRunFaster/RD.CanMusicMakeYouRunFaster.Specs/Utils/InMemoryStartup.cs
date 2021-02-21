namespace RD.CanMusicMakeYouRunFaster.Specs.Utils
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer;
    using RD.CanMusicMakeYouRunFaster.Rest.Controllers;

    /// <summary>
    /// Startup for the InMemory version of the FakeResponseServer.
    /// </summary>
    public class InMemoryStartup
    {
        private readonly Startup startup;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryStartup"/> class.
        /// </summary>
        /// <param name="config"> InMemory server configuration. </param>
        public InMemoryStartup(IConfiguration config)
        {
            startup = new Startup(config);
        }

        /// <summary>
        /// Method is called by the runtime. Used to add services to the container
        /// </summary>
        /// <param name="services"> Services to configure. </param>
        public void ConfigureServices(IServiceCollection services)
        {
            var externalApiController = typeof(ExternalAPIGateway).Assembly;

            services.AddControllers()
                .AddApplicationPart(externalApiController);

            startup.ConfigureServices(services);
        }

        /// <summary>
        /// Used to configure HTTP request pipeline.
        /// </summary>
        /// <param name="app">the builder for the app</param>
        /// <param name="env">the hosting environment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            startup.Configure(app, env);
        }
    }
}

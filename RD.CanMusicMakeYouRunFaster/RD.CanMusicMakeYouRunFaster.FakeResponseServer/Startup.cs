namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// File used to dictate the properties of the web API.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration"> The API configuration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the API Configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Method called by the runtime. Use this to add services to the container.
        /// </summary>
        /// <param name="services"> Services to configure. </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        /// <summary>
        /// Method called by the runtime. Use this to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"> The application to configure. </param>
        /// <param name="env"> The environment to configure. </param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

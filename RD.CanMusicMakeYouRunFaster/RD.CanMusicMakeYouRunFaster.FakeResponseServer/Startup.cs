namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer
{
    using DbContext;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Class used to dictate startup properties of the FakeResponseServer.
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
        /// Method called by the runtime. Used to add services to the container.
        /// </summary>
        /// <param name="services"> Services to configure. </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataRetrievalContext>(opt => opt.UseInMemoryDatabase("FakeResponseServerDb"));
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddControllers()
                .ConfigureApiBehaviorOptions(opt => { opt.SuppressModelStateInvalidFilter = true; });
        }

        /// <summary>
        /// Method called by the runtime. Used to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"> The application used to configure. </param>
        /// <param name="env"> The environment used to configure. </param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
}

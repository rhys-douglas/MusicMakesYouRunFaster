namespace RD.CanMusicMakeYouRunFaster.CommonTestUtils.Factories
{
    using System;
    using System.Net.Http;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.DbContext;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    /// <summary>
    /// Factory class to create in-memory backend.
    /// </summary>
    /// <typeparam name="TStartup">Start up type (InMemory or fake server)</typeparam>
    public class InMemoryFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        private readonly string databaseName;
        private readonly InMemoryDatabaseRoot databaseRoot;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryFactory{TStartup}"/> class.
        /// </summary>
        /// <param name="databaseName"> Name of the database. </param>
        /// <param name="databaseRoot"> Database root path. </param>
        public InMemoryFactory(string databaseName, InMemoryDatabaseRoot databaseRoot)
        {
            this.databaseName = databaseName;
            this.databaseRoot = databaseRoot;
        }

        /// <summary>
        /// Creates an HttpClient instance with the base address
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        /// <returns>Http Client instance</returns>
        public HttpClient CreateClient(string baseAddr)
        {
            return CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false,
                BaseAddress = new Uri(baseAddr)
            });
        }

        /// <inheritdoc/>
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.RemoveAll<DbContextOptions<DataRetrievalContext>>();
                services.AddDbContext<DataRetrievalContext>(options =>
                {
                    options.UseInMemoryDatabase(databaseName, databaseRoot);
                });
            });
        }

        /// <inheritdoc/>
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(x =>
                {
                    x.UseStartup<TStartup>().UseTestServer();
                });
            return builder;
        }
    }
}

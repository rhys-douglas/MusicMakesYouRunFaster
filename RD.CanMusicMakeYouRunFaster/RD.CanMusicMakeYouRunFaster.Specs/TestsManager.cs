namespace RD.CanMusicMakeYouRunFaster.Specs
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using BoDi;
    using ClientDrivers;
    using DataSource;
    using FakeResponseServer.DbContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Factories;
    using RD.CanMusicMakeYouRunFaster.Rest.Gateways;
    using RD.CanMusicMakeYouRunFaster.Specs.Utils;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Class to set up, tear down and manage specs tests.
    /// </summary>
    [Binding]
    public class TestsManager
    {
        private const string DatabaseName = "SpecsDatabase";
        private static IClientDriver clientDriver;
        private static DbContextOptions<DataRetrievalContext> contextOptions;
        private static InMemoryDatabaseRoot databaseRoot;

        /// <summary>
        /// Set up precursors to testing.
        /// </summary>
        /// <param name="objectContainer"> Object container </param>
        [BeforeTestRun]
        public static void TestSetup(IObjectContainer objectContainer)
        {
            HttpClient httpClient;
            // Set up back end DB
            databaseRoot = new InMemoryDatabaseRoot();
            contextOptions = new DbContextOptionsBuilder<DataRetrievalContext>()
                .UseInMemoryDatabase(DatabaseName, databaseRoot).Options;
            // Set up InMemory http client.
            var webAppFactory = new InMemoryFactory<InMemoryStartup>(DatabaseName, databaseRoot);
            httpClient = webAppFactory.CreateClient(TestsConfiguration.FakeResponseServerUrl);

            var spotifyClient = new SpotifyClient(httpClient, TestsConfiguration.FakeResponseServerUrl);

            var externalAPIGateway = new ExternalAPIGateway(spotifyClient);

            var dataSource = new FakeDataSource(contextOptions, spotifyClient);

            clientDriver = new ApiClientDriver();
            clientDriver.SetUp();

            objectContainer.RegisterInstanceAs<IClientDriver>(clientDriver);
            objectContainer.RegisterInstanceAs(dataSource);

            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
    }
}

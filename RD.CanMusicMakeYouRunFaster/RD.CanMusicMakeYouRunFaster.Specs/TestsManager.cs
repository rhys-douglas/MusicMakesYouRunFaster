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
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers;
    using TechTalk.SpecFlow;
    using RD.CanMusicMakeYouRunFaster.CommonTestUtils.Factories;

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
            databaseRoot = new InMemoryDatabaseRoot();
            contextOptions = new DbContextOptionsBuilder<DataRetrievalContext>()
                .UseInMemoryDatabase(DatabaseName, databaseRoot).Options;
            var webAppFactory = new InMemoryFactory<FakeResponseServer.Startup>(DatabaseName, databaseRoot);
            httpClient = webAppFactory.CreateClient("http://localhost:2222");

            var spotifyClient = new ExternalAPICaller(httpClient);

            var dataSource = new DataPort(contextOptions, spotifyClient);

            clientDriver = new ApiClientDriver();
            clientDriver.SetUp(dataSource.ExternalAPIGateway);

            objectContainer.RegisterInstanceAs<IClientDriver>(clientDriver);
            objectContainer.RegisterInstanceAs(dataSource);

            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        [AfterScenario]
        public static void TearDown(DbContextOptions<DataRetrievalContext> contextOptions)
        {
            using var context = new DataRetrievalContext(contextOptions);
        }
    }
}

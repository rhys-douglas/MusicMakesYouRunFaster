namespace RD.CanMusicMakeYouRunFaster.Rest.UnitTests.ControllerTests
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.Rest.Gateways;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources;
    using System.Net.Http;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.EntityFrameworkCore;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.DbContext;
    using RD.CanMusicMakeYouRunFaster.CommonTestUtils.Factories;

    public class ExternalAPIGatewayTests
    {
        private ExternalAPIGateway sut;
        private const string DatabaseName = "FakeExternalAPIGatewayDatabase";
        private DbContextOptions<DataRetrievalContext> contextOptions;
        private const string FakeServerAddress = "http://localhost:2222";

        [OneTimeSetUp]
        public void SetUpTests()
        {
            HttpClient httpClient;
            var databaseRoot = new InMemoryDatabaseRoot();
            contextOptions = new DbContextOptionsBuilder<DataRetrievalContext>()
                    .UseInMemoryDatabase(DatabaseName, databaseRoot)
                    .Options;

            var webAppFactory = new InMemoryFactory<FakeResponseServer.Startup>(DatabaseName, databaseRoot);
            httpClient = webAppFactory.CreateClient(FakeServerAddress);

            var dataSource = new FakeDataRetrievalSource(new SpotifyClient(httpClient), FakeServerAddress);
            sut = new ExternalAPIGateway(dataSource);
        }

        [Test]
        public void GetSpotifyAuthenticationToken_AuthenticationTokenReturned()
        {
            var tokenAsJson = sut.GetSpotifyAuthenticationToken();
            tokenAsJson.Value.Should().NotBeNull();
            var spotifyAuthToken = JsonConvert.DeserializeObject<SpotifyAuthenticationToken>((string)tokenAsJson.Value);
            spotifyAuthToken.AccessToken.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void GetSpotifyRecentlyPlayed_ListeningHistoryReturned()
        {
            var listeningHistory = sut.GetSpotifyRecentlyPlayed();
            listeningHistory.Should().NotBeNull();
        }
    }
}
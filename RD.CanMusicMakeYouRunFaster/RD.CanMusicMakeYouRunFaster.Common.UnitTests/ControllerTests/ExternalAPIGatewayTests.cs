namespace RD.CanMusicMakeYouRunFaster.Rest.UnitTests.ControllerTests
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.Rest.Gateways;
    using RD.CanMusicMakeYouRunFaster.Rest.DTO;
    using RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources;

    public class ExternalAPIGatewayTests
    {
        private ExternalAPIGateway sut;

        [OneTimeSetUp]
        public void SetUpTests()
        {
            var dataSource = new FakeDataRetrievalSource();
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
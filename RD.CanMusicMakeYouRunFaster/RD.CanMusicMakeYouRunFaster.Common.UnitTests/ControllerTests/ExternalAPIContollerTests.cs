namespace RD.CanMusicMakeYouRunFaster.Rest.UnitTests.ControllerTests
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.Rest.Controllers;
    using RD.CanMusicMakeYouRunFaster.Rest.DTO;

    public class ExternalAPIContollerTests
    {
        private ExternalAPIController sut;

        [OneTimeSetUp]
        public void SetUpTests()
        {
            sut = new ExternalAPIController();
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
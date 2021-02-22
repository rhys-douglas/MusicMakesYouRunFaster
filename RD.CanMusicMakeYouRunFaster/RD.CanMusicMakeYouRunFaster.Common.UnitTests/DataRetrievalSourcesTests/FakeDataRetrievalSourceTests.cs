namespace RD.CanMusicMakeYouRunFaster.Rest.UnitTests.DataRetrievalSourcesTests
{
    using DataRetrievalSources;
    using DTO;
    using FluentAssertions;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers;

    public class FakeDataRetrievalSourceTests
    {
        private SpotifyAuthenticationToken authenticationToken;
        private IDataRetrievalSource sut;

        [OneTimeSetUp]
        public void SetUpTests()
        {
            var spotifyClient = new SpotifyClient();
            sut = MakeSut();
            var oauthToken = sut.GetSpotifyAuthenticationToken();
            oauthToken.Result.Should().NotBeNull();
            oauthToken.Result.Value.Should().NotBe(string.Empty);
            authenticationToken = JsonConvert.DeserializeObject<SpotifyAuthenticationToken>((string)oauthToken.Result.Value);
            authenticationToken.AccessToken.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void GetSpotifyListeningHistory_ListeningHistoryRetrieved()
        {
            var listeningHistory = sut.GetSpotifyRecentlyPlayed(authenticationToken);
            listeningHistory.Result.Value.Should().NotBeNull();
            listeningHistory.Result.Value.Should().NotBe(string.Empty);
        }

        [Test]
        public void GetSpotifyListeningHistoryWithInvalidAuthToken_ExceptionThrown()
        {
            var listeningHistory = sut.GetSpotifyRecentlyPlayed(new SpotifyAuthenticationToken()) ;
            listeningHistory.Result.Value.Should().NotBeNull();
            listeningHistory.Result.Value.Should().NotBe(string.Empty);
        }

        private FakeDataRetrievalSource MakeSut()
        {
            return new FakeDataRetrievalSource();
        }
    }
}

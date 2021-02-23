namespace RD.CanMusicMakeYouRunFaster.Rest.UnitTests.DataRetrievalSourcesTests
{
    using DataRetrievalSources;
    using FluentAssertions;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;

    public class RealDataRetrievalSourceTests
    {
        private SpotifyAuthenticationToken authenticationToken;
        private IDataRetrievalSource sut;

        [OneTimeSetUp]
        public void SetUpTests()
        {
            sut = new RealDataRetrievalSource();
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
    }
}

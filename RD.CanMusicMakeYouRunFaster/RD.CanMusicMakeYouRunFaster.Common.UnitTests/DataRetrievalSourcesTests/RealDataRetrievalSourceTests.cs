namespace RD.CanMusicMakeYouRunFaster.Rest.UnitTests.DataRetrievalSourcesTests
{
    using FluentAssertions;
    using RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources;

    public class RealDataRetrievalSourceTests
    {
        [Test]
        public void GetSpotifyOAuthToken_OAuthTokenRetrieved()
        {
            var sut = new RealDataRetrievalSource();
            sut.GetSpotifyOAuthToken().Should().NotBeNull();
        }
    }
}

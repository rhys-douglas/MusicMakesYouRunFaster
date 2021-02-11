namespace RD.CanMusicMakeYouRunFaster.Rest.UnitTests.DataRetrievalSourcesTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources;

    public class RealDataRetrievalSourceTests
    {
        [Test]
        public void GetSpotifyOAuthToken_OAuthTokenRetrieved()
        {
            var sut = new RealDataRetrievalSource();
            var oauthToken = sut.GetSpotifyOAuthToken();
            oauthToken.Result.Should().NotBeNull();
        }
    }
}

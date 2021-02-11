namespace RD.CanMusicMakeYouRunFaster.Rest.UnitTests.DataRetrievalSourcesTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources;

    public class RealDataRetrievalSourceTests
    {
        [Test]
        public void GetSpotifyAuthenticationToken_AuthenticationTokenRetrieved()
        {
            var sut = new RealDataRetrievalSource();
            var oauthToken = sut.GetSpotifyAuthenticationToken();
            oauthToken.Result.Should().NotBeNull();
            oauthToken.Result.Value.Should().NotBe(string.Empty);
        }
    }
}

namespace RD.CanMusicMakeYouRunFaster.Rest.UnitTests.AuthenticatorTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.Rest.Authenticators;

    public class StravaAuthenticatorTests
    {
        [Test]
        public void StravaAuthenticatorInstantiated_ObjectIsNotNull()
        {
            var sut = new StravaAuthenticator(new RestSharp.RestClient(@"https://www.strava.com/oauth/authorize"));
            sut.Should().NotBeNull();
        }

        [Test]
        public void GetAuthToken_AuthTokenReturned()
        {
            var sut = new StravaAuthenticator(new RestSharp.RestClient(@"https://www.strava.com/oauth/authorize"));
            var retrievedToken = sut.GetAuthToken();
            retrievedToken.Should().NotBeNull();
        }
    }
}

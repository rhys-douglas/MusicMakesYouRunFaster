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
            var sut = new StravaAuthenticator();
            sut.Should().NotBeNull();
        }

        [Test]
        public void GetAuthToken_AuthTokenReturned()
        {
            var sut = new StravaAuthenticator();
            var retrievedRequest = sut.GetAuthToken();
            retrievedRequest.Should().NotBeNull();
            retrievedRequest.IsFaulted.Should().BeFalse();
            retrievedRequest.Result.Should().NotBeNull();
            retrievedRequest.Result.access_token.Should().NotBeNullOrEmpty();
            retrievedRequest.Result.refresh_token.Should().NotBeNullOrEmpty();
            retrievedRequest.Result.athlete.Should().NotBeNull();
        }
    }
}

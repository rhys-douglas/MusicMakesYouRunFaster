namespace RD.CanMusicMakeYouRunFaster.Rest.UnitTests.AuthenticatorTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.Rest.Authenticators;

    public class OAuth2AuthenticatorTests
    {
        [Test]
        public void StravaAuthenticatorInstantiated_ObjectIsNotNull()
        {
            var sut = new OAuth2Authenticator();
            sut.Should().NotBeNull();
        }

        [Test]
        public void GetStravaAuthToken_AuthTokenReturned()
        {
            var sut = new OAuth2Authenticator();
            var retrievedJsonResult = sut.GetStravaAuthToken();
            retrievedJsonResult.Should().NotBeNull();
            retrievedJsonResult.IsFaulted.Should().BeFalse();
            retrievedJsonResult.Result.Should().NotBeNull();
            retrievedJsonResult.Result.access_token.Should().NotBeNullOrEmpty();
            retrievedJsonResult.Result.refresh_token.Should().NotBeNullOrEmpty();
            retrievedJsonResult.Result.athlete.Should().NotBeNull();
        }

        [Test]
        public void GetFitBitAuthToken_AuthTokenReturned()
        {
            var sut = new OAuth2Authenticator();
            var retrievedJsonResult = sut.GetFitBitAuthToken();
            retrievedJsonResult.Should().NotBeNull();
            retrievedJsonResult.IsFaulted.Should().BeFalse();
            retrievedJsonResult.Result.Should().NotBeNull();
            retrievedJsonResult.Result.AccessToken.Should().NotBeNullOrEmpty();
            retrievedJsonResult.Result.RefreshToken.Should().NotBeNullOrEmpty();
        }
    }
}

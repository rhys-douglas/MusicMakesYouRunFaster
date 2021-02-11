namespace RD.CanMusicMakeYouRunFaster.Common.UnitTests.ControllerTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.Rest.Controllers;

    public class ExternalAPIContollerTests
    {
        [Test]
        public void GetSpotifyOAuthToken_OAuthTokenReturned()
        {
            var sut = new ExternalAPIController();
            sut.GetSpotifyOAuthToken();
            sut.Should().NotBeNull();
        }
    }
}
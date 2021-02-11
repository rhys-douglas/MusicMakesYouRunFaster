namespace RD.CanMusicMakeYouRunFaster.Common.UnitTests.ControllerTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.Rest.Controllers;

    public class ExternalAPIContollerTests
    {
        [Test]
        public void UseFakeDataSource_FakeDataSourceUsed()
        {
            var sut = new ExternalAPIController();
        }

        [Test]
        public void GetSpotifyAuthenticationToken_AuthenticationTokenReturned()
        {
            var sut = new ExternalAPIController();
            var token = sut.GetSpotifyAuthenticationToken();
            token.Should().NotBeNull();
        }

        [Test]
        public void GetSpotifyRecentlyPlayed_ListeningHistoryReturned()
        {
            var sut = new ExternalAPIController();
            var listeningHistory = sut.GetSpotifyRecentlyPlayed();
            listeningHistory.Should().NotBeNull();
        }
    }
}
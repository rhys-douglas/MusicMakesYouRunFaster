namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.UnitTests.ControllerTests
{
    using NUnit.Framework;
    using FakeResponseServer.Controllers;
    using Microsoft.EntityFrameworkCore;
    using FakeResponseServer.DbContext;
    using Microsoft.EntityFrameworkCore.Storage;
    using FluentAssertions;
    using SpotifyAPI.Web;
    using System;
    using System.Threading.Tasks;

    public class SpotifyAuthControllerTests
    {
        private const string ClientId = "1580ff80db9a43e589eee411deba30b0";
        SpotifyAuthController sut;

        [OneTimeSetUp]
        public void SetUp()
        {
            var databaseRoot = new InMemoryDatabaseRoot();
            var contextOptions = new DbContextOptionsBuilder<DataRetrievalContext>()
                .UseInMemoryDatabase("SpotifyAuthControllerDB", databaseRoot).Options;

            sut = new SpotifyAuthController(new DataRetrievalContext(contextOptions)) ;
        }

        [Test]
        public void GetAuthToken_AuthTokenIsValid()
        {
            var (verifier, challenge) = PKCEUtil.GenerateCodes();
            var tokenRequest = new PKCETokenRequest(ClientId, "0", new Uri("localhost:5000/callback"), verifier);
            var retrievedToken = sut.GetPKCEAuthToken(tokenRequest);
            retrievedToken.Result.AccessToken.Should().NotBeNullOrEmpty();
            retrievedToken.Result.RefreshToken.Should().NotBeNullOrEmpty();
            retrievedToken.Result.AccessToken.Should().NotBeSameAs(retrievedToken.Result.RefreshToken);
            retrievedToken.Result.TokenType.Should().Be("Bearer");
            retrievedToken.Result.IsExpired.Should().Be(false);
            retrievedToken.Result.Scope.Should().Contain("UserReadRecentlyPlayed");
            retrievedToken.Result.ExpiresIn.Should().Be(3600);
            retrievedToken.Result.CreatedAt.Should().BeBefore(DateTime.Now);
        }

        [Test]
        public void GetAuthTokenWithNullRequest_ExceptionThrown()
        {
            PKCETokenRequest tokenRequest = null;
            Func<Task> act = async () => await sut.GetPKCEAuthToken(tokenRequest);
            act.Should().Throw<Exception>().WithMessage("Token request is null.");
        }
    }
}

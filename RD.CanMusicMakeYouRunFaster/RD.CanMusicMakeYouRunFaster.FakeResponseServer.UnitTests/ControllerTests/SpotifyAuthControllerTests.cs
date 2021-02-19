namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.UnitTests.ControllerTests
{
    using NUnit.Framework;
    using FakeResponseServer.Controllers;
    using Microsoft.EntityFrameworkCore;
    using FakeResponseServer.DbContext;
    using Microsoft.EntityFrameworkCore.Storage;
    using FluentAssertions;

    public class SpotifyAuthControllerTests
    {
        SpotifyAuthController sut;

        [SetUp]
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
            var result = sut.GetPKCEAuthToken();
            result.Should().NotBeNull();
        }
    }
}

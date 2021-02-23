namespace RD.CanMusicMakeYouRunFaster.Rest.IntegrationTests.FactoryTests
{
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore.Storage;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.CommonTestUtils.Factories;

    public class InMemoryFactoryTests
    {
        [Test]
        public void CreateClient_ClientCreatedSuccessfuly()
        {
            var sut = new InMemoryFactory<FakeResponseServer.Startup>("databaseName", new InMemoryDatabaseRoot());

            var httpClient = sut.CreateClient("http://localhost");
            httpClient.Should().NotBeNull();
        }
    }
}

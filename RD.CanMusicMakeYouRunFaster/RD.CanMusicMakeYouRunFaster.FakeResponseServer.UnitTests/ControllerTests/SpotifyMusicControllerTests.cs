namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.UnitTests.ControllerTests
{
    using NUnit.Framework;
    using FakeResponseServer.Controllers;
    using FluentAssertions;
    using SpotifyAPI.Web;
    using System.Collections.Generic;
    using System;
    using DbContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using System.Threading;

    public class SpotifyMusicControllerTests
    {
        private SpotifyMusicController sut;
        private readonly List<PlayHistoryItem> listeningHistory = new List<PlayHistoryItem>();

        private readonly PlayHistoryItem item1 = new PlayHistoryItem
        {
            PlayedAt = new DateTime(2021, 02, 19),
            Track = new SimpleTrack
            {
                Name = "Song 1",
                ExternalUrls = null
            }
        };

        private readonly PlayHistoryItem item2 = new PlayHistoryItem
        {
            PlayedAt = new DateTime(2021, 02, 20),
            Track = new SimpleTrack
            {
                Name = "Song 2",
                ExternalUrls = null
            }
        };

        private readonly PlayHistoryItem item3 = new PlayHistoryItem
        {
            PlayedAt = new DateTime(2021, 02, 21),
            Track = new SimpleTrack
            {
                Name = "Song 3",
                ExternalUrls = null
            }
        };

        private DbContextOptions<DataRetrievalContext> contextOptions;

        [OneTimeSetUp]
        public void SetUp()
        {
            contextOptions = new DbContextOptionsBuilder<DataRetrievalContext>()
                .UseInMemoryDatabase("SpotifyMusicControllerTestDatabase")
                .Options;

            using var context = new DataRetrievalContext(contextOptions);

            foreach (var musicItem in listeningHistory)
            {
                context.PlayHistoryItems.Add(musicItem);
            }

            context.SaveChanges();
        }

        [Test]
        public void GetRecentlyPlayed_MusicHistoryReturned()
        {
            sut = new SpotifyMusicController(new DataRetrievalContext(contextOptions));
            var getResult = sut.GetRecentlyPlayed();
            getResult.Result.Items.Should().NotBeEmpty();
            getResult.Result.Items.Count.Should().Be(3);
        }
    }
}

namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.UnitTests.ControllerTests
{
    using NUnit.Framework;
    using FakeResponseServer.Controllers;
    using FluentAssertions;
    using System.Collections.Generic;
    using System;
    using DbContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using System.Threading;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Models;
    using SpotifyAPI.Web;

    public class SpotifyMusicControllerTests
    {
        private SpotifyMusicController sut;
        private readonly List<Models.PlayHistoryItem> listeningHistory = new List<Models.PlayHistoryItem>();

        private readonly Models.PlayHistoryItem item1 = new Models.PlayHistoryItem
        {
            Id = "1",
            PlayedAt = new DateTime(2021, 02, 19),
            Track = new Models.SimpleTrack
            {
                Id = "1",
                Name = "Song 1",
                ExternalUrls = null
            }
        };

        private readonly Models.PlayHistoryItem item2 = new Models.PlayHistoryItem
        {
            Id = "2",
            PlayedAt = new DateTime(2021, 02, 20),
            Track = new Models.SimpleTrack
            {
                Id = "2",
                Name = "Song 2",
                ExternalUrls = null
            }
        };

        private readonly Models.PlayHistoryItem item3 = new Models.PlayHistoryItem
        {
            Id = "3",
            PlayedAt = new DateTime(2021, 02, 21),
            Track = new Models.SimpleTrack
            {
                Id = "3",
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

            listeningHistory.Add(item1);
            listeningHistory.Add(item2);
            listeningHistory.Add(item3);

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
            var retrievedSongs = new List<Models.PlayHistoryItem>();
            foreach (var song in getResult.Result.Items)
            {
                retrievedSongs.Add(song);
            }
            retrievedSongs.Should().HaveCount(3);
            retrievedSongs.Should().BeEquivalentTo(listeningHistory);
        }
    }
}

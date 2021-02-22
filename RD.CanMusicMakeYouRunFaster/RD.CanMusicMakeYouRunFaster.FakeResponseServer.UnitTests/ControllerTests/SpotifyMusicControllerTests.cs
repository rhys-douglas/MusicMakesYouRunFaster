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
        private readonly List<DTO.PlayHistoryItem> listeningHistory = new List<DTO.PlayHistoryItem>();

        private readonly Models.PlayHistoryItem item1 = new Models.PlayHistoryItem
        {
            Context = new Models.Context
            {
                ExternalUrls = new Dictionary<string, string>(),
                Href = "SomeHREF",
                Type = "SomeType",
                Uri = "SomeURI"
            },
            Id = "Unneeded value 1.",
            PlayedAt = DateTime.UtcNow,
            Track = new Models.SimpleTrack
            {
                Artists = new List<Models.SimpleArtist>(),
                AvailableMarkets = new List<string>(),
                DiscNumber = 1,
                DurationMs = 3600,
                Explicit = true,
                ExternalUrls = new Dictionary<string, string>(),
                Href = "AnotherHref",
                Id = "12345678",
                IsPlayable = true,
                LinkedFrom = new Models.LinkedTrack 
                { 
                    Id = "12345678",
                    ExternalUrls = new Dictionary<string, string>(),
                    Href = "Some href",
                    Type = "Track",
                    Uri = "Some URI"
                },
                Name = "My favourite song",
                PreviewUrl = "https://google.com",
                TrackNumber = 5,
                Type = Models.ItemType.Track,
                Uri = "AnotherURI"
            }
        };

        private readonly Models.PlayHistoryItem item2 = new Models.PlayHistoryItem
        {
            Context = new Models.Context
            {
                ExternalUrls = new Dictionary<string, string>(),
                Href = "SomeHREF",
                Type = "SomeType",
                Uri = "SomeURI2"
            },
            Id = "Unneeded value 2.",
            PlayedAt = DateTime.UtcNow,
            Track = new Models.SimpleTrack
            {
                Artists = new List<Models.SimpleArtist>(),
                AvailableMarkets = new List<string>(),
                DiscNumber = 1,
                DurationMs = 3600,
                Explicit = true,
                ExternalUrls = new Dictionary<string, string>(),
                Href = "AnotherHref",
                Id = "23456789",
                IsPlayable = true,
                LinkedFrom = new Models.LinkedTrack
                {
                    Id = "23456789",
                    ExternalUrls = new Dictionary<string, string>(),
                    Href = "Some href",
                    Type = "Track",
                    Uri = "Some URI"
                },
                Name = "My favourite song",
                PreviewUrl = "https://google.com",
                TrackNumber = 5,
                Type = Models.ItemType.Track,
                Uri = "AnotherURI"
            }
        };

        private readonly Models.PlayHistoryItem item3 = new Models.PlayHistoryItem
        {
            Context = new Models.Context
            {
                ExternalUrls = new Dictionary<string, string>(),
                Href = "SomeHREF",
                Type = "SomeType",
                Uri = "SomeURI3"
            },
            Id = "Unneeded value 3.",
            PlayedAt = DateTime.UtcNow,
            Track = new Models.SimpleTrack
            {
                Artists = new List<Models.SimpleArtist>(),
                AvailableMarkets = new List<string>(),
                DiscNumber = 1,
                DurationMs = 3600,
                Explicit = true,
                ExternalUrls = new Dictionary<string, string>(),
                Href = "AnotherHref",
                Id = "34567890",
                IsPlayable = true,
                LinkedFrom = new Models.LinkedTrack
                {
                    Id = "34567890",
                    ExternalUrls = new Dictionary<string, string>(),
                    Href = "Some href",
                    Type = "Track",
                    Uri = "Some URI"
                },
                Name = "My favourite song",
                PreviewUrl = "https://google.com",
                TrackNumber = 5,
                Type = Models.ItemType.Track,
                Uri = "AnotherURI"
            }
        };

        private readonly DTO.PlayHistoryItem DTOItem1 = new DTO.PlayHistoryItem
        {
            Context = new DTO.Context
            {
                ExternalUrls = null,
                Href = "SomeHREF",
                Type = "SomeType",
                Uri = "SomeURI"
            },
            PlayedAt = DateTime.UtcNow,
            Track = new DTO.SimpleTrack
            {
                Artists = null,
                AvailableMarkets = null,
                DiscNumber = 1,
                DurationMs = 3600,
                Explicit = true,
                ExternalUrls = null,
                Href = "AnotherHref",
                Id = "12345678",
                IsPlayable = true,
                LinkedFrom = new DTO.LinkedTrack
                {
                    Id = "12345678",
                    ExternalUrls = null,
                    Href = "Some href",
                    Type = "Track",
                    Uri = "Some URI"
                },
                Name = "My favourite song",
                PreviewUrl = "https://google.com",
                TrackNumber = 5,
                Type = Models.ItemType.Track,
                Uri = "AnotherURI"
            }
        };

        private readonly DTO.PlayHistoryItem DTOItem2 = new DTO.PlayHistoryItem
        {
            Context = new DTO.Context
            {
                ExternalUrls = null,
                Href = "SomeHREF",
                Type = "SomeType",
                Uri = "SomeURI2"
            },
            PlayedAt = DateTime.UtcNow,
            Track = new DTO.SimpleTrack
            {
                Artists = null,
                AvailableMarkets = null,
                DiscNumber = 1,
                DurationMs = 3600,
                Explicit = true,
                ExternalUrls = null,
                Href = "AnotherHref",
                Id = "23456789",
                IsPlayable = true,
                LinkedFrom = new DTO.LinkedTrack
                {
                    Id = "23456789",
                    ExternalUrls = null,
                    Href = "Some href",
                    Type = "Track",
                    Uri = "Some URI"
                },
                Name = "My favourite song",
                PreviewUrl = "https://google.com",
                TrackNumber = 5,
                Type = Models.ItemType.Track,
                Uri = "AnotherURI"
            }
        };

        private readonly DTO.PlayHistoryItem DTOItem3 = new DTO.PlayHistoryItem
        {
            Context = new DTO.Context
            {
                ExternalUrls = null,
                Href = "SomeHREF",
                Type = "SomeType",
                Uri = "SomeURI3"
            },
            PlayedAt = DateTime.UtcNow,
            Track = new DTO.SimpleTrack
            {
                Artists = null,
                AvailableMarkets = null,
                DiscNumber = 1,
                DurationMs = 3600,
                Explicit = true,
                ExternalUrls = null,
                Href = "AnotherHref",
                Id = "34567890",
                IsPlayable = true,
                LinkedFrom = new DTO.LinkedTrack
                {
                    Id = "34567890",
                    ExternalUrls = null,
                    Href = "Some href",
                    Type = "Track",
                    Uri = "Some URI"
                },
                Name = "My favourite song",
                PreviewUrl = "https://google.com",
                TrackNumber = 5,
                Type = Models.ItemType.Track,
                Uri = "AnotherURI"
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
            var now = DateTime.UtcNow;
            item1.PlayedAt = now;
            item2.PlayedAt = now;
            item3.PlayedAt = now;
            DTOItem1.PlayedAt = now;
            DTOItem2.PlayedAt = now;
            DTOItem3.PlayedAt = now;

            listeningHistory.Add(DTOItem1);
            listeningHistory.Add(DTOItem2);
            listeningHistory.Add(DTOItem3);

            context.PlayHistoryItems.Add(item1);
            context.PlayHistoryItems.Add(item2);
            context.PlayHistoryItems.Add(item3);

            context.SaveChanges();
        }

        [Test]
        public void GetRecentlyPlayed_MusicHistoryReturned()
        {
            sut = new SpotifyMusicController(new DataRetrievalContext(contextOptions));
            var getResult = sut.GetRecentlyPlayed();
            getResult.Result.Items.Should().NotBeEmpty();
            getResult.Result.Items.Count.Should().Be(3);
            var retrievedSongs = new List<DTO.PlayHistoryItem>();
            foreach (var song in getResult.Result.Items)
            {
                retrievedSongs.Add(song);
            }
            retrievedSongs.Should().HaveCount(3);
            retrievedSongs.Should().BeEquivalentTo(listeningHistory);
        }
    }
}

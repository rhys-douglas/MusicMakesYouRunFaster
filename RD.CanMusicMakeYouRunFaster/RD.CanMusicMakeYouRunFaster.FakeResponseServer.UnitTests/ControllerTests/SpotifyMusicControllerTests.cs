namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.UnitTests.ControllerTests
{
    using NUnit.Framework;
    using FakeResponseServer.Controllers;
    using FluentAssertions;
    using System.Collections.Generic;
    using System;
    using DbContext;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class SpotifyMusicControllerTests
    {
        private SpotifyMusicController sut;
        private readonly List<DTO.PlayHistoryItem> listeningHistory = new List<DTO.PlayHistoryItem>();

        private readonly Models.Spotify.PlayHistoryItem item1 = new Models.Spotify.PlayHistoryItem
        {
            Context = new Models.Spotify.Context
            {
                ExternalUrls = new Dictionary<string, string>(),
                Href = "SomeHREF",
                Type = "SomeType",
                Uri = "SomeURI"
            },
            Id = "Unneeded value 1.",
            PlayedAt = DateTime.UtcNow.AddDays(-2),
            Track = new Models.Spotify.SimpleTrack
            {
                Artists = new List<Models.Spotify.SimpleArtist>(),
                AvailableMarkets = new List<string>(),
                DiscNumber = 1,
                DurationMs = 3600,
                Explicit = true,
                ExternalUrls = new Dictionary<string, string>(),
                Href = "AnotherHref",
                Id = "12345678",
                IsPlayable = true,
                LinkedFrom = new Models.Spotify.LinkedTrack 
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
                Type = Models.Spotify.ItemType.Track,
                Uri = "AnotherURI"
            }
        };

        private readonly Models.Spotify.PlayHistoryItem item2 = new Models.Spotify.PlayHistoryItem
        {
            Context = new Models.Spotify.Context
            {
                ExternalUrls = new Dictionary<string, string>(),
                Href = "SomeHREF",
                Type = "SomeType",
                Uri = "SomeURI2"
            },
            Id = "Unneeded value 2.",
            PlayedAt = DateTime.UtcNow.AddDays(-3),
            Track = new Models.Spotify.SimpleTrack
            {
                Artists = new List<Models.Spotify.SimpleArtist>(),
                AvailableMarkets = new List<string>(),
                DiscNumber = 1,
                DurationMs = 3600,
                Explicit = true,
                ExternalUrls = new Dictionary<string, string>(),
                Href = "AnotherHref",
                Id = "23456789",
                IsPlayable = true,
                LinkedFrom = new Models.Spotify.LinkedTrack
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
                Type = Models.Spotify.ItemType.Track,
                Uri = "AnotherURI"
            }
        };

        private readonly Models.Spotify.PlayHistoryItem item3 = new Models.Spotify.PlayHistoryItem
        {
            Context = new Models.Spotify.Context
            {
                ExternalUrls = new Dictionary<string, string>(),
                Href = "SomeHREF",
                Type = "SomeType",
                Uri = "SomeURI3"
            },
            Id = "Unneeded value 3.",
            PlayedAt = DateTime.UtcNow,
            Track = new Models.Spotify.SimpleTrack
            {
                Artists = new List<Models.Spotify.SimpleArtist>(),
                AvailableMarkets = new List<string>(),
                DiscNumber = 1,
                DurationMs = 3600,
                Explicit = true,
                ExternalUrls = new Dictionary<string, string>(),
                Href = "AnotherHref",
                Id = "34567890",
                IsPlayable = true,
                LinkedFrom = new Models.Spotify.LinkedTrack
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
                Type = Models.Spotify.ItemType.Track,
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
            PlayedAt = DateTime.UtcNow.AddDays(-2),
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
                Type = Models.Spotify.ItemType.Track,
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
            PlayedAt = DateTime.UtcNow.AddDays(-3),
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
                Type = Models.Spotify.ItemType.Track,
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
                Type = Models.Spotify.ItemType.Track,
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
            item1.PlayedAt = now.AddDays(-2);
            item2.PlayedAt = now.AddDays(-3);
            item3.PlayedAt = now;
            DTOItem1.PlayedAt = now.AddDays(-2);
            DTOItem2.PlayedAt = now.AddDays(-3);
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
            var retrievedSongs = getResult.Result.Items.ToList();
            retrievedSongs.Should().HaveCount(3);
            retrievedSongs.Should().BeEquivalentTo(listeningHistory);
        }

        [Test]
        public void GetRecentlyPlayedWithAfterParam_MusicHistoryReturned()
        {
            var after = DateTime.UtcNow.AddDays(-1);
            var afterAsUnix = ((DateTimeOffset)after).ToUnixTimeMilliseconds();
            sut = new SpotifyMusicController(new DataRetrievalContext(contextOptions));
            var getResult = sut.GetRecentlyPlayed(afterAsUnix);
            var retrievedSongs = getResult.Result.Items.ToList();
            retrievedSongs.Should().HaveCount(1);
            retrievedSongs.Should().NotBeEquivalentTo(listeningHistory);
        }
    }
}

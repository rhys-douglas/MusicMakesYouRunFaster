namespace RD.CanMusicMakeYouRunFaster.Rest.IntegrationTests.DataRetrievalSourcesTests
{
    using DataRetrievalSources;
    using Entity;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.DbContext;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Factories;
    using RD.CanMusicMakeYouRunFaster.Rest.IntegrationTests.TestUtils;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    public class FakeDataRetrievalSourceTests : TestsBase
    {
        private SpotifyAuthenticationToken authenticationToken;
        private IDataRetrievalSource sut;
        private DbContextOptions<DataRetrievalContext> contextOptions;

        

        private readonly List<FakeResponseServer.Models.PlayHistoryItem> PlayHistoryItems = new List<FakeResponseServer.Models.PlayHistoryItem>
        {
            new FakeResponseServer.Models.PlayHistoryItem
            {
                Context = new FakeResponseServer.Models.Context
                {
                    ExternalUrls = null,
                    Href = "Href object",
                    Type = "Some type",
                    Uri = "Uri1"
                },
                Id = "1",
                PlayedAt = DateTime.UtcNow,
                Track = new FakeResponseServer.Models.SimpleTrack
                {
                    Artists = null,
                    AvailableMarkets = null, 
                    DiscNumber = 1,
                    DurationMs = 3600,
                    Explicit = true,
                    ExternalUrls = null,
                    Href = "Href 1",
                    Id = "1",
                    IsPlayable = true,
                    LinkedFrom = new FakeResponseServer.Models.LinkedTrack
                    {
                        ExternalUrls = null,
                        Href = "Some href",
                        Id = "1",
                        Type = "Track",
                        Uri = "Uri1"
                    },
                    Name = "Track 1",
                    PreviewUrl = "http://google.com",
                    TrackNumber = 1,
                    Type = FakeResponseServer.Models.ItemType.Track,
                    Uri = "Uri1"
                }
            },

            new FakeResponseServer.Models.PlayHistoryItem
            {
                Context = new FakeResponseServer.Models.Context
                {
                    ExternalUrls = null,
                    Href = "Href object",
                    Type = "Some type",
                    Uri = "Uri2"
                },
                Id = "2",
                PlayedAt = DateTime.UtcNow,
                Track = new FakeResponseServer.Models.SimpleTrack
                {
                    Artists = null,
                    AvailableMarkets = null,
                    DiscNumber = 2,
                    DurationMs = 3600,
                    Explicit = true,
                    ExternalUrls = null,
                    Href = "Href 2",
                    Id = "2",
                    IsPlayable = true,
                    LinkedFrom = new FakeResponseServer.Models.LinkedTrack
                    {
                        ExternalUrls = null,
                        Href = "Some href",
                        Id = "2",
                        Type = "Track",
                        Uri = "Uri2"
                    },
                    Name = "Track 2",
                    PreviewUrl = "http://google.com",
                    TrackNumber = 1,
                    Type = FakeResponseServer.Models.ItemType.Track,
                    Uri = "Uri2"
                }
            },

            new FakeResponseServer.Models.PlayHistoryItem
            {
                Context = new FakeResponseServer.Models.Context
                {
                    ExternalUrls = null,
                    Href = "Href object",
                    Type = "Some type",
                    Uri = "Uri3"
                },
                Id = "3",
                PlayedAt = DateTime.UtcNow,
                Track = new FakeResponseServer.Models.SimpleTrack
                {
                    Artists = null,
                    AvailableMarkets = null,
                    DiscNumber = 3,
                    DurationMs = 3600,
                    Explicit = true,
                    ExternalUrls = null,
                    Href = "Href 3",
                    Id = "3",
                    IsPlayable = true,
                    LinkedFrom = new FakeResponseServer.Models.LinkedTrack
                    {
                        ExternalUrls = null,
                        Href = "Some href",
                        Id = "3",
                        Type = "Track",
                        Uri = "Uri1"
                    },
                    Name = "Track 3",
                    PreviewUrl = "http://google.com",
                    TrackNumber = 1,
                    Type = FakeResponseServer.Models.ItemType.Track,
                    Uri = "Uri3"
                }
            },

        };

        [OneTimeSetUp]
        public void SetUpTests()
        {
            var now = DateTime.UtcNow;
            foreach (var item in PlayHistoryItems)
            {
                item.PlayedAt = now;
                dataRetrievalContext.PlayHistoryItems.Add(item);
            }
            dataRetrievalContext.SaveChanges();

            var oauthToken = sut.GetSpotifyAuthenticationToken();
            oauthToken.Result.Should().NotBeNull();
            oauthToken.Result.Value.Should().NotBe(string.Empty);
            authenticationToken = JsonConvert.DeserializeObject<SpotifyAuthenticationToken>((string)oauthToken.Result.Value);
            authenticationToken.AccessToken.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void GetSpotifyListeningHistory_ListeningHistoryRetrieved()
        {
            var listeningHistory = sut.GetSpotifyRecentlyPlayed(authenticationToken);
            listeningHistory.Result.Value.Should().NotBeNull();
            listeningHistory.Result.Value.Should().NotBe(string.Empty);
        }

        [Test]
        public void GetSpotifyListeningHistoryWithInvalidAuthToken_ExceptionThrown()
        {
            var listeningHistory = sut.GetSpotifyRecentlyPlayed(new SpotifyAuthenticationToken()) ;
            listeningHistory.Result.Value.Should().NotBeNull();
            listeningHistory.Result.Value.Should().NotBe(string.Empty);
        }

        private FakeDataRetrievalSource MakeSut(SpotifyClient spotifyClient)
        {
            return new FakeDataRetrievalSource(spotifyClient);
        }
    }
}

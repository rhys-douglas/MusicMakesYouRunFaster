namespace RD.CanMusicMakeYouRunFaster.Rest.IntegrationTests.DataRetrievalSourcesTests
{
    using System;
    using System.Collections.Generic;
    using DataRetrievalSources;
    using Entity;
    using FluentAssertions;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.Rest.IntegrationTests.TestUtils;
    using SpotifyAPI.Web;

    public class FakeDataRetrievalSourceTests : TestsBase
    {
        private SpotifyAuthenticationToken spotifyAuthToken;
        private StravaAuthenticationToken stravaAuthToken;
        private FakeDataRetrievalSource sut;
        private readonly List<FakeResponseServer.Models.Spotify.PlayHistoryItem> PlayHistoryItems = new List<FakeResponseServer.Models.Spotify.PlayHistoryItem>
        {
            new FakeResponseServer.Models.Spotify.PlayHistoryItem
            {
                Context = new FakeResponseServer.Models.Spotify.Context
                {
                    ExternalUrls = null,
                    Href = "Href object",
                    Type = "Some type",
                    Uri = "Uri1"
                },
                Id = "1",
                PlayedAt = DateTime.UtcNow,
                Track = new FakeResponseServer.Models.Spotify.SimpleTrack
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
                    LinkedFrom = new FakeResponseServer.Models.Spotify.LinkedTrack
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
                    Type = FakeResponseServer.Models.Spotify.ItemType.Track,
                    Uri = "Uri1"
                }
            },

            new FakeResponseServer.Models.Spotify.PlayHistoryItem
            {
                Context = new FakeResponseServer.Models.Spotify.Context
                {
                    ExternalUrls = null,
                    Href = "Href object",
                    Type = "Some type",
                    Uri = "Uri2"
                },
                Id = "2",
                PlayedAt = DateTime.UtcNow,
                Track = new FakeResponseServer.Models.Spotify.SimpleTrack
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
                    LinkedFrom = new FakeResponseServer.Models.Spotify.LinkedTrack
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
                    Type = FakeResponseServer.Models.Spotify.ItemType.Track,
                    Uri = "Uri2"
                }
            },

            new FakeResponseServer.Models.Spotify.PlayHistoryItem
            {
                Context = new FakeResponseServer.Models.Spotify.Context
                {
                    ExternalUrls = null,
                    Href = "Href object",
                    Type = "Some type",
                    Uri = "Uri3"
                },
                Id = "3",
                PlayedAt = DateTime.UtcNow,
                Track = new FakeResponseServer.Models.Spotify.SimpleTrack
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
                    LinkedFrom = new FakeResponseServer.Models.Spotify.LinkedTrack
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
                    Type = FakeResponseServer.Models.Spotify.ItemType.Track,
                    Uri = "Uri3"
                }
            },

        };

        private readonly List<Activity> ActivityItems = new List<Activity>
        {
            new Activity
            {

            }
        };

        [OneTimeSetUp]
        public void SetUpTests()
        {
            var now = DateTime.UtcNow;
            foreach (var item in PlayHistoryItems)
            {
                item.PlayedAt = now;
            }

            RegisterMusicHistory(PlayHistoryItems);

            sut = MakeSut();

            // Get spotify auth token.
            var spotifyAuthTask = sut.GetSpotifyAuthenticationToken();
            spotifyAuthTask.Result.Should().NotBeNull();
            spotifyAuthTask.Result.Value.Should().NotBe(string.Empty);
            var temp = JsonConvert.SerializeObject(spotifyAuthTask.Result.Value);
            spotifyAuthToken = JsonConvert.DeserializeObject<SpotifyAuthenticationToken>(temp);
            spotifyAuthToken.AccessToken.Should().NotBeNullOrEmpty();

            // Get strava auth token.
            var stravaAuthTask = sut.GetStravaAuthenticationToken();
            stravaAuthTask.Result.Should().NotBeNull();
            stravaAuthTask.Result.Value.Should().NotBeNull();
            temp = JsonConvert.SerializeObject(stravaAuthTask.Result.Value);
            stravaAuthToken = JsonConvert.DeserializeObject<StravaAuthenticationToken>(temp);
            stravaAuthToken.access_token.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void GetSpotifyListeningHistory_ListeningHistoryRetrieved()
        {
            sut = MakeSut();
            var listeningHistory = sut.GetSpotifyRecentlyPlayed(spotifyAuthToken);
            listeningHistory.Result.Value.Should().NotBeNull();
            listeningHistory.Result.Value.Should().NotBe(string.Empty);
            var listeningHistoryJson = JsonConvert.SerializeObject(listeningHistory.Result.Value);
            var actualListeningHistory = JsonConvert.DeserializeObject<CursorPaging<PlayHistoryItem>>(listeningHistoryJson);
            actualListeningHistory.Items.Should().HaveCount(3);
            actualListeningHistory.Items[0].Should().BeOfType<PlayHistoryItem>();
        }

        [Test]
        public void GetSpotifyListeningHistoryWithInvalidAuthToken_ExceptionThrown()
        {
            sut = MakeSut();
            var listeningHistory = sut.GetSpotifyRecentlyPlayed(new SpotifyAuthenticationToken()) ;
            listeningHistory.Result.Value.Should().NotBeNull();
            listeningHistory.Result.Value.Should().NotBe(string.Empty);
        }

        [Test]
        public void GetStravaActivityHistoryWithValidAuthToken_ActivityHistoryRetrieved()
        {
            sut = MakeSut();
            var runningHistoryTask = sut.GetStravaActivityHistory(stravaAuthToken);
            runningHistoryTask.Result.Value.Should().NotBeNull();
            runningHistoryTask.Result.Value.Should().NotBe(string.Empty);
            var runningHistoryJson = JsonConvert.SerializeObject(runningHistoryTask.Result.Value);
            var actualRunningHistory = JsonConvert.DeserializeObject<List<Activity>>(runningHistoryJson);
            actualRunningHistory.Count.Should().Be(2);
            actualRunningHistory[0].Should().BeOfType<Activity>();
        }

        private FakeDataRetrievalSource MakeSut()
        {
            return new FakeDataRetrievalSource(externalAPICaller, FakeServerAddress);
        }
    }
}

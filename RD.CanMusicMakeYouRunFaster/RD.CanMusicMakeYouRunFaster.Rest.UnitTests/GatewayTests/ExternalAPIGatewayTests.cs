namespace RD.CanMusicMakeYouRunFaster.Rest.UnitTests.GatewayTests
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.Rest.Gateways;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using RD.CanMusicMakeYouRunFaster.Rest.DataRetrievalSources;
    using System.Net.Http;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.EntityFrameworkCore;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.DbContext;
    using RD.CanMusicMakeYouRunFaster.CommonTestUtils.Factories;
    using SpotifyAPI.Web;
    using System.Collections.Generic;
    using System;

    public class ExternalAPIGatewayTests
    {
        private ExternalAPIGateway sut;
        private const string DatabaseName = "FakeExternalAPIGatewayDatabase";
        private DbContextOptions<DataRetrievalContext> contextOptions;
        private const string FakeServerAddress = "http://localhost:2222";
        private FakeDataRetrievalSource fakeDataRetrievalSource;

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
                PlayedAt = DateTime.UtcNow.AddHours(1),
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

        private readonly List<FakeResponseServer.Models.Strava.Activity> ActivityHistory = new List<FakeResponseServer.Models.Strava.Activity>
        {
            new FakeResponseServer.Models.Strava.Activity
            {
                resource_state = 1,
                athlete = new FakeResponseServer.Models.Strava.Athlete
                {
                    id = 12345678,
                    resource_state = 2
                },
                name = "Activity 1",
                distance = 100.1,
                moving_time = 7620,
                elapsed_time = 8920,
                total_elevation_gain = -5,
                type = "Run",
                workout_type = 1,
                id = "1274371a83432",
                external_id = "Activity 1",
                upload_id = "132387623743t8a",
                start_date = DateTime.UtcNow,
                start_date_local = DateTime.Now,
                timezone = "GMT+00",
                utc_offset = 0,
                start_latlng = new List<double>(),
                end_latlng = new List<double>(),
                location_city = "Oxford",
                location_state = "OXF",
                location_country = "UK",
                start_latitude = 50.10202412,
                start_longitude = -1.2435235,
                achievement_count = 9,
                kudos_count = 6,
                comment_count = 1,
                athlete_count = 1,
                photo_count = 0,
                map = new FakeResponseServer.Models.Strava.Map
                {
                    id = "Map1",
                    resource_state = 2,
                    summary_polyline = "something"
                },
                trainer = false,
                commute = true,
                manual = false,
                Private = true,
                visibility = "Private",
                flagged = false,
                gear_id = "asdasf123dsf21",
                from_accepted_tag = false,
                upload_id_str = "String upload ID",
                average_speed = 12.35,
                max_speed = 14.2,
                average_cadence = 78.5,
                average_temp = 7,
                has_heartrate = true,
                average_heartrate = 163,
                max_heartrate = 200,
                heartrate_opt_out = false,
                display_hide_heartrate_option = false,
                elev_high = 65,
                elev_low = 60,
                pr_count = 1,
                total_photo_count = 1,
                has_kudoed = false,
            },
            new FakeResponseServer.Models.Strava.Activity
            {
                resource_state = 1,
                athlete = new FakeResponseServer.Models.Strava.Athlete
                {
                    id = 2345678,
                    resource_state = 2
                },
                name = "Activity 2",
                distance = 100.1,
                moving_time = 7620,
                elapsed_time = 8920,
                total_elevation_gain = -5,
                type = "Run",
                workout_type = 1,
                id = "43271617841asf3472",
                external_id = "Activity 2",
                upload_id = "132387623743t8a",
                start_date = DateTime.UtcNow,
                start_date_local = DateTime.Now,
                timezone = "GMT+00",
                utc_offset = 0,
                start_latlng = new List<double>(),
                end_latlng = new List<double>(),
                location_city = "Cardiff",
                location_state = "CDF",
                location_country = "UK",
                start_latitude = 50.10202412,
                start_longitude = -1.2435235,
                achievement_count = 9,
                kudos_count = 6,
                comment_count = 1,
                athlete_count = 1,
                photo_count = 0,
                map = new FakeResponseServer.Models.Strava.Map
                {
                    id = "Map2",
                    resource_state = 2,
                    summary_polyline = "something"
                },
                trainer = false,
                commute = true,
                manual = false,
                Private = true,
                visibility = "Private",
                flagged = false,
                gear_id = "asdasf123dsf21",
                from_accepted_tag = false,
                upload_id_str = "String upload ID",
                average_speed = 12.35,
                max_speed = 14.2,
                average_cadence = 78.5,
                average_temp = 7,
                has_heartrate = true,
                average_heartrate = 163,
                max_heartrate = 200,
                heartrate_opt_out = false,
                display_hide_heartrate_option = false,
                elev_high = 65,
                elev_low = 60,
                pr_count = 1,
                total_photo_count = 1,
                has_kudoed = false,
            }
        };

        [OneTimeSetUp]
        public void SetUpTests()
        {
            HttpClient httpClient;
            var databaseRoot = new InMemoryDatabaseRoot();
            contextOptions = new DbContextOptionsBuilder<DataRetrievalContext>()
                    .UseInMemoryDatabase(DatabaseName, databaseRoot)
                    .Options;

            var webAppFactory = new InMemoryFactory<FakeResponseServer.Startup>(DatabaseName, databaseRoot);
            httpClient = webAppFactory.CreateClient(FakeServerAddress);
            var dataSource = new FakeDataRetrievalSource(new FakeResponseServer.Controllers.ExternalAPICaller(httpClient), FakeServerAddress);
            sut = new ExternalAPIGateway(dataSource);

            var externalAPICaller = new FakeResponseServer.Controllers.ExternalAPICaller(httpClient);

            var now_UTC = DateTime.UtcNow;
            var now_local = DateTime.Now;
            var offset = -2;
            foreach (var item in PlayHistoryItems)
            {
                item.PlayedAt = now_UTC.AddDays(offset);
                offset++;
            }

            foreach (var item in ActivityHistory)
            {
                item.start_date = now_UTC;
                item.start_date_local = now_local;
            }

            using var context = new DataRetrievalContext(contextOptions);
            context.PlayHistoryItems.RemoveRange(context.PlayHistoryItems);
            context.PlayHistoryItems.AddRange(PlayHistoryItems);
            context.ActivityHistoryItems.RemoveRange(context.ActivityHistoryItems);
            context.ActivityHistoryItems.AddRange(ActivityHistory);
            context.SaveChanges();

            fakeDataRetrievalSource = new FakeDataRetrievalSource(externalAPICaller, FakeServerAddress);
            sut = MakeSut();
        }

        [Test]
        public void GetSpotifyAuthenticationToken_AuthenticationTokenReturned()
        {
            sut = MakeSut();
            var tokenAsJson = sut.GetSpotifyAuthenticationToken();
            tokenAsJson.Value.Should().NotBeNull();
            var tokenAsExtractedJson = JsonConvert.SerializeObject(tokenAsJson.Value);
            var spotifyAuthToken = JsonConvert.DeserializeObject<SpotifyAuthenticationToken>(tokenAsExtractedJson);
            spotifyAuthToken.AccessToken.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void GetSpotifyRecentlyPlayed_ListeningHistoryReturned()
        {
            sut = MakeSut();
            var listeningHistory = sut.GetSpotifyRecentlyPlayed();
            listeningHistory.Value.Should().NotBeNull();
            var listeningHistoryExtracted = JsonConvert.SerializeObject(listeningHistory.Value);
            var actualListeningHistory = JsonConvert.DeserializeObject<CursorPaging<PlayHistoryItem>>(listeningHistoryExtracted);
            actualListeningHistory.Items.Should().HaveCount(3);
            actualListeningHistory.Items.Should().NotBeNull();
        }

        [Test]
        public void GetStravaAuthenticationToken_AuthenticationTokenReturned()
        {
            sut = MakeSut();
            var tokenAsJson = sut.GetStravaAuthenticationToken();
            tokenAsJson.Value.Should().NotBeNull();
            var tokenAsExtractedJson = JsonConvert.SerializeObject(tokenAsJson.Value);
            var stravaAuthToken = JsonConvert.DeserializeObject<StravaAuthenticationToken>(tokenAsExtractedJson);
            stravaAuthToken.access_token.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void GetStravaActivityHistory_ActivityHistoryReturned()
        {
            sut = MakeSut();
            var activityHistory = sut.GetStravaRecentActivities();
            activityHistory.Value.Should().NotBeNull();
            var activityHistoryExtracted = JsonConvert.SerializeObject(activityHistory.Value);
            var actualActivityHistory = JsonConvert.DeserializeObject<List<Activity>>(activityHistoryExtracted);
            actualActivityHistory.Count.Should().Be(2);
            actualActivityHistory[0].average_speed.Should().Be(12.35);
        }

        [Test]
        public void GetSpotifyRecentlyPlayedWithAfterParam_CorrectResponseReturned()
        {
            var now = DateTime.UtcNow.AddDays(-1);
            var nowInUnix = ((DateTimeOffset)now).ToUnixTimeMilliseconds();
            sut = MakeSut();
            var listeningHistory = sut.GetSpotifyRecentlyPlayed(nowInUnix);
            listeningHistory.Value.Should().NotBeNull();
            var afterTestJSON = JsonConvert.SerializeObject(listeningHistory.Value);
            var afterTest = JsonConvert.DeserializeObject<CursorPaging<PlayHistoryItem>>(afterTestJSON);
            afterTest.Items.Should().HaveCount(1);
            afterTest.Items.Should().NotBeNull().And.NotBeEmpty();

            listeningHistory = sut.GetSpotifyRecentlyPlayed();
            listeningHistory.Value.Should().NotBeNull();
            var listeningHistoryExtracted = JsonConvert.SerializeObject(listeningHistory.Value);
            var actualListeningHistory = JsonConvert.DeserializeObject<CursorPaging<PlayHistoryItem>>(listeningHistoryExtracted);
            actualListeningHistory.Items.Should().HaveCount(3);
            actualListeningHistory.Items.Should().NotBeNull();
        }

        [Test]
        public void GetFitBitAuthenticationToken_AuthenticationTokenReturned()
        {
            sut = MakeSut();
            var tokenAsJson = sut.GetFitBitAuthenticationToken();
            tokenAsJson.Value.Should().NotBeNull();
            var extractedJsonToken = JsonConvert.SerializeObject(tokenAsJson.Value);
            var fitBitAuthToken = JsonConvert.DeserializeObject<FitBitAuthenticationToken>(extractedJsonToken);
            fitBitAuthToken.AccessToken.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void GetFitBitActivityHistory_ActivityHistoryReturned()
        {
            // Get activities
            sut = MakeSut();
            var activityHistory = sut.GetFitBitRecentActivities();
            var actualHistory = activityHistory.Value;
            actualHistory.Should().NotBeNull();
            actualHistory.Should().BeOfType<Fitbit.Api.Portable.Models.ActivityLogsList>();
        }

        private ExternalAPIGateway MakeSut()
        {
            return new ExternalAPIGateway(fakeDataRetrievalSource);
        }
    }
}
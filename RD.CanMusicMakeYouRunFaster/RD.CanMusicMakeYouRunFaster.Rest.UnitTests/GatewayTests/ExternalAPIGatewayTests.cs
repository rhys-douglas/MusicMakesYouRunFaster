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

        private readonly List<FakeResponseServer.Models.FitBit.Activities> FitBitActivityItems = new List<FakeResponseServer.Models.FitBit.Activities>
        {
            new FakeResponseServer.Models.FitBit.Activities
            {
                ActiveDuration = 5,
                ActivityLevel = new List<FakeResponseServer.Models.FitBit.ActivityLevel>(),
                ActivityName = "Run 1",
                ActivityTypeId = 5,
                AverageHeartRate = 140,
                Calories = 500,
                DateOfActivity = "17/04/2021",
                Distance = 3500,
                DistanceUnit = "M",
                Duration = 3600,
                ElevationGain = 330,
                HeartRateZones = new List<FakeResponseServer.Models.FitBit.HeartRateZone>(),
                LastModified = DateTime.Now,
                LogId = 123253464353,
                LogType = "logtype1",
                ManualValuesSpecified = new FakeResponseServer.Models.FitBit.ManualValuesSpecified
                {
                    Distance = false,
                    Calories = false,
                    Steps = false,
                },
                OriginalDuration = 3601,
                OriginalStartTime = DateTime.Now,
                Pace = 16.5,
                Source = new FakeResponseServer.Models.FitBit.ActivityLogSource
                {
                    Id = "1",
                    Name = "1",
                    Type = "type1",
                    Url = "someurl"
                },
                Speed = 18.5,
                StartTime = DateTime.Now,
                Steps = 14000,
                TcxLink = "??"
            },
            new FakeResponseServer.Models.FitBit.Activities
            {
                ActiveDuration = 5,
                ActivityLevel = new List<FakeResponseServer.Models.FitBit.ActivityLevel>(),
                ActivityName = "Run 2",
                ActivityTypeId = 5,
                AverageHeartRate = 140,
                Calories = 500,
                DateOfActivity = "18/04/2021",
                Distance = 3500,
                DistanceUnit = "M",
                Duration = 3600,
                ElevationGain = 330,
                HeartRateZones = new List<FakeResponseServer.Models.FitBit.HeartRateZone>(),
                LastModified = DateTime.Now,
                LogId = 23456789,
                LogType = "logtype2",
                ManualValuesSpecified = new FakeResponseServer.Models.FitBit.ManualValuesSpecified
                {
                    Distance = true,
                    Calories = false,
                    Steps = false,
                },
                OriginalDuration = 3601,
                OriginalStartTime = DateTime.Now,
                Pace = 16.5,
                Source = new FakeResponseServer.Models.FitBit.ActivityLogSource
                {
                    Id = "2",
                    Name = "2",
                    Type = "type2",
                    Url = "url2"
                },
                Speed = 18.5,
                StartTime = DateTime.Now,
                Steps = 14000,
                TcxLink = "??"
            }
        };

        private readonly List<FakeResponseServer.Models.LastFM.LastTrack> LastFMTrackItems = new List<FakeResponseServer.Models.LastFM.LastTrack>
        {
            new FakeResponseServer.Models.LastFM.LastTrack
            {
                AlbumName = "Some Album Name",
                ArtistImages = new FakeResponseServer.Models.LastFM.LastImageSet()
                {
                    Small = new Uri("http://localhost/Small"),
                    Medium = new Uri("http://localhost/Medium"),
                    Large = new Uri("http://localhost/Large"),
                    ExtraLarge = new Uri("http://localhost/XL"),
                    Mega = new Uri("http://localhost/Mega"),
                },
                ArtistMbid = "123456789",
                ArtistName = "Some Artist",
                ArtistUrl = new Uri("http://localhost/ArtistURI"),
                Duration = new TimeSpan(0, 2, 30),
                Id = "23456789",
                Images = new FakeResponseServer.Models.LastFM.LastImageSet
                {
                    Small = new Uri("http://localhost/Small1"),
                    Medium = new Uri("http://localhost/Medium1"),
                    Large = new Uri("http://localhost/Large1"),
                    ExtraLarge = new Uri("http://localhost/XL1"),
                    Mega = new Uri("http://localhost/Mega1"),
                },
                IsLoved = true,
                IsNowPlaying = false,
                ListenerCount = 1500,
                Mbid = "1",
                Name = "Some Track",
                PlayCount = 300,
                Rank = 1,
                TimePlayed = DateTime.UtcNow,
                TopTags = new List<FakeResponseServer.Models.LastFM.LastTag>(),
                Url = new Uri("http://localhost/TrackURI"),
                UserPlayCount = 20
            },
            new FakeResponseServer.Models.LastFM.LastTrack
            {
                AlbumName = "Some Album Name 2",
                ArtistImages = new FakeResponseServer.Models.LastFM.LastImageSet()
                {
                    Small = new Uri("http://localhost/Small2"),
                    Medium = new Uri("http://localhost/Medium2"),
                    Large = new Uri("http://localhost/Large2"),
                    ExtraLarge = new Uri("http://localhost/XL2"),
                    Mega = new Uri("http://localhost/Mega2"),
                },
                ArtistMbid = "abcdefghi",
                ArtistName = "Some Artist 2",
                ArtistUrl = new Uri("http://localhost/ArtistURI2"),
                Duration = new TimeSpan(0, 3, 0),
                Id = "bcdefghij",
                Images = new FakeResponseServer.Models.LastFM.LastImageSet
                {
                    Small = new Uri("http://localhost/Small3"),
                    Medium = new Uri("http://localhost/Medium3"),
                    Large = new Uri("http://localhost/Large3"),
                    ExtraLarge = new Uri("http://localhost/XL3"),
                    Mega = new Uri("http://localhost/Mega3"),
                },
                IsLoved = false,
                IsNowPlaying = true,
                ListenerCount = 53478763,
                Mbid = "2",
                Name = "Some Track 2",
                PlayCount = 573847389,
                Rank = 2,
                TimePlayed = DateTime.UtcNow,
                TopTags = new List<FakeResponseServer.Models.LastFM.LastTag>(),
                Url = new Uri("http://localhost/TrackURI2"),
                UserPlayCount = 30,
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

            foreach (var item in FitBitActivityItems)
            {
                item.StartTime = now_UTC;
                item.OriginalStartTime = now_UTC;
                item.LastModified = now_UTC;
            }

            offset = -1;
            foreach (var item in LastFMTrackItems)
            {
                item.TimePlayed = now_UTC.AddDays(offset);
                offset++;
            }

            using var context = new DataRetrievalContext(contextOptions);
            context.PlayHistoryItems.RemoveRange(context.PlayHistoryItems);
            context.PlayHistoryItems.AddRange(PlayHistoryItems);
            context.ActivityHistoryItems.RemoveRange(context.ActivityHistoryItems);
            context.ActivityHistoryItems.AddRange(ActivityHistory);
            context.FitBitActivityItems.RemoveRange(context.FitBitActivityItems);
            context.FitBitActivityItems.AddRange(FitBitActivityItems);
            context.LastTracks.RemoveRange(context.LastTracks);
            context.LastTracks.AddRange(LastFMTrackItems);
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
            var spotifyAuthToken = JsonConvert.DeserializeObject<SpotifyAuthenticationToken>((string)tokenAsJson.Value);
            spotifyAuthToken.AccessToken.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void GetSpotifyRecentlyPlayed_ListeningHistoryReturned()
        {
            sut = MakeSut();
            var tokenAsJson = sut.GetSpotifyAuthenticationToken();
            tokenAsJson.Value.Should().NotBeNull();
            var spotifyAuthToken = JsonConvert.DeserializeObject<SpotifyAuthenticationToken>((string)tokenAsJson.Value);
            spotifyAuthToken.AccessToken.Should().NotBeNullOrEmpty();

            var listeningHistory = sut.GetSpotifyRecentlyPlayed(spotifyAuthToken.AccessToken);
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
            var stravaAuthToken = JsonConvert.DeserializeObject<StravaAuthenticationToken>((string)tokenAsJson.Value);
            stravaAuthToken.access_token.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void GetStravaActivityHistory_ActivityHistoryReturned()
        {
            sut = MakeSut();
            var tokenAsJson = sut.GetStravaAuthenticationToken();
            tokenAsJson.Value.Should().NotBeNull();
            var stravaAuthToken = JsonConvert.DeserializeObject<StravaAuthenticationToken>((string)tokenAsJson.Value);
            stravaAuthToken.access_token.Should().NotBeNullOrEmpty();

            var activityHistory = sut.GetStravaRecentActivities(stravaAuthToken.access_token);
            activityHistory.Value.Should().NotBeNull();
            var activityHistoryExtracted = JsonConvert.SerializeObject(activityHistory.Value);
            var actualActivityHistory = JsonConvert.DeserializeObject<List<StravaActivity>>(activityHistoryExtracted);
            actualActivityHistory.Count.Should().Be(2);
            actualActivityHistory[0].average_speed.Should().Be(12.35);
        }

        [Test]
        public void GetStravaActivityHistoryWithAcessTokenAndStartDate_CorrectActivityHistoryReturned()
        {
            sut = MakeSut();
            var tokenAsJson = sut.GetStravaAuthenticationToken();
            tokenAsJson.Value.Should().NotBeNull();
            var stravaAuthToken = JsonConvert.DeserializeObject<StravaAuthenticationToken>((string)tokenAsJson.Value);
            stravaAuthToken.access_token.Should().NotBeNullOrEmpty();

            var startDate = DateTime.UtcNow.AddDays(-1);

            var activityHistory = sut.GetStravaRecentActivities(stravaAuthToken.access_token, startDate);
            activityHistory.Value.Should().NotBeNull();
            var activityHistoryExtracted = JsonConvert.SerializeObject(activityHistory.Value);
            var actualActivityHistory = JsonConvert.DeserializeObject<List<StravaActivity>>(activityHistoryExtracted);
            actualActivityHistory.Count.Should().Be(2);

            var alternativeActivityHistory = sut.GetStravaRecentActivities(stravaAuthToken.access_token, startDate.AddDays(7));
            var alternativeActivityHistoryExtracted = JsonConvert.SerializeObject(alternativeActivityHistory.Value);
            var alternativeActualActivityHistory = JsonConvert.DeserializeObject<List<StravaActivity>>(alternativeActivityHistoryExtracted);
            alternativeActualActivityHistory.Count.Should().Be(0);
        }

        [Test]
        public void GetStravaActivityHistoryWithAcessTokenAndEndDate_CorrectActivityHistoryReturned()
        {
            sut = MakeSut();
            var tokenAsJson = sut.GetStravaAuthenticationToken();
            tokenAsJson.Value.Should().NotBeNull();
            var stravaAuthToken = JsonConvert.DeserializeObject<StravaAuthenticationToken>((string)tokenAsJson.Value);
            stravaAuthToken.access_token.Should().NotBeNullOrEmpty();

            var endDate = DateTime.UtcNow.AddDays(1);

            var activityHistory = sut.GetStravaRecentActivities(stravaAuthToken.access_token, null, endDate);
            activityHistory.Value.Should().NotBeNull();
            var activityHistoryExtracted = JsonConvert.SerializeObject(activityHistory.Value);
            var actualActivityHistory = JsonConvert.DeserializeObject<List<StravaActivity>>(activityHistoryExtracted);
            actualActivityHistory.Count.Should().Be(2);

            var alternativeActivityHistory = sut.GetStravaRecentActivities(stravaAuthToken.access_token, null, endDate.AddDays(-7));
            var alternativeActivityHistoryExtracted = JsonConvert.SerializeObject(alternativeActivityHistory.Value);
            var alternativeActualActivityHistory = JsonConvert.DeserializeObject<List<StravaActivity>>(alternativeActivityHistoryExtracted);
            alternativeActualActivityHistory.Count.Should().Be(0);
        }

        [Test]
        public void GetStravaActivityWithAllParams_CorrectActivityHistoryReturned()
        {
            sut = MakeSut();
            var tokenAsJson = sut.GetStravaAuthenticationToken();
            tokenAsJson.Value.Should().NotBeNull();
            var stravaAuthToken = JsonConvert.DeserializeObject<StravaAuthenticationToken>((string)tokenAsJson.Value);
            stravaAuthToken.access_token.Should().NotBeNullOrEmpty();

            var startDate = DateTime.UtcNow.AddDays(-1);
            var endDate = DateTime.UtcNow.AddDays(1);

            var activityHistory = sut.GetStravaRecentActivities(stravaAuthToken.access_token, startDate, endDate);
            activityHistory.Value.Should().NotBeNull();
            var activityHistoryExtracted = JsonConvert.SerializeObject(activityHistory.Value);
            var actualActivityHistory = JsonConvert.DeserializeObject<List<StravaActivity>>(activityHistoryExtracted);
            actualActivityHistory.Count.Should().Be(2);

            var alternativeActivityHistory = sut.GetStravaRecentActivities(stravaAuthToken.access_token, startDate.AddDays(7), endDate.AddDays(-7));
            var alternativeActivityHistoryExtracted = JsonConvert.SerializeObject(alternativeActivityHistory.Value);
            var alternativeActualActivityHistory = JsonConvert.DeserializeObject<List<StravaActivity>>(alternativeActivityHistoryExtracted);
            alternativeActualActivityHistory.Count.Should().Be(0);
        }

        [Test]
        public void GetSpotifyRecentlyPlayedWithAfterParam_CorrectResponseReturned()
        {
            var now = DateTime.UtcNow.AddDays(-1);
            sut = MakeSut();
            var tokenAsJson = sut.GetSpotifyAuthenticationToken();
            tokenAsJson.Value.Should().NotBeNull();
            var spotifyAuthToken = JsonConvert.DeserializeObject<SpotifyAuthenticationToken>((string)tokenAsJson.Value);
            spotifyAuthToken.AccessToken.Should().NotBeNullOrEmpty();
            var listeningHistory = sut.GetSpotifyRecentlyPlayed(spotifyAuthToken.AccessToken, now);
            listeningHistory.Value.Should().NotBeNull();
            var afterTestJSON = JsonConvert.SerializeObject(listeningHistory.Value);
            var afterTest = JsonConvert.DeserializeObject<CursorPaging<PlayHistoryItem>>(afterTestJSON);
            afterTest.Items.Should().HaveCount(1);
            afterTest.Items.Should().NotBeNull().And.NotBeEmpty();

            listeningHistory = sut.GetSpotifyRecentlyPlayed(spotifyAuthToken.AccessToken);
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
            var fitBitAuthToken = JsonConvert.DeserializeObject<FitBitAuthenticationToken>((string)tokenAsJson.Value);
            fitBitAuthToken.AccessToken.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void GetFitBitActivityHistory_ActivityHistoryReturned()
        {
            sut = MakeSut();
            var tokenAsJson = sut.GetFitBitAuthenticationToken();
            tokenAsJson.Value.Should().NotBeNull();
            var fitBitAuthToken = JsonConvert.DeserializeObject<FitBitAuthenticationToken>((string)tokenAsJson.Value);
            fitBitAuthToken.AccessToken.Should().NotBeNullOrEmpty();

            var activityHistory = sut.GetFitBitRecentActivities(fitBitAuthToken.AccessToken);
            Fitbit.Api.Portable.Models.ActivityLogsList actualHistory = (Fitbit.Api.Portable.Models.ActivityLogsList)activityHistory.Value;
            actualHistory.Should().NotBeNull();
            actualHistory.Should().BeOfType<Fitbit.Api.Portable.Models.ActivityLogsList>();
            actualHistory.Activities.Should().HaveCount(2);
        }

        [Test]
        public void GetFitBitActivityHistoryWithStartDate_ActivityHistoryReturned()
        {
            sut = MakeSut();
            var tokenAsJson = sut.GetFitBitAuthenticationToken();
            tokenAsJson.Value.Should().NotBeNull();
            var fitBitAuthToken = JsonConvert.DeserializeObject<FitBitAuthenticationToken>((string)tokenAsJson.Value);
            fitBitAuthToken.AccessToken.Should().NotBeNullOrEmpty();

            var startDate = DateTime.UtcNow.AddDays(-7);

            var activityHistory = sut.GetFitBitRecentActivities(fitBitAuthToken.AccessToken, startDate);
            Fitbit.Api.Portable.Models.ActivityLogsList actualHistory = (Fitbit.Api.Portable.Models.ActivityLogsList)activityHistory.Value;
            actualHistory.Should().NotBeNull();
            actualHistory.Should().BeOfType<Fitbit.Api.Portable.Models.ActivityLogsList>();
            actualHistory.Activities.Should().HaveCount(2);

            var alternativeActivityHistory = sut.GetFitBitRecentActivities(fitBitAuthToken.AccessToken, startDate.AddDays(7));
            Fitbit.Api.Portable.Models.ActivityLogsList alternativeActualHistory = (Fitbit.Api.Portable.Models.ActivityLogsList)alternativeActivityHistory.Value;
            alternativeActualHistory.Should().NotBeNull();
            alternativeActualHistory.Should().BeOfType<Fitbit.Api.Portable.Models.ActivityLogsList>();
            alternativeActualHistory.Activities.Should().HaveCount(0);
        }

        [Test]
        public void GetFitBitActivityHistoryWithEndDate_ActivityHistoryReturned()
        {
            sut = MakeSut();
            var tokenAsJson = sut.GetFitBitAuthenticationToken();
            tokenAsJson.Value.Should().NotBeNull();
            var fitBitAuthToken = JsonConvert.DeserializeObject<FitBitAuthenticationToken>((string)tokenAsJson.Value);
            fitBitAuthToken.AccessToken.Should().NotBeNullOrEmpty();

            var endDate = DateTime.UtcNow.AddDays(1);

            var activityHistory = sut.GetFitBitRecentActivities(fitBitAuthToken.AccessToken, null, endDate);
            Fitbit.Api.Portable.Models.ActivityLogsList actualHistory = (Fitbit.Api.Portable.Models.ActivityLogsList)activityHistory.Value;
            actualHistory.Should().NotBeNull();
            actualHistory.Should().BeOfType<Fitbit.Api.Portable.Models.ActivityLogsList>();
            actualHistory.Activities.Should().HaveCount(2);

            var alternativeActivityHistory = sut.GetFitBitRecentActivities(fitBitAuthToken.AccessToken, null, endDate.AddDays(-31));
            Fitbit.Api.Portable.Models.ActivityLogsList alternativeActualHistory = (Fitbit.Api.Portable.Models.ActivityLogsList)alternativeActivityHistory.Value;
            alternativeActualHistory.Should().NotBeNull();
            alternativeActualHistory.Should().BeOfType<Fitbit.Api.Portable.Models.ActivityLogsList>();
            alternativeActualHistory.Activities.Should().HaveCount(0);
        }

        [Test]
        public void GetFitBitActivityHistoryWithAllParams_ActivityHistoryReturned()
        {
            sut = MakeSut();
            var tokenAsJson = sut.GetFitBitAuthenticationToken();
            tokenAsJson.Value.Should().NotBeNull();
            var fitBitAuthToken = JsonConvert.DeserializeObject<FitBitAuthenticationToken>((string)tokenAsJson.Value);
            fitBitAuthToken.AccessToken.Should().NotBeNullOrEmpty();

            var startDate = DateTime.UtcNow.AddDays(-7);
            var endDate = DateTime.UtcNow.AddDays(1);

            var activityHistory = sut.GetFitBitRecentActivities(fitBitAuthToken.AccessToken, startDate, endDate);
            Fitbit.Api.Portable.Models.ActivityLogsList actualHistory = (Fitbit.Api.Portable.Models.ActivityLogsList)activityHistory.Value;
            actualHistory.Should().NotBeNull();
            actualHistory.Should().BeOfType<Fitbit.Api.Portable.Models.ActivityLogsList>();
            actualHistory.Activities.Should().HaveCount(2);

            var alternativeActivityHistory = sut.GetFitBitRecentActivities(fitBitAuthToken.AccessToken, startDate.AddDays(7), endDate.AddDays(-31));
            Fitbit.Api.Portable.Models.ActivityLogsList alternativeActualHistory = (Fitbit.Api.Portable.Models.ActivityLogsList)alternativeActivityHistory.Value;
            alternativeActualHistory.Should().NotBeNull();
            alternativeActualHistory.Should().BeOfType<Fitbit.Api.Portable.Models.ActivityLogsList>();
            alternativeActualHistory.Activities.Should().HaveCount(0);
        }

        [Test]
        public void GetLastFMRecentlyPlayedWithoutAfterParam_CorrectResponseReturned()
        {
            sut = MakeSut();
            var listeningHistory = sut.GetLastFMRecentlyPlayed("SomeUser");
            IF.Lastfm.Core.Api.Helpers.PageResponse<IF.Lastfm.Core.Objects.LastTrack> actualHistory = (IF.Lastfm.Core.Api.Helpers.PageResponse<IF.Lastfm.Core.Objects.LastTrack>)listeningHistory.Value;
            actualHistory.Should().NotBeNull();
            actualHistory.Should().BeOfType<IF.Lastfm.Core.Api.Helpers.PageResponse<IF.Lastfm.Core.Objects.LastTrack>>();
            actualHistory.Content.Should().HaveCount(2);
        }

        [Test]
        public void GetLastFMRecentlyPlayedWithAfterParam_CorrectResponseReturned()
        {
            var after = DateTime.UtcNow.AddDays(-1);
            sut = MakeSut();
            var listeningHistory = sut.GetLastFMRecentlyPlayed("SomeUser",after);
            IF.Lastfm.Core.Api.Helpers.PageResponse<IF.Lastfm.Core.Objects.LastTrack> actualHistory = (IF.Lastfm.Core.Api.Helpers.PageResponse<IF.Lastfm.Core.Objects.LastTrack>)listeningHistory.Value;
            actualHistory.Should().NotBeNull();
            actualHistory.Should().BeOfType<IF.Lastfm.Core.Api.Helpers.PageResponse<IF.Lastfm.Core.Objects.LastTrack>>();
            actualHistory.Content.Should().HaveCount(1);
        }

        private ExternalAPIGateway MakeSut()
        {
            return new ExternalAPIGateway(fakeDataRetrievalSource);
        }
    }
}
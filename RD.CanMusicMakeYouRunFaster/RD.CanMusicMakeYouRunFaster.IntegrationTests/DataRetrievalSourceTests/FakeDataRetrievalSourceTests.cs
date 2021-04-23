namespace RD.CanMusicMakeYouRunFaster.Rest.IntegrationTests.DataRetrievalSourcesTests
{
    using System;
    using System.Collections.Generic;
    using DataRetrievalSources;
    using Entity;
    using Fitbit.Api.Portable.Models;
    using FluentAssertions;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.Rest.IntegrationTests.TestUtils;
    using SpotifyAPI.Web;
    using IF.Lastfm.Core;
    using IF.Lastfm.Core.Api.Helpers;
    using IF.Lastfm.Core.Objects;

    public class FakeDataRetrievalSourceTests : TestsBase
    {
        private SpotifyAuthenticationToken spotifyAuthToken;
        private StravaAuthenticationToken stravaAuthToken;
        private FitBitAuthenticationToken fitBitAuthToken;
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

        private readonly List<FakeResponseServer.Models.Strava.Activity> ActivityItems = new List<FakeResponseServer.Models.Strava.Activity>
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
            var now = DateTime.UtcNow;
            var now_local = DateTime.Now;
            var offset = -2;
            foreach (var item in PlayHistoryItems)
            {
                item.PlayedAt = now.AddDays(offset);
                offset++;
            }

            foreach (var item in ActivityItems)
            {
                item.start_date = now;
                item.start_date_local = now_local;
            }

            foreach (var item in FitBitActivityItems)
            {
                item.StartTime = now;
                item.OriginalStartTime = now;
                item.LastModified = now;
            }

            offset = -2;
            foreach (var item in LastFMTrackItems)
            {
                item.TimePlayed = now;
                offset++;
            }

            RegisterMusicHistory(PlayHistoryItems);

            RegisterActivityHistory(ActivityItems);

            RegisterFitBitHistory(FitBitActivityItems);

            RegisterLastFMTracks(LastFMTrackItems);

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

            // Get FitBit auth token.
            var fitBitAuthTask = sut.GetFitBitAuthenticationToken();
            fitBitAuthTask.Result.Should().NotBeNull();
            fitBitAuthTask.Result.Value.Should().NotBeNull();
            temp = JsonConvert.SerializeObject(fitBitAuthTask.Result.Value);
            fitBitAuthToken = JsonConvert.DeserializeObject<FitBitAuthenticationToken>(temp);
            fitBitAuthToken.AccessToken.Should().NotBeNullOrEmpty();
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
        public void GetSpotifyListeningHistoryWithAfterParam_ListeningHistoryRetrieved()
        {
            sut = MakeSut();
            var after = DateTime.UtcNow.AddDays(-1);
            var afterAsUnix = ((DateTimeOffset)after).ToUnixTimeMilliseconds();
            var listeningHistory = sut.GetSpotifyRecentlyPlayed(spotifyAuthToken,afterAsUnix);
            listeningHistory.Result.Value.Should().NotBeNull();
            listeningHistory.Result.Value.Should().NotBe(string.Empty);
            var listeningHistoryJson = JsonConvert.SerializeObject(listeningHistory.Result.Value);
            var actualListeningHistory = JsonConvert.DeserializeObject<CursorPaging<PlayHistoryItem>>(listeningHistoryJson);
            actualListeningHistory.Items.Should().HaveCount(1);
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
            var actualRunningHistory = JsonConvert.DeserializeObject<List<StravaActivity>>(runningHistoryJson);
            actualRunningHistory.Count.Should().Be(2);
            actualRunningHistory[0].Should().BeOfType<StravaActivity>();
        }

        [Test]
        public void GetFitBitActivityHistoryWithValidAuthToken_ActivityHistoryRetrieved()
        {
            sut = MakeSut();
            var runningHistoryTask = sut.GetFitBitActivityHistory(fitBitAuthToken);
            runningHistoryTask.Result.Value.Should().NotBeNull();
            runningHistoryTask.Result.Value.Should().NotBe(string.Empty);
            ActivityLogsList actualRunningHistory = (ActivityLogsList)runningHistoryTask.Result.Value;
            actualRunningHistory.Should().BeOfType<ActivityLogsList>();
            actualRunningHistory.Activities.Should().HaveCount(2);
        }

        [Test]
        public void GetLastFMListeniningHistory_ListeningHistoryReturned()
        {
            sut = MakeSut();
            var listeningHistoryTask = sut.GetLastFMRecentlyPlayed("RD");
            listeningHistoryTask.Result.Value.Should().NotBeNull();
            listeningHistoryTask.Result.Value.Should().NotBe(string.Empty);
            PageResponse<LastTrack> actualPageResponse = (PageResponse<LastTrack>)listeningHistoryTask.Result.Value;
            actualPageResponse.Content.Should().NotBeEmpty();
            actualPageResponse.Content.Should().HaveCount(2);
            actualPageResponse.Content[0].Duration.Should().Be(new TimeSpan(0, 2, 30));
        }

        private FakeDataRetrievalSource MakeSut()
        {
            return new FakeDataRetrievalSource(externalAPICaller, FakeServerAddress);
        }
    }
}

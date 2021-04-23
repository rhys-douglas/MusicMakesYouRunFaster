namespace RD.CanMusicMakeYouRunFaster.Specs.Steps
{
    using System;
    using System.Collections.Generic;
    using ClientDrivers;
    using DataSource;
    using FluentAssertions;
    using SpotifyAPI.Web;
    using TechTalk.SpecFlow;

    [Binding]
    public class CommonSteps
    {

        private readonly IClientDriver clientDriver;
        private readonly DataPort dataSource;
        private readonly List<PlayHistoryItem> listeningHistory = new List<PlayHistoryItem>();
        private readonly List<Rest.Entity.StravaActivity> runningHistory = new List<Rest.Entity.StravaActivity>();

        public CommonSteps(IClientDriver clientDriver, DataPort dataSource)
        {
            this.clientDriver = clientDriver;
            this.dataSource = dataSource;
        }

        [Given(@"a list of Spotify listening history")]
        public void GivenAListOfSpotifyListeningHistory(Table table)
        {
            var fakeListeningHistory = new List<FakeResponseServer.Models.Spotify.PlayHistoryItem>();
            var count = 0;
            foreach (var row in table.Rows)
            {
                var listeningHistoryItem = new PlayHistoryItem
                {
                    PlayedAt = DateTime.ParseExact(row["Time of listening"], "dd'/'MM'/'yyyy HH:mm:ss", null),
                    Track = new SimpleTrack
                    {
                        Artists = new List<SimpleArtist>(),
                        AvailableMarkets = new List<string>(),
                        DiscNumber = 1,
                        DurationMs = 3500,
                        Explicit = false,
                        ExternalUrls = new Dictionary<string, string>(),
                        Href = "https://api.spotify.com/v1/albums/SomeHref",
                        Id = count.ToString(),
                        IsPlayable = true,
                        LinkedFrom = new LinkedTrack
                        {
                            ExternalUrls = new Dictionary<string, string>(),
                            Href = "https://api.spotify.com/v1/albums/SomeOtherHref",
                            Id = count.ToString(),
                            Type = "Track",
                            Uri = "spotify:album:SomeOtherURI"
                        },
                        Name = row["Song name"],
                        PreviewUrl = "https://p.scdn.co/mp3-preview/SomeRef",
                        TrackNumber = 1,
                        Type = ItemType.Track,
                        Uri = "SomeURI",
                    },
                    Context = new Context
                    {
                        ExternalUrls = new Dictionary<string, string>(),
                        Href = "https://api.spotify.com/v1/albums/SomeURI",
                        Type = "Album",
                        Uri = "spotify:album:SomeURI" + count.ToString()
                    }
                };
                var fakeHistoryItem = new FakeResponseServer.Models.Spotify.PlayHistoryItem
                {
                    Id = count.ToString(),
                    PlayedAt = DateTime.ParseExact(row["Time of listening"], "dd'/'MM'/'yyyy HH:mm:ss", null),
                    Track = new FakeResponseServer.Models.Spotify.SimpleTrack
                    {
                        Artists = new List<FakeResponseServer.Models.Spotify.SimpleArtist>(),
                        AvailableMarkets = new List<string>(),
                        DiscNumber = 1,
                        DurationMs = 3500,
                        Explicit = false,
                        ExternalUrls = new Dictionary<string, string>(),
                        Href = "https://api.spotify.com/v1/albums/SomeHref",
                        Id = count.ToString(),
                        IsPlayable = true,
                        LinkedFrom = new FakeResponseServer.Models.Spotify.LinkedTrack
                        {
                            ExternalUrls = new Dictionary<string, string>(),
                            Href = "https://api.spotify.com/v1/albums/SomeOtherHref",
                            Id = count.ToString(),
                            Type = "Track",
                            Uri = "spotify:album:SomeOtherURI"
                        },
                        Name = row["Song name"],
                        PreviewUrl = "https://p.scdn.co/mp3-preview/SomeRef",
                        TrackNumber = 1,
                        Type = FakeResponseServer.Models.Spotify.ItemType.Track,
                        Uri = "SomeURI",
                    },
                    Context = new FakeResponseServer.Models.Spotify.Context
                    {
                        ExternalUrls = new Dictionary<string, string>(),
                        Href = "https://api.spotify.com/v1/albums/SomeURI",
                        Type = "Album",
                        Uri = "spotify:album:SomeURI" + count.ToString()
                    }
                };

                listeningHistory.Add(listeningHistoryItem);
                fakeListeningHistory.Add(fakeHistoryItem);
                count++;
            }
            dataSource.AddListeningHistory(fakeListeningHistory);
        }


        [Given(@"a list of Strava running history")]
        public void GivenAListOfStravaRunningHistory(Table table)
        {
            var fakeRunningHistory = new List<FakeResponseServer.Models.Strava.Activity>();
            int idcounter = 0;
            var now_local = DateTime.Now;
            foreach (var row in table.Rows)
            {
                var fakeHistoryItem = new FakeResponseServer.Models.Strava.Activity
                {
                    achievement_count = 1,
                    athlete_count = 1,
                    athlete = new FakeResponseServer.Models.Strava.Athlete
                    {
                        id = idcounter + 5,
                        resource_state = 2
                    },
                    average_cadence = 75,
                    average_heartrate = 151,
                    average_speed = double.Parse(row["Average Pace (m/s)"]),
                    average_temp = 15,
                    comment_count = 0,
                    commute = false,
                    display_hide_heartrate_option = false,
                    distance = 1900,
                    elapsed_time = int.Parse(row["Elapsed Time of Activity (s)"]),
                    elev_high = 95,
                    elev_low = 90,
                    end_latlng = new List<double>(),
                    external_id = idcounter.ToString(),
                    flagged = false,
                    from_accepted_tag = false,
                    gear_id = "123456",
                    has_heartrate = true,
                    has_kudoed = false,
                    heartrate_opt_out = false,
                    id = row["Activity Id"],
                    kudos_count = 5,
                    location_city = "Cardiff",
                    location_country = "UK",
                    location_state = "CDF",
                    manual = false,
                    map = new FakeResponseServer.Models.Strava.Map
                    {
                        id = idcounter.ToString(),
                        resource_state = 2,
                        summary_polyline = "some summary"
                    },
                    max_heartrate = 200,
                    max_speed = 20,
                    moving_time = int.Parse(row["Elapsed Time of Activity (s)"]) - 5,
                    name = row["Activity Name"],
                    photo_count = 1,
                    Private = true,
                    pr_count = 0,
                    resource_state = 2,
                    start_date_local = now_local,
                    start_date = DateTime.ParseExact(row["Time of activity start"], "dd'/'MM'/'yyyy HH:mm:ss", null),
                    start_latitude = 50.52342,
                    start_latlng = new List<double>(),
                    start_longitude = -1.23432,
                    timezone = "(GMT+01:00) Europe/London",
                    total_elevation_gain = 30,
                    total_photo_count = 0,
                    trainer = false,
                    type = "1",
                    upload_id = "23456789",
                    upload_id_str = "23456789",
                    utc_offset = 0,
                    visibility = "private",
                    workout_type = 1,
                };

                var realHistoryItem = new Rest.Entity.StravaActivity
                {
                    achievement_count = 1,
                    athlete_count = 1,
                    athlete = new Rest.Entity.StravaAthlete
                    {
                        id = idcounter + 5,
                        resource_state = 2
                    },
                    average_cadence = 75,
                    average_heartrate = 151,
                    average_speed = 16.4,
                    average_temp = 15,
                    comment_count = 0,
                    commute = false,
                    display_hide_heartrate_option = false,
                    distance = 1900,
                    elapsed_time = int.Parse(row["Elapsed Time of Activity (s)"]),
                    elev_high = 95,
                    elev_low = 90,
                    end_latlng = null,
                    external_id = idcounter.ToString(),
                    flagged = false,
                    from_accepted_tag = false,
                    gear_id = "123456",
                    has_heartrate = true,
                    has_kudoed = false,
                    heartrate_opt_out = false,
                    id = row["Activity Id"],
                    kudos_count = 5,
                    location_city = "Cardiff",
                    location_country = "UK",
                    location_state = "CDF",
                    manual = false,
                    map = new Rest.Entity.StravaMap
                    {
                        id = idcounter.ToString(),
                        resource_state = 2,
                        summary_polyline = "some summary"
                    },
                    max_heartrate = 200,
                    max_speed = 20,
                    moving_time = int.Parse(row["Elapsed Time of Activity (s)"]) - 5,
                    name = row["Activity Name"],
                    photo_count = 1,
                    Private = true,
                    pr_count = 0,
                    resource_state = 2,
                    start_date_local = now_local,
                    start_date = DateTime.ParseExact(row["Time of activity start"], "dd'/'MM'/'yyyy HH:mm:ss", null),
                    start_latitude = 50.52342,
                    start_latlng = null,
                    start_longitude = -1.23432,
                    timezone = "(GMT+01:00) Europe/London",
                    total_elevation_gain = 30,
                    total_photo_count = 0,
                    trainer = false,
                    type = "1",
                    upload_id = "23456789",
                    upload_id_str = "23456789",
                    utc_offset = 0,
                    visibility = "private",
                    workout_type = 1,
                };

                fakeRunningHistory.Add(fakeHistoryItem);
                runningHistory.Add(realHistoryItem);
                idcounter++;
            }
            dataSource.AddRunningHistory(fakeRunningHistory);
        }

        [Given(@"a list of FitBit running history")]
        public void GivenAListOfFitBitRunningHistory(Table table)
        {

        }

        [Given(@"Given a list of Last.FM listening history")]
        public void GivenAListOfLastFMListeningHistory(Table table)
        {

        }

        [Given(@"a list of users")]
        public void GivenAListOfUsers(Table table)
        {
            // Does nothing.
        }

        [Given(@"a user [""]?([^""]*)[""]?")]
        public void GivenAUser(string user)
        {
            clientDriver.RegisterUser(user);
            // Does nothing.
        }
    }
}

namespace RD.CanMusicMakeYouRunFaster.Specs.Steps
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers;
    using RD.CanMusicMakeYouRunFaster.Specs.DataSource;
    using TechTalk.SpecFlow;

    [Binding]
    public class StravaHistorySteps
    {
        private readonly IClientDriver clientDriver;
        private readonly DataPort dataSource;
        private readonly List<Rest.Entity.Activity> actualHistory = new List<Rest.Entity.Activity>(); 

        public StravaHistorySteps(IClientDriver clientDriver, DataPort dataSource)
        {
            this.clientDriver = clientDriver;
            this.dataSource = dataSource;
        }

        [Given(@"a list of running history")]
        public void GivenAListOfRunningHistory(Table table)
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
                    average_speed = 16.4,
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

                var realHistoryItem = new Rest.Entity.Activity
                {
                    achievement_count = 1,
                    athlete_count = 1,
                    athlete = new Rest.Entity.Athlete
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
                    map = new Rest.Entity.Map
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
                actualHistory.Add(realHistoryItem);
                idcounter++;
            }
            dataSource.AddRunningHistory(fakeRunningHistory);
        }


        [Given(@"their running history")]
        public void GivenTheirRunningHistory()
        {
            // Do something
        }

        [When(@"the user's recent running history is requested")]
        public void WhenTheUsersRunningHistoryIsRequested()
        {
            clientDriver.GetRecentActivities();
        }

        [Then(@"the user's recent running history is produced")]
        public void ThenTheUsersRunningHistoryIsProduced()
        {
            var acquiredListeningHistory = clientDriver.GetFoundItems();
            acquiredListeningHistory.Should().BeEquivalentTo(actualHistory);
        }
    }
}

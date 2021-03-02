namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.UnitTests.ControllerTests
{
    using NUnit.Framework;
    using FluentAssertions;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.DbContext;
    using System;

    public class StravaActivityControllerTests
    {
        private StravaActivityController sut;
        private readonly List<DTO.Activity> activityHistory = new List<DTO.Activity>();

        private readonly Models.Strava.Activity activity1 = new Models.Strava.Activity
        {
            achievement_count = 2,
            athlete = new Models.Strava.Athlete
            {
                id = 1,
                resource_state = 2
            },
            athlete_count = 1,
            average_cadence = 86.1,
            average_heartrate = 191,
            average_speed = 16.5,
            average_temp = 10,
            comment_count = 0,
            commute = false,
            display_hide_heartrate_option = false,
            distance = 30.1,
            elapsed_time = 7200,
            elev_high = 80,
            elev_low = 30,
            end_latlng = new List<double>(),
            external_id = "1234253547687",
            flagged = false,
            from_accepted_tag = false,
            gear_id = "1",
            has_heartrate = true,
            has_kudoed = false,
            heartrate_opt_out = false,
            id = "1234253547687",
            kudos_count = 5,
            location_city = "Oxford",
            location_country = "UK",
            location_state = "OXF",
            manual = false,
            map = new Models.Strava.Map
            {
                id = "Map 1",
                resource_state = 2,
                summary_polyline = "Some data"
            },
            max_heartrate = 200,
            max_speed = 18,
            moving_time = 1234,
            name = "Activity 1",
            photo_count = 0,
            Private = false,
            pr_count = 3,
            resource_state = 1,
            start_date = DateTime.UtcNow,
            start_date_local = DateTime.Now,
            start_latitude = 50.121231,
            start_latlng = new List<double>(),
            start_longitude = -1.2342535,
            timezone = "(GMT+01:00) Europe/London",
            total_elevation_gain = 30,
            total_photo_count = 0,
            trainer = false,
            type = "1",
            upload_id = "1234253547687",
            upload_id_str = "123456789",
            utc_offset = 0,
            visibility = "private",
            workout_type = 1,
        };

        private readonly Models.Strava.Activity activity2 = new Models.Strava.Activity
        {
            achievement_count = 2,
            athlete = new Models.Strava.Athlete
            {
                id = 2,
                resource_state = 2
            },
            athlete_count = 1,
            average_cadence = 86.1,
            average_heartrate = 191,
            average_speed = 16.5,
            average_temp = 10,
            comment_count = 0,
            commute = false,
            display_hide_heartrate_option = false,
            distance = 30.1,
            elapsed_time = 7200,
            elev_high = 80,
            elev_low = 30,
            end_latlng = new List<double>(),
            external_id = "23456789",
            flagged = false,
            from_accepted_tag = false,
            gear_id = "1",
            has_heartrate = true,
            has_kudoed = false,
            heartrate_opt_out = false,
            id = "23456789",
            kudos_count = 5,
            location_city = "Cardiff",
            location_country = "UK",
            location_state = "CF",
            manual = false,
            map = new Models.Strava.Map
            {
                id = "Map 2",
                resource_state = 2,
                summary_polyline = "Some data"
            },
            max_heartrate = 200,
            max_speed = 18,
            moving_time = 1234,
            name = "Activity 2",
            photo_count = 0,
            Private = false,
            pr_count = 3,
            resource_state = 1,
            start_date = DateTime.UtcNow,
            start_date_local = DateTime.Now,
            start_latitude = 50.121231,
            start_latlng = new List<double>(),
            start_longitude = -1.2342535,
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

        private readonly DTO.Activity DTOActivity1 = new DTO.Activity
        {
            achievement_count = 2,
            athlete = new DTO.Athlete
            {
                id = 1,
                resource_state = 2
            },
            athlete_count = 1,
            average_cadence = 86.1,
            average_heartrate = 191,
            average_speed = 16.5,
            average_temp = 10,
            comment_count = 0,
            commute = false,
            display_hide_heartrate_option = false,
            distance = 30.1,
            elapsed_time = 7200,
            elev_high = 80,
            elev_low = 30,
            end_latlng = new List<double>(),
            external_id = "1234253547687",
            flagged = false,
            from_accepted_tag = false,
            gear_id = "1",
            has_heartrate = true,
            has_kudoed = false,
            heartrate_opt_out = false,
            id = "1234253547687",
            kudos_count = 5,
            location_city = "Oxford",
            location_country = "UK",
            location_state = "OXF",
            manual = false,
            map = new DTO.Map
            {
                id = "Map 1",
                resource_state = 2,
                summary_polyline = "Some data"
            },
            max_heartrate = 200,
            max_speed = 18,
            moving_time = 1234,
            name = "Activity 1",
            photo_count = 0,
            Private = false,
            pr_count = 3,
            resource_state = 1,
            start_date = DateTime.UtcNow,
            start_date_local = DateTime.Now,
            start_latitude = 50.121231,
            start_latlng = new List<double>(),
            start_longitude = -1.2342535,
            timezone = "(GMT+01:00) Europe/London",
            total_elevation_gain = 30,
            total_photo_count = 0,
            trainer = false,
            type = "1",
            upload_id = "1234253547687",
            upload_id_str = "123456789",
            utc_offset = 0,
            visibility = "private",
            workout_type = 1,
        };

        private readonly DTO.Activity DTOActivity2 = new DTO.Activity
        {
            achievement_count = 2,
            athlete = new DTO.Athlete
            {
                id = 2,
                resource_state = 2
            },
            athlete_count = 1,
            average_cadence = 86.1,
            average_heartrate = 191,
            average_speed = 16.5,
            average_temp = 10,
            comment_count = 0,
            commute = false,
            display_hide_heartrate_option = false,
            distance = 30.1,
            elapsed_time = 7200,
            elev_high = 80,
            elev_low = 30,
            end_latlng = new List<double>(),
            external_id = "23456789",
            flagged = false,
            from_accepted_tag = false,
            gear_id = "1",
            has_heartrate = true,
            has_kudoed = false,
            heartrate_opt_out = false,
            id = "23456789",
            kudos_count = 5,
            location_city = "Cardiff",
            location_country = "UK",
            location_state = "CF",
            manual = false,
            map = new DTO.Map
            {
                id = "Map 2",
                resource_state = 2,
                summary_polyline = "Some data"
            },
            max_heartrate = 200,
            max_speed = 18,
            moving_time = 1234,
            name = "Activity 2",
            photo_count = 0,
            Private = false,
            pr_count = 3,
            resource_state = 1,
            start_date = DateTime.UtcNow,
            start_date_local = DateTime.Now,
            start_latitude = 50.121231,
            start_latlng = new List<double>(),
            start_longitude = -1.2342535,
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

        private DbContextOptions<DataRetrievalContext> contextOptions;

        [OneTimeSetUp]
        public void SetUp()
        {
            contextOptions = new DbContextOptionsBuilder<DataRetrievalContext>()
                .UseInMemoryDatabase("StravaActivityControllerDatabase")
                .Options;

            using var context = new DataRetrievalContext(contextOptions);
            var now_UTC = DateTime.UtcNow;
            var now_local = DateTime.Now;

            activity1.start_date = now_UTC;
            activity1.start_date_local = now_local;
            activity2.start_date = now_UTC;
            activity2.start_date_local = now_local;
            DTOActivity1.start_date = now_UTC;
            DTOActivity1.start_date_local = now_local;
            DTOActivity2.start_date = now_UTC;
            DTOActivity2.start_date_local = now_local;

            activityHistory.Add(DTOActivity1);
            activityHistory.Add(DTOActivity2);

            context.ActivityHistoryItems.Add(activity1);
            context.ActivityHistoryItems.Add(activity2);
            context.SaveChanges();
        }

        [Test]
        public void GetAthleteActivities_ActivitiesReturned()
        {
            sut = new StravaActivityController(new DataRetrievalContext(contextOptions));
            var getResult = sut.GetLoggedInAthleteActivities();
            getResult.Result.Should().NotBeEmpty();
            getResult.Result.Count.Should().Be(2);
            var retrievedActivities = new List<DTO.Activity>();
            foreach (var activity in getResult.Result)
            {
                retrievedActivities.Add(activity);
            }
            retrievedActivities.Should().HaveCount(2);
            retrievedActivities.Should().BeEquivalentTo(activityHistory);
        }
    }
}

namespace RD.CanMusicMakeYouRunFaster.Rest.UnitTests.GatewayTests
{
    using FluentAssertions;
    using RD.CanMusicMakeYouRunFaster.Rest.Gateways;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using System.Collections.Generic;
    using System;
    using NUnit.Framework;
    using Fitbit.Api.Portable.Models;
    using Fitbit.Models;

    public class InferenceAPIGatewayTests
    {
        private readonly List<StravaActivity> StravaActivityHistory = new List<StravaActivity>
        {
            new StravaActivity
            {
                resource_state = 1,
                athlete = new StravaAthlete
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
                map = new StravaMap
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
                average_speed = 13,
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
            new StravaActivity
            {
                resource_state = 1,
                athlete = new StravaAthlete
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
                map = new StravaMap
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
        private readonly ActivityLogsList FitBitActivityHistory = new ActivityLogsList
        {
            Activities = new List<Activities>
            {
                new Activities
                {
                    ActiveDuration = 5,
                    ActivityLevel = new List<ActivityLevel>(),
                    ActivityName = "Run 1",
                    ActivityTypeId = 5,
                    AverageHeartRate = 140,
                    Calories = 500,
                    Distance = 3500,
                    DistanceUnit = "M",
                    Duration = 3600,
                    ElevationGain = 330,
                    HeartRateZones = new List<HeartRateZone>(),
                    LastModified = DateTime.Now,
                    LogId = 123253464353,
                    LogType = "logtype1",
                    ManualValuesSpecified = new ManualValuesSpecified
                    {
                        Distance = false,
                        Calories = false,
                        Steps = false,
                    },
                    OriginalDuration = 3601,
                    OriginalStartTime = DateTime.Now,
                    Pace = 16.5,
                    Source = new ActivityLogSource
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
                new Activities
                {
                    ActiveDuration = 5,
                    ActivityLevel = new List<ActivityLevel>(),
                    ActivityName = "Run 2",
                    ActivityTypeId = 5,
                    AverageHeartRate = 140,
                    Calories = 500,
                    Distance = 3500,
                    DistanceUnit = "M",
                    Duration = 3600,
                    ElevationGain = 330,
                    HeartRateZones = new List<HeartRateZone>(),
                    LastModified = DateTime.Now,
                    LogId = 23456789,
                    LogType = "logtype2",
                    ManualValuesSpecified = new ManualValuesSpecified
                    {
                        Distance = true,
                        Calories = false,
                        Steps = false,
                    },
                    OriginalDuration = 3601,
                    OriginalStartTime = DateTime.Now,
                    Pace = 16.3,
                    Source = new ActivityLogSource
                    {
                        Id = "2",
                        Name = "2",
                        Type = "type2",
                        Url = "url2"
                    },
                    Speed = 20,
                    StartTime = DateTime.Now,
                    Steps = 14000,
                    TcxLink = "??"
                }
            }
        };

        [Test]
        public void GetFastestStravaActivity_FastestActivityReturned()
        {
            var sut = MakeSut();
            var fastestActivity = sut.PostFastestStravaActivity(StravaActivityHistory).Value;
            StravaActivity fastestAct = (StravaActivity)fastestActivity;
            fastestAct.name.Should().Be("Activity 1");
        }

        [Test]
        public void GetFastestStravaActivityWithEmptyList_NullReturned()
        {
            var sut = MakeSut();
            var nullActivity = sut.PostFastestStravaActivity(new List<StravaActivity>()).Value;
            nullActivity.Should().BeNull();
        }

        [Test]
        public void GetFastestFitBitActivity_FastestActivityReturned()
        {
            var sut = MakeSut();
            var fastestActivity = sut.PostFastestFitBitActivity(FitBitActivityHistory).Value;
            Activities fastestAct = (Activities)fastestActivity;
            fastestAct.ActivityName.Should().Be("Run 2");
        }

        [Test]
        public void GetFastestFitBitActivityWithEmptyList_NullReturned()
        {
            var sut = MakeSut();
            var nullActivity = sut.PostFastestFitBitActivity(new ActivityLogsList()).Value;
            nullActivity.Should().BeNull();
        }

        [Test]
        public void GetFastestFitBitActivityWithNullList_NullReturned()
        {
            var sut = MakeSut();
            var nullActivity = sut.PostFastestFitBitActivity(new ActivityLogsList { Activities = null }).Value;
            nullActivity.Should().BeNull();
        }

        [Test]
        public void FindFastestActivity_DateTimeOfFastestActivityReturned()
        {

        }

        private InferenceAPIGateway MakeSut()
        {
            return new InferenceAPIGateway();
        }
    }
}

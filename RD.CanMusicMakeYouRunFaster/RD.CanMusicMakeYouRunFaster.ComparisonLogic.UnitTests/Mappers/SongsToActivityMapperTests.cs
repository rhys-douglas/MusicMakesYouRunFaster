namespace RD.CanMusicMakeYouRunFaster.ComparisonLogic.UnitTests.Mappers
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.ComparisonLogic.Mappers;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using SpotifyAPI.Web;

    public class SongsToActivityMapperTests
    {
        private SongsToActivityMapper sut;

        [Test]
        public void MapWithCorrectParams_CorrectResultsReturned()
        {
            var startTime = DateTime.UtcNow;
            var endTime = startTime.AddMinutes(20);

            sut = new SongsToActivityMapper();
            var fakeActivity = new StravaActivity
            {
                achievement_count = 2,
                athlete = new StravaAthlete
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
                elapsed_time = 1200,
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
                map = new StravaMap
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
                start_date = startTime,
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

            var fakeListeningHistory = new List<PlayHistoryItem>
            {
                new PlayHistoryItem
                {
                    Context = new Context(),
                    PlayedAt = startTime.AddSeconds(1),
                    Track = new SimpleTrack
                    {
                        Name = "Song 1",
                        Id = "1",
                        DurationMs = 180000
                    }
                },
                new PlayHistoryItem
                {
                    Context = new Context(),
                    PlayedAt = startTime.AddMinutes(1),
                    Track = new SimpleTrack
                    {
                        Name = "Song 2",
                        Id = "2",
                        DurationMs = 90000
                    }
                },
                new PlayHistoryItem
                {
                    Context = new Context(),
                    PlayedAt = startTime.AddMinutes(-20),
                    Track = new SimpleTrack
                    {
                        Name = "Song 3",
                        Id = "3",
                        DurationMs = 500
                    }
                },
                new PlayHistoryItem
                {
                    Context = new Context(),
                    PlayedAt = startTime.AddMinutes(5),
                    Track = new SimpleTrack
                    {
                        Name = "Song 4",
                        Id = "4",
                        DurationMs = 1500
                    }
                }
            };

            var mappedSongsToActivity = SongsToActivityMapper.MapSongsToActivity(fakeActivity,fakeListeningHistory);

            mappedSongsToActivity.Count.Should().Be(1);
            mappedSongsToActivity[fakeActivity].Count.Should().Be(3);
            mappedSongsToActivity[fakeActivity][0].Track.Id.Should().Be("1");
            mappedSongsToActivity[fakeActivity][1].Track.Id.Should().Be("2");
            mappedSongsToActivity[fakeActivity][2].Track.Id.Should().Be("4");
        }
    }
}

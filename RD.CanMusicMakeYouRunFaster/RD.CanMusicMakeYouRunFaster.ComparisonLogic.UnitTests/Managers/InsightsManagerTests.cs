﻿namespace RD.CanMusicMakeYouRunFaster.ComparisonLogic.UnitTests.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.ComparisonLogic.Managers;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using SpotifyAPI.Web;

    public class InsightsManagerTests
    {
        private InsightsManager sut;

        [Test]
        public void GetFastestActivitySongs_FastestActivitySongsReturned()
        {
            var now = DateTime.UtcNow;

            var activity1 = new Activity
            {
                type = "Run",
                average_speed = 3.5,
                start_date = now.AddHours(-2),
                elapsed_time = 3600
            };
            var listOfActivity1PlayHistory = new List<PlayHistoryItem>
            {
                new PlayHistoryItem
                {
                    PlayedAt = now.AddHours(-2),
                    Track = new SimpleTrack
                    {
                        Name = "Song 1",
                        DurationMs = 3600
                    }
                },

                new PlayHistoryItem
                {
                    PlayedAt = now.AddHours(-2).AddMinutes(5),
                    Track = new SimpleTrack
                    {
                        Name = "Song 2",
                        DurationMs = 3600
                    }
                },

                new PlayHistoryItem
                {
                    PlayedAt = now.AddHours(-2).AddMinutes(10),
                    Track = new SimpleTrack
                    {
                        Name = "Song 3",
                        DurationMs = 3600
                    }
                }
            };

            var activity2 = new Activity
            {
                type = "Run",
                average_speed = 4.5,
                start_date = now.AddHours(-1),
                elapsed_time = 3600
            };

            var listOfActivity2PlayHistory = new List<PlayHistoryItem>
            {
                new PlayHistoryItem
                {
                    PlayedAt = now.AddHours(-1).AddMinutes(5),
                    Track = new SimpleTrack
                    {
                        Name = "Faster Song 1",
                        DurationMs = 600
                    }
                },

                new PlayHistoryItem
                {
                    PlayedAt = now.AddHours(-1).AddMinutes(10),
                    Track = new SimpleTrack
                    {
                        Name = "Faster Song 2",
                        DurationMs = 900
                    }
                },

                new PlayHistoryItem
                {
                    PlayedAt = now.AddHours(-1).AddMinutes(15),
                    Track = new SimpleTrack
                    {
                        Name = "Faster Song 3",
                        DurationMs = 1200
                    }
                },

                new PlayHistoryItem
                {
                    PlayedAt = now.AddHours(-1).AddMinutes(20),
                    Track = new SimpleTrack
                    {
                        Name = "Faster Song 4",
                        DurationMs = 600
                    }
                },
            };

            var sampleData = new Dictionary<Activity, List<PlayHistoryItem>>
            {
                { activity1, listOfActivity1PlayHistory },
                { activity2, listOfActivity2PlayHistory }
            };

            sut = new InsightsManager();
            var result = sut.GetFastestActivityWithListeningHistory(sampleData);
            result.Keys.Should().Contain(activity2);
            result.Keys.Should().HaveCount(1);
            result.Values.ToList()[0].Should().BeEquivalentTo(listOfActivity2PlayHistory);
        }

        [Test]
        public void GetFastestActivitySongsWithNoActivitiesOrSongs_ExceptionThrown()
        {
            sut = new InsightsManager();
            Action exceptionAction = () => sut.GetFastestActivityWithListeningHistory(new Dictionary<Activity, List<PlayHistoryItem>>());
            exceptionAction.Should().Throw<IndexOutOfRangeException>().WithMessage("No activities in parsed array dictionary.");
        }
    }
}

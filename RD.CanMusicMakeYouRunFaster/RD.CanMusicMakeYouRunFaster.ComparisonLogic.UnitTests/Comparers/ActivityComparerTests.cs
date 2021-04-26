namespace RD.CanMusicMakeYouRunFaster.ComparisonLogic.UnitTests.Comparers
{
    using Fitbit.Api.Portable.Models;
    using FluentAssertions;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.ComparisonLogic.Comparers;
    using RD.CanMusicMakeYouRunFaster.Rest.Entity;
    using System;
    using System.Collections.Generic;

    public class ActivityComparerTests
    {
        [Test]
        public void FindFastestActivity_FastestActivityReturned()
        {
            var now_UTC = DateTime.UtcNow;
            var sampleActivities = new List<object>
            {
                new StravaActivity
                {
                    id = "1",
                    start_date = now_UTC,
                    elapsed_time = 500,
                    average_speed = 3
                },
                new StravaActivity
                {
                    id = "2",
                    start_date = now_UTC.AddDays(1),
                    elapsed_time = 700,
                    average_speed = 4.5
                },
                new StravaActivity
                {
                    id = "3",
                    start_date = now_UTC.AddDays(-7),
                    elapsed_time = 100,
                    average_speed = 5
                },
            };
            var result = ActivityComparer.FindFastestActivity(sampleActivities);
            StravaActivity stravaResult = (StravaActivity)result;
            stravaResult.id.Should().Be("3");
            stravaResult.average_speed.Should().Be(5);
        }

        [Test]
        public void FindFastestActivityWithFitBitActivitiesIncluded_FastestActivityReturned()
        {
            var now_UTC = DateTime.UtcNow;
            var sampleActivities = new List<object>
            {
                new StravaActivity
                {
                    id = "1",
                    start_date = now_UTC,
                    elapsed_time = 500,
                    average_speed = 3
                },
                new StravaActivity
                {
                    id = "2",
                    start_date = now_UTC.AddDays(1),
                    elapsed_time = 700,
                    average_speed = 4.5
                },
                new StravaActivity
                {
                    id = "3",
                    start_date = now_UTC.AddDays(-7),
                    elapsed_time = 100,
                    average_speed = 5
                },
                new Activities
                {
                    LogId = 4,
                    StartTime = now_UTC.AddDays(1),
                    Duration = 500,
                    Speed = 6
                }
            };
            var result = ActivityComparer.FindFastestActivity(sampleActivities);
            var activitiesResult = (Activities)result;
            activitiesResult.LogId.Should().Be(4);
            activitiesResult.Speed.Should().Be(6);
        }

        [Test]
        public void FindFastestActivityWithEmptyList_ExceptionThrown()
        {
            var emptyActivityList = new List<object>();
            Action a = () => ActivityComparer.FindFastestActivity(emptyActivityList);
            a.Should().Throw<NullReferenceException>().WithMessage("FindFastestActivity: No Activities Parsed.");
        }
    }
}

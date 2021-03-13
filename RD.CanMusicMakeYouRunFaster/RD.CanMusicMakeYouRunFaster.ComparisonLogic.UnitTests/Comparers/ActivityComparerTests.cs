namespace RD.CanMusicMakeYouRunFaster.ComparisonLogic.UnitTests.Comparers
{
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
            var sampleActivities = new List<Activity>
            {
                new Activity
                {
                    id = "1",
                    start_date = now_UTC,
                    elapsed_time = 500,
                    average_speed = 3
                },
                new Activity
                {
                    id = "2",
                    start_date = now_UTC.AddDays(1),
                    elapsed_time = 700,
                    average_speed = 4.5
                },
                new Activity
                {
                    id = "3",
                    start_date = now_UTC.AddDays(-7),
                    elapsed_time = 100,
                    average_speed = 5
                },
            };
            var result = ActivityComparer.FindFastestActivity(sampleActivities);
            result.id.Should().Be("3");
            result.average_speed.Should().Be(5);
        }

        [Test]
        public void FindFastestActivityWithEmptyList_ExceptionThrown()
        {
            var emptyActivityList = new List<Activity>();
            Action a = () => ActivityComparer.FindFastestActivity(emptyActivityList);
            a.Should().Throw<IndexOutOfRangeException>().WithMessage("Empty activity list");
        }
    }
}

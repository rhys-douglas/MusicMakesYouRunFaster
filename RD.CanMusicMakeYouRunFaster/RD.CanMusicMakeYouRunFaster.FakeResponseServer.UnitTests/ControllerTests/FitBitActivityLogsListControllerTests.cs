namespace RD.CanMusicMakeYouRunFaster.FakeResponseServer.UnitTests.ControllerTests
{
    using System.Collections.Generic;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.Controllers;
    using NUnit.Framework;
    using RD.CanMusicMakeYouRunFaster.FakeResponseServer.DbContext;
    using Microsoft.EntityFrameworkCore;
    using System;
    using FluentAssertions;

    public class FitBitActivityLogsListControllerTests
    {
        private FitBitActivityLogsListController sut;

        private readonly List<DTO.FitBitActivities> listOfActivities = new List<DTO.FitBitActivities>();

        private readonly Models.FitBit.Activities ContextFitBitActivity1 = new Models.FitBit.Activities
        {
            ActiveDuration = 5,
            ActivityLevel = new List<Models.FitBit.ActivityLevel>(),
            ActivityName = "Run 1",
            ActivityTypeId = 5,
            AverageHeartRate = 140,
            Calories = 500,
            DateOfActivity = "17/04/2021",
            Distance = 3500,
            DistanceUnit = "M",
            Duration = 3600,
            ElevationGain = 330,
            HeartRateZones = new List<Models.FitBit.HeartRateZone>(),
            LastModified = DateTime.Now,
            LogId = 123253464353,
            LogType = "logtype1",
            ManualValuesSpecified = new Models.FitBit.ManualValuesSpecified
            {
                Distance = false,
                Calories = false,
                Steps = false,
            },
            OriginalDuration = 3601,
            OriginalStartTime = DateTime.Now,
            Pace = 16.5,
            Source = new Models.FitBit.ActivityLogSource
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
        };

        private readonly Models.FitBit.Activities ContextFitBitActivity2 = new Models.FitBit.Activities
        {
            ActiveDuration = 5,
            ActivityLevel = new List<Models.FitBit.ActivityLevel>(),
            ActivityName = "Run 2",
            ActivityTypeId = 5,
            AverageHeartRate = 140,
            Calories = 500,
            DateOfActivity = "18/04/2021",
            Distance = 3500,
            DistanceUnit = "M",
            Duration = 3600,
            ElevationGain = 330,
            HeartRateZones = new List<Models.FitBit.HeartRateZone>(),
            LastModified = DateTime.Now,
            LogId = 23456789,
            LogType = "logtype2",
            ManualValuesSpecified = new Models.FitBit.ManualValuesSpecified
            {
                Distance = true,
                Calories = false,
                Steps = false,
            },
            OriginalDuration = 3601,
            OriginalStartTime = DateTime.Now,
            Pace = 16.5,
            Source = new Models.FitBit.ActivityLogSource
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
        };

        private readonly DTO.FitBitActivities DTOFitBitActivity1 = new DTO.FitBitActivities
        {
            ActiveDuration = 5,
            ActivityLevel = null,
            ActivityName = "Run 1",
            ActivityTypeId = 5,
            AverageHeartRate = 140,
            Calories = 500,
            DateOfActivity = "17/04/2021",
            Distance = 3500,
            DistanceUnit = "M",
            Duration = 3600,
            ElevationGain = 330,
            HeartRateZones = null,
            LastModified = DateTime.Now,
            LogId = 123253464353,
            LogType = "logtype1",
            ManualValuesSpecified = new DTO.ManualValuesSpecified
            {
                Distance = false,
                Calories = false,
                Steps = false,
            },
            OriginalDuration = 3601,
            OriginalStartTime = DateTime.Now,
            Pace = 16.5,
            Source = new DTO.ActivityLogSource
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
        };

        private readonly DTO.FitBitActivities DTOFitBitActivity2 = new DTO.FitBitActivities
        {
            ActiveDuration = 5,
            ActivityLevel = null,
            ActivityName = "Run 2",
            ActivityTypeId = 5,
            AverageHeartRate = 140,
            Calories = 500,
            DateOfActivity = "18/04/2021",
            Distance = 3500,
            DistanceUnit = "M",
            Duration = 3600,
            ElevationGain = 330,
            HeartRateZones = null,
            LastModified = DateTime.Now,
            LogId = 23456789,
            LogType = "logtype2",
            ManualValuesSpecified = new DTO.ManualValuesSpecified
            {
                Distance = true,
                Calories = false,
                Steps = false
            },
            OriginalDuration = 3601,
            OriginalStartTime = DateTime.Now,
            Pace = 16.5,
            Source = new DTO.ActivityLogSource
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

            ContextFitBitActivity1.LastModified = now_UTC;
            ContextFitBitActivity1.OriginalStartTime = now_UTC;
            ContextFitBitActivity1.StartTime = now_UTC;

            ContextFitBitActivity2.LastModified = now_UTC;
            ContextFitBitActivity2.OriginalStartTime = now_UTC;
            ContextFitBitActivity2.StartTime = now_UTC;

            DTOFitBitActivity1.LastModified = now_UTC;
            DTOFitBitActivity1.OriginalStartTime = now_UTC;
            DTOFitBitActivity1.StartTime = now_UTC;

            DTOFitBitActivity2.LastModified = now_UTC;
            DTOFitBitActivity2.OriginalStartTime = now_UTC;
            DTOFitBitActivity2.StartTime = now_UTC;

            listOfActivities.Add(DTOFitBitActivity1);
            listOfActivities.Add(DTOFitBitActivity2);

            context.FitBitActivityItems.Add(ContextFitBitActivity1);
            context.FitBitActivityItems.Add(ContextFitBitActivity2);
            context.SaveChanges();
        }

        [Test]
        public void GetAuthenticatedUserLogList()
        {
            sut = new FitBitActivityLogsListController(new DataRetrievalContext(contextOptions));
            var getResult = sut.GetAuthenticatedUserLogList();
            getResult.Result.Activities.Should().NotBeEmpty();
            getResult.Result.Activities.Count.Should().Be(2);
            var retrievedActivities = new List<DTO.FitBitActivities>();
            foreach (var activity in getResult.Result.Activities)
            {
                retrievedActivities.Add(activity);
            }
            retrievedActivities.Should().HaveCount(2);
            retrievedActivities.Should().BeEquivalentTo(listOfActivities);
        }
    }
}

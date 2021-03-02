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

        };

        private DbContextOptions<DataRetrievalContext> contextOptions;

        [OneTimeSetUp]
        public void SetUp()
        {
            contextOptions = new DbContextOptionsBuilder<DataRetrievalContext>()
                .UseInMemoryDatabase("StravaActivityControllerDatabase")
                .Options;

            using var context = new DataRetrievalContext(contextOptions);
            var now = DateTime.UtcNow;
            /*
            item1.PlayedAt = now;
            item2.PlayedAt = now;
            item3.PlayedAt = now;
            DTOItem1.PlayedAt = now;
            DTOItem2.PlayedAt = now;
            DTOItem3.PlayedAt = now;

            listeningHistory.Add(DTOItem1);
            listeningHistory.Add(DTOItem2);
            listeningHistory.Add(DTOItem3);

            context.PlayHistoryItems.Add(item1);
            context.PlayHistoryItems.Add(item2);
            context.PlayHistoryItems.Add(item3);
            */
            context.ActivityHistoryItems.Add(activity1);
            context.ActivityHistoryItems.Add(activity2);
            context.SaveChanges();
        }
    }
}

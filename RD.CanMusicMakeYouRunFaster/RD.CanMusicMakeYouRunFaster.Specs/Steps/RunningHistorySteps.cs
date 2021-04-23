namespace RD.CanMusicMakeYouRunFaster.Specs.Steps
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers;
    using RD.CanMusicMakeYouRunFaster.Specs.DataSource;
    using TechTalk.SpecFlow;
    using NUnit.Framework;

    [Binding]
    public class RunningHistorySteps
    {
        private readonly IClientDriver clientDriver;
        private readonly DataPort dataSource;

        public RunningHistorySteps(IClientDriver clientDriver, DataPort dataSource)
        {
            this.clientDriver = clientDriver;
            this.dataSource = dataSource;
        }


        [Given(@"their Strava running history")]
        public void GivenTheirStravaRunningHistory()
        {
            // Do something
        }

        [When(@"the user's recent running history is requested")]
        public void WhenTheUsersRunningHistoryIsRequested()
        {
            clientDriver.GetRecentStravaActivities();
        }

        [When(@"the user's recent Strava running history is requested")]
        public void WhenTheUsersStravaRunningHistoryIsRequested()
        {
            clientDriver.GetRecentStravaActivities();
        }

        [When(@"When the user's recent FitBit running history is requested")]
        public void WhenTheUsersFitBitRunningHistoryIsRequested()
        {
            clientDriver.GetRecentFitBitActivities();
        }

        [Then(@"Then the user's recent FitBit running history is produced")]
        public void ThenTheUsersFitBitRunningHistoryIsProduced()
        {
            Assert.Fail();
        }

        [Then(@"the user's recent Strava running history is produced")]
        public void ThenTheUsersRecentStravaRunningHistoryIsProduced()
        {
            var acquiredItems = clientDriver.GetFoundItems();
            var actualRunningHistory = new List<Rest.Entity.StravaActivity>();

            foreach (var item in acquiredItems)
            {
                if (item is Rest.Entity.StravaActivity run)
                {
                    actualRunningHistory.Add(run);
                }
            }

            actualRunningHistory[0].name.Should().Be("Cardiff Friday Morning Run");
            actualRunningHistory[1].name.Should().Be("Oxford Half Marathon");
            actualRunningHistory[2].name.Should().Be("Roath Lake Midnight Run");
            actualRunningHistory[3].name.Should().Be("Late Night Run");
            actualRunningHistory[4].name.Should().Be("Test Run");
        }

        [Then(@"the user's recent running history is produced")]
        public void ThenTheUsersRunningHistoryIsProduced()
        {
            var acquiredItems = clientDriver.GetFoundItems();
            var actualRunningHistory = new List<Rest.Entity.StravaActivity>();

            foreach (var item in acquiredItems)
            {
                if (item is Rest.Entity.StravaActivity run)
                {
                    actualRunningHistory.Add(run);
                }
            }

            actualRunningHistory[0].name.Should().Be("Cardiff Friday Morning Run");
            actualRunningHistory[1].name.Should().Be("Oxford Half Marathon");
            actualRunningHistory[2].name.Should().Be("Roath Lake Midnight Run");
            actualRunningHistory[3].name.Should().Be("Late Night Run");
            actualRunningHistory[4].name.Should().Be("Test Run");
        }
    }
}

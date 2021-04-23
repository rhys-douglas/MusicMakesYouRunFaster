namespace RD.CanMusicMakeYouRunFaster.Specs.Steps
{
    using FluentAssertions;
    using System.Collections.Generic;
    using RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers;
    using RD.CanMusicMakeYouRunFaster.Specs.DataSource;
    using TechTalk.SpecFlow;

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
            // Does nothing
        }

        [Given(@"their FitBit running history")]
        public void GivenTheirFitBitRunningHistory()
        {
            // Does nothing
        }

        [When(@"the user's recent FitBit running history is requested")]
        public void WhenTheUsersRecentFitBitRunningHistoryIsRequested()
        {
            clientDriver.GetRecentFitBitActivities();
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

        [Then(@"the user's recent FitBit running history is produced")]
        public void ThenTheUsersRecentFitBitRunningHistoryIsProduced()
        {
            var acquiredItems = clientDriver.GetFoundItems();
            var actualRunningHistory = new List<Fitbit.Api.Portable.Models.Activities>();

            foreach (var item in acquiredItems)
            {
                if (item is Fitbit.Api.Portable.Models.Activities run)
                {
                    actualRunningHistory.Add(run);
                }
            }

            actualRunningHistory[0].ActivityName.Should().Be("Cardiff Friday Morning Run");
            actualRunningHistory[1].ActivityName.Should().Be("Oxford Half Marathon");
            actualRunningHistory[2].ActivityName.Should().Be("Roath Lake Midnight Run");
            actualRunningHistory[3].ActivityName.Should().Be("Late Night Run");
            actualRunningHistory[4].ActivityName.Should().Be("Test Run");
        }
    }
}

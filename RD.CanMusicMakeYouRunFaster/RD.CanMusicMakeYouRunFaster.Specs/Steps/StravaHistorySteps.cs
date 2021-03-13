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
    public class StravaHistorySteps
    {
        private readonly IClientDriver clientDriver;
        private readonly DataPort dataSource;

        public StravaHistorySteps(IClientDriver clientDriver, DataPort dataSource)
        {
            this.clientDriver = clientDriver;
            this.dataSource = dataSource;
        }


        [Given(@"their running history")]
        public void GivenTheirRunningHistory()
        {
            // Do something
        }

        [When(@"the user's recent running history is requested")]
        public void WhenTheUsersRunningHistoryIsRequested()
        {
            clientDriver.GetRecentActivities();
        }

        [Then(@"the user's recent running history is produced")]
        public void ThenTheUsersRunningHistoryIsProduced()
        {
            var acquiredItems = clientDriver.GetFoundItems();
            var actualRunningHistory = new List<Rest.Entity.Activity>();

            foreach (var item in acquiredItems)
            {
                if (item is Rest.Entity.Activity run)
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

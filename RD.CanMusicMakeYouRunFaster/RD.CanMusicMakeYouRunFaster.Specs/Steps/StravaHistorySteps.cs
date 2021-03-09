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
            var acquiredListeningHistory = clientDriver.GetFoundItems();
            // acquiredListeningHistory.Should().BeEquivalentTo(actualHistory);
            Assert.Fail();
        }
    }
}

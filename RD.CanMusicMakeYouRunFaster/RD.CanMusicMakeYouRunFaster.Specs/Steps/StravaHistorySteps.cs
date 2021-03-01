namespace RD.CanMusicMakeYouRunFaster.Specs.Steps
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers;
    using RD.CanMusicMakeYouRunFaster.Specs.DataSource;
    using TechTalk.SpecFlow;

    [Binding]
    public class StravaHistorySteps
    {
        private readonly IClientDriver clientDriver;
        private readonly DataPort dataSource;
        private readonly List<FakeResponseServer.Models.Strava.Activity> actualHistory = new List<FakeResponseServer.Models.Strava.Activity>(); 

        public StravaHistorySteps(IClientDriver clientDriver, DataPort dataSource)
        {
            this.clientDriver = clientDriver;
            this.dataSource = dataSource;
        }

        [Given(@"a list of running history")]
        public void GivenAListOfRunningHistory(Table table)
        {
            var fakeRunningHistory = new List<FakeResponseServer.Models.Strava.Activity>();
            int idcounter = 0;

            foreach (var row in table.Rows)
            {
                var fakeHistoryItem = new FakeResponseServer.Models.Strava.Activity
                {
                    external_id = idcounter.ToString(),
                    name = row["Activity Name"],
                    start_date = DateTime.ParseExact(row["Time of activity start"], "dd'/'MM'/'yyyy HH:mm:ss", null),
                    elapsed_time = int.Parse(row["Elapsed Time of Activity (s)"]),
                };
                fakeRunningHistory.Add(fakeHistoryItem);
                idcounter++;
            }
            dataSource.AddRunningHistory(fakeRunningHistory);
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
            acquiredListeningHistory.Should().BeEquivalentTo(actualHistory);
        }
    }
}

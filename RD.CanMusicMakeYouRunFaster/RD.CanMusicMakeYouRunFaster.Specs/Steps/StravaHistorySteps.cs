namespace RD.CanMusicMakeYouRunFaster.Specs.Steps
{
    using FluentAssertions;
    using NUnit.Framework;
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
        private readonly List<StravaSharp.Activity> actualHistory = new List<StravaSharp.Activity>(); 

        public StravaHistorySteps(IClientDriver clientDriver, DataPort dataSource)
        {
            this.clientDriver = clientDriver;
            this.dataSource = dataSource;
        }

        [Given(@"a list of running history")]
        public void GivenAListOfRunningHistory(Table table)
        {
            var convertedRunningHistory = new List<StravaSharp.Activity>();
            var fakeRunningHistory = new List<FakeResponseServer.Models.Strava.Activity>();

            foreach (var row in table.Rows)
            {
                var fakeHistoryItem = new FakeResponseServer.Models.Strava.Activity
                {
                    Name = row["Activity Name"],
                    StartDate = DateTime.ParseExact(row["Time of activity start"], "dd'/'MM'/'yyyy HH:mm:ss", null),
                    ElapsedTime = int.Parse(row["Elapsed Time of Activity (s)"]),
                };
                fakeRunningHistory.Add(fakeHistoryItem);
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
            
        }

        [Then(@"the user's recent running history is produced")]
        public void ThenTheUsersRunningHistoryIsProduced()
        {

        }
    }
}

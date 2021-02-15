namespace RD.CanMusicMakeYouRunFaster.Specs.Steps
{
    using System.Collections.Generic;
    using FluentAssertions;
    using RD.CanMusicMakeYouRunFaster.Specs.ClientDrivers;
    using TechTalk.SpecFlow;

    [Binding]
    public class MusicHistorySteps
    {
        private readonly IClientDriver clientDriver;
        private readonly List<Dictionary<string, string>> listeningHistory = new List<Dictionary<string, string>>();

        public MusicHistorySteps(IClientDriver clientDriver)
        {
            this.clientDriver = clientDriver;
        }

        [Given(@"a list of users")]
        public void GivenAListOfUsers(Table table)
        {
            // Temporarily redundant
        }

        [Given(@"a list of listening history")]
        public void GivenAListOfListeningHistory(Table table)
        {
            foreach (var row in table.Rows)
            {
                var rowOfHistory = new Dictionary<string, string>
                {
                    { row["Song name"], row["Time of listening"] }
                };
                listeningHistory.Add(rowOfHistory);
            }
        }

        [Given(@"a user [""]?([^""]*)[""]?")]
        public void GivenAUser(string user)
        {
            // Does something
        }

        [Given(@"their listening history")]
        public void GivenTheirListeningHistory()
        {
            // Do something
        }

        [When(@"the user's recently played history is requested")]
        public void WhenTheUserSRecentlyPlayedHistoryIsRequested()
        {
            clientDriver.GetRecentlyPlayedMusic();
        }

        [Then(@"the user's recently played history is produced")]
        public void ThenTheUserSRecentlyPlayedHistoryIsProduced()
        {
            var acquiredListeningHistory = clientDriver.GetFoundItems();
            acquiredListeningHistory.Should().BeEquivalentTo(listeningHistory);
        }
    }
}

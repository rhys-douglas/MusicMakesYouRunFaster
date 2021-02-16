namespace RD.CanMusicMakeYouRunFaster.Specs.Steps
{
    using System;
    using System.Collections.Generic;
    using ClientDrivers;
    using DataSource;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class MusicHistorySteps
    {
        private readonly IClientDriver clientDriver;
        private readonly FakeDataSource dataSource;
        private readonly List<Dictionary<string, string>> listeningHistory = new List<Dictionary<string, string>>();

        public MusicHistorySteps(IClientDriver clientDriver, FakeDataSource dataSource)
        {
            this.clientDriver = clientDriver;
            this.dataSource = dataSource;
        }

        [Given(@"a list of users")]
        public void GivenAListOfUsers(Table table)
        {
            // Temporarily redundant
        }

        [Given(@"a list of listening history")]
        public void GivenAListOfListeningHistory(Table table)
        {
            var convertedListeningHistory = new List<SpotifyAPI.Web.PlayHistoryItem>();
            foreach (var row in table.Rows)
            {
                var rowOfHistory = new Dictionary<string, string>
                {
                    { row["Song name"], row["Time of listening"] }
                };
                listeningHistory.Add(rowOfHistory);

                var listeningHistoryItem = new SpotifyAPI.Web.PlayHistoryItem
                {
                    PlayedAt = DateTime.ParseExact(row["Time of listening"], "dd'/'MM'/'yyyy HH:mm:ss", null),
                    Track = new SpotifyAPI.Web.SimpleTrack
                    {
                        Name = row["Song name"]
                    }
                };

                convertedListeningHistory.Add(listeningHistoryItem);
            }
            dataSource.AddListeningHistory(convertedListeningHistory);
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
